using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Net;
using MiniTravelingExplorer.Models;
using MiniTravelingExplorer.Utils;
using Newtonsoft.Json;
using System.Configuration;
using System.IO;
using System.Net.Mail;
using AutoMapper;
using MiniTravelingExplorer.Models.Configuration;

namespace MiniTravelingExplorer.Services
{
    public class LoginService : BaseService
    {
        public User LoginUser(User user, string returnUrl)
        {
            User responseUser = new User();

            bool isValidPassword = false;

            EntityModel.User userPasswordDetail = GetUserPassword(user.Email, string.Empty, 0, false);

            if (userPasswordDetail != null)
            {
                isValidPassword = UtilFunction.VerifyHashedPassword(userPasswordDetail.Password, user.Password, userPasswordDetail.SaltKey);
            }

            SqlCommand sqlCommand = new SqlCommand(Constant.GET_USER_BY_EMAIL_SP, connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@Email", user.Email);
            sqlCommand.Parameters.Add("@Password", SqlDbType.NVarChar, 200);
            sqlCommand.Parameters["@Password"].Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add("@NoOfAttempt", SqlDbType.Int);
            sqlCommand.Parameters["@NoOfAttempt"].Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add("@LockedOutDateTime", SqlDbType.DateTime);
            sqlCommand.Parameters["@LockedOutDateTime"].Direction = ParameterDirection.Output;

            DataSet dataSet = new DataSet();
            int maxTimeOutMinutes = Convert.ToInt32(ConfigurationManager.AppSettings[Constant.USER_LOCK_OUT_TIME_KEY]);

            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand))
            {
                dataAdapter.Fill(dataSet, Constant.USER_TABLE);

                if (dataSet != null)
                {
                    DateTime? lockedOutDateTime = (DateTime?)null;
                    DateTime? unlockTime = (DateTime?)null;
                    int timeRemaining = 0;
                    int noOfAttempt = 0;
                    bool isLockedOut;

                    if (dataAdapter.SelectCommand.Parameters["@NoOfAttempt"].Value != DBNull.Value)
                    {
                        noOfAttempt = Convert.ToInt32(dataAdapter.SelectCommand.Parameters["@NoOfAttempt"].Value);
                    }

                    if (dataAdapter.SelectCommand.Parameters["@LockedOutDateTime"].Value != DBNull.Value)
                    {
                        lockedOutDateTime = Convert.ToDateTime(dataAdapter.SelectCommand.Parameters["@LockedOutDateTime"].Value);
                        unlockTime = lockedOutDateTime?.AddMinutes(maxTimeOutMinutes);
                    }

                    isLockedOut = (lockedOutDateTime != null && unlockTime != null && lockedOutDateTime <= unlockTime) ||
                            noOfAttempt > Convert.ToInt32(ConfigurationManager.AppSettings[Constant.USER_LOCK_OUT_MAX_ATTEMPT_KEY]);

                    if (isLockedOut)
                    {
                        timeRemaining = GetRemainingTime(lockedOutDateTime, maxTimeOutMinutes);

                        EntityModel.User lockedOutUserInfo = GetUserLockOutInfo(user.Email, isValidPassword, timeRemaining);

                        if (lockedOutUserInfo?.LockedOutDateTime != null)
                        {
                            lockedOutDateTime = lockedOutUserInfo.LockedOutDateTime;
                            timeRemaining = GetRemainingTime(lockedOutDateTime, maxTimeOutMinutes);
                            isLockedOut = timeRemaining > 0 && (noOfAttempt > 0 && (lockedOutDateTime != null));
                        }
                    }

                    if (isLockedOut && timeRemaining > 0)
                    {
                        httpResponse.StatusCode = HttpStatusCode.Unauthorized;
                        httpResponse.ErrorMessage = string.Format(Constant.USER_LOCKED_OUT_ERROR_MESSAGE, (timeRemaining == 0 ? 1 : timeRemaining));
                    }
                    else if (!isValidPassword)
                    {
                        httpResponse.StatusCode = HttpStatusCode.Unauthorized;
                        httpResponse.ErrorMessage = Constant.USER_NOT_FOUND_INVALID_CREDENTIALS_ERROR_MESSAGE;
                    }
                    else
                    {
                        DataTable dt = dataSet.Tables[Constant.USER_TABLE];
                        List<EntityModel.User> userList = UtilFunction.DataTableToList<EntityModel.User>(dt);

                        if (userList != null && userList.Any())
                        {
                            GetUserLockOutInfo(user.Email, true, 0);

                            EntityModel.User entityUser = userList.FirstOrDefault();

                            if (!entityUser.IsActivated)
                            {
                                httpResponse.StatusCode = HttpStatusCode.Unauthorized;
                                httpResponse.ErrorMessage = Constant.USER_NOT_ACTIVATE_ERROR_MESSAGE;
                            }
                            else
                            {
                                if (!string.IsNullOrWhiteSpace(entityUser.Email) && !string.IsNullOrWhiteSpace(entityUser.FullName))
                                {
                                    EntityModel.User userDetail = UtilFunction.DataTableToObject<EntityModel.User>(dt);
                                    Mapper mapper = AutoMapperConfiguration.InitializeAutomapper();
                                    user = mapper.Map<EntityModel.User, User>(userDetail);

                                    httpResponse.StatusCode = HttpStatusCode.OK;
                                    httpResponse.IsRedirect = true;

                                    string controller = string.Empty;
                                    string action = string.Empty;
                                    UtilFunction.GetControllerActionFromUrl(returnUrl, out controller, out action);
                                    httpResponse.Controller = controller;
                                    httpResponse.Action = action;
                                    httpResponse.ResponseData = new User()
                                    {
                                        Email = entityUser.Email
                                    };

                                    responseUser = new User()
                                    {
                                        UserId = entityUser.UserId,
                                        Email = entityUser.Email,
                                        FullName = entityUser.FullName,
                                        SaltKey = entityUser.SaltKey,
                                        UserPhotoType = entityUser.UserPhotoType,
                                        UserPhoto = entityUser.UserPhoto
                                    };
                                }
                                else
                                {
                                    httpResponse.StatusCode = HttpStatusCode.Unauthorized;
                                    httpResponse.ErrorMessage = Constant.USER_NOT_FOUND_INVALID_CREDENTIALS_ERROR_MESSAGE;
                                }
                            }
                        }
                        else
                        {
                            httpResponse.StatusCode = HttpStatusCode.Unauthorized;
                            httpResponse.ErrorMessage = Constant.USER_NOT_FOUND_INVALID_CREDENTIALS_ERROR_MESSAGE;
                        }
                    }
                }
            }

            responseUser.HttpResponse = httpResponse;

            return responseUser;
        }

        public string UpdateUserLogin(User user, string activationData, bool isActivate, string password = "", bool isSendPasswordResetLink = false, string serverMapPath = "")
        {
            string emailBody = string.Empty;
            string fullName = string.Empty;
            var decryptedActivationData = UtilFunction.DecryptString(activationData);
            LoginUser loginUser = JsonConvert.DeserializeObject<LoginUser>(decryptedActivationData);

            if (loginUser != null && (DateTime.UtcNow <= loginUser.ExpiryDate))
            {
                if (!string.IsNullOrWhiteSpace(password))
                {
                    EntityModel.User userPasswordDetail = GetUserPassword(loginUser.Email, string.Empty, 0, false);

                    if (userPasswordDetail != null)
                    {
                        loginUser.Password = UtilFunction.HashPassword(password, userPasswordDetail.SaltKey);
                    }
                }
            }
            else if (isSendPasswordResetLink)
            {
                string passwordResetKey = Guid.NewGuid().ToString();

                loginUser = new LoginUser
                {
                    Email = user.Email,
                    FullName = user.FullName,
                    PasswordResetKey = passwordResetKey,
                    ExpiryDate = DateTime.UtcNow.AddDays(Convert.ToDouble(ConfigurationManager.AppSettings[Constant.PASSWORD_RESET_LINK_EXPIRY_DAYS_KEY]))
                };

                string passwordResetUrl = string.Concat(ConfigurationManager.AppSettings[Constant.BASE_URL_KEY], Constant.PASSWORD_RESET_LINK, UtilFunction.EncryptString(JsonConvert.SerializeObject(loginUser)));

                emailBody = UtilFunction.GetFileData(Path.Combine(serverMapPath, Constant.TEMPLATE_PATH, Constant.EMAIL_TEMPLATE_FOLDER, Constant.USER_RESET_PASSWORD_TEMPLATE_FILE)).Replace(Constant.EMAIL_TEMPLATE_PASSWORD_RESET_LINK, passwordResetUrl).Replace(Constant.EMAIL_ACTIVATION_HOME_PAGE_URL, ConfigurationManager.AppSettings[Constant.BASE_URL_KEY]);
            }

            SqlCommand sqlCommand = new SqlCommand(Constant.UPDATE_LOGIN_USER_SP, connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            sqlCommand.Parameters.Add("@Email", SqlDbType.NVarChar, 100).Value = loginUser.Email;
            sqlCommand.Parameters.Add("@Password", SqlDbType.NVarChar, 200).Value = !isActivate ? (string.IsNullOrEmpty(loginUser.Password) ? (object)DBNull.Value : loginUser.Password) : (object)DBNull.Value;
            sqlCommand.Parameters.Add("@FullName", SqlDbType.NVarChar, 100).Value = isActivate ? loginUser.FullName : (object)DBNull.Value;
            sqlCommand.Parameters.Add("@ActivationKey", SqlDbType.NVarChar, 50).Value = isActivate ? loginUser.ActivationKey : string.Empty;
            sqlCommand.Parameters.Add("@PasswordResetKey", SqlDbType.NVarChar, 50).Value = !isActivate ? loginUser.PasswordResetKey : string.Empty;
            sqlCommand.Parameters.Add("@IsActivate", SqlDbType.Bit).Value = isActivate;

            using (connection)
            {
                connection.Open();
                NoOfRowsAffected = sqlCommand.ExecuteNonQuery();
            }

            if (NoOfRowsAffected > 0)
            {
                fullName = (isSendPasswordResetLink || !string.IsNullOrEmpty(loginUser.Password)) ? loginUser.Email : loginUser.FullName;

                if (isSendPasswordResetLink)
                {
                    EmailService.SendEmail(new MailAddress(user.Email, user.Email), Constant.USER_RESET_PASSWORD_SUBJECT, emailBody);
                }
            }

            return fullName;
        }
        private EntityModel.User GetUserLockOutInfo(string email, bool isValidPassword, int timeRemaining)
        {
            EntityModel.User userDetail = new EntityModel.User();

            SqlCommand sqlCommand = new SqlCommand(Constant.GET_USER_LOCK_OUT_INFO_SP, connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            sqlCommand.Parameters.AddWithValue("@Email", email);
            sqlCommand.Parameters.AddWithValue("@IsValidPassword", isValidPassword && timeRemaining <= 0);
            sqlCommand.Parameters.AddWithValue("@IsValidateLockOutTime", timeRemaining <= 0);
            sqlCommand.Parameters.Add("@LockedOutDateTime", SqlDbType.DateTime);
            sqlCommand.Parameters["@LockedOutDateTime"].Direction = ParameterDirection.Output;

            DataSet dataSet = new DataSet();

            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand))
            {
                dataAdapter.Fill(dataSet, Constant.USER_TABLE);

                if (dataSet != null)
                {
                    dataAdapter.Fill(dataSet, Constant.USER_TABLE);
                    DataTable dataTable = dataSet.Tables[Constant.USER_TABLE];
                    userDetail = UtilFunction.DataTableToObject<EntityModel.User>(dataTable);
                }
            }

            return userDetail;
        }

        private int GetRemainingTime(DateTime? lockedOutDateTime, int maxTimeOutMinutes)
        {
            var unlockTime = lockedOutDateTime?.AddMinutes(maxTimeOutMinutes + 1);
            return !unlockTime.HasValue ? maxTimeOutMinutes : unlockTime.Value.Subtract(DateTime.UtcNow).Minutes;
        }
    }
}