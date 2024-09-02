using AutoMapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using MiniTravelingExplorer.Models;
using MiniTravelingExplorer.Utils;
using EntityModel = MiniTravelingExplorer.EntityModel;
using System.Configuration;
using System.IO;
using System.Net.Mail;
using MiniTravelingExplorer.Exceptions;
using MiniTravelingExplorer.Models.Configuration;

namespace MiniTravelingExplorer.Services
{
    public class AccountService : BaseService
    {
        public User GetUserDetail(string email, int userId)
        {
            User user = new User();

            using (connection)
            {
                using (SqlDataAdapter dataAdapter = new SqlDataAdapter())
                {
                    dataAdapter.SelectCommand = new SqlCommand(Constant.GET_USER_BY_EMAIL_AND_ID_SP, connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    dataAdapter.SelectCommand.Parameters.Add("@Email", SqlDbType.NVarChar, 100).Value = email;
                    dataAdapter.SelectCommand.Parameters.Add("@UserId", SqlDbType.Int).Value = userId;

                    DataSet dataSet = new DataSet();

                    if (dataSet != null)
                    {
                        dataAdapter.Fill(dataSet, Constant.USER_TABLE);
                        DataTable dt = dataSet.Tables[Constant.USER_TABLE];
                        EntityModel.User userDetail = UtilFunction.DataTableToObject<EntityModel.User>(dt);
                        Mapper mapper = AutoMapperConfiguration.InitializeAutomapper();
                        user = mapper.Map<EntityModel.User, User>(userDetail);
                    }
                }
            }

            return user;
        }

        public ChecklistData GetMyChecklistData(int userId)
        {
            ChecklistData checklistData = new ChecklistData();

            SqlCommand sqlCommand = new SqlCommand(Constant.GET_CHECKLIST_DATA_SP, connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            sqlCommand.Parameters.Add("@UserId", SqlDbType.Int).Value = userId;

            DataSet dataSet = new DataSet();

            using (connection)
            {
                using (SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand))
                {
                    dataAdapter.Fill(dataSet, Constant.CHECKLIST_DATA);

                    if (dataSet != null && dataSet.Tables != null && dataSet.Tables.Count >= 2)
                    {
                        Mapper mapper = AutoMapperConfiguration.InitializeAutomapper();

                        if (dataSet.Tables[0] != null)
                        {
                            List<EntityModel.MyChecklist> entityMyChecklistList = UtilFunction.DataTableToList<EntityModel.MyChecklist>(dataSet.Tables[0]);
                            checklistData.ChecklistList = mapper.Map<List<EntityModel.MyChecklist>, List<MyChecklist>>(entityMyChecklistList);
                        }

                        if (dataSet.Tables[1] != null)
                        {
                            List<EntityModel.ActiveBooking> entityActiveBooking = UtilFunction.DataTableToList<EntityModel.ActiveBooking>(dataSet.Tables[1]);
                            checklistData.ActiveBookingList = mapper.Map<List<EntityModel.ActiveBooking>, List<ActiveBooking>>(entityActiveBooking);

                            if (checklistData.ActiveBookingList.Any())
                            {
                                checklistData.ActiveBooking = JsonConvert.SerializeObject(checklistData.ActiveBookingList);
                            }
                        }
                    }
                }
            }

            if (checklistData.ChecklistList.Any())
            {
                int count = 1;
                float animationDelayTime = 0.1f;

                checklistData.ChecklistList.ForEach(c =>
                {
                    if (count == 1)
                    {
                        animationDelayTime = 0.1f;
                    }
                    else if (count == 3)

                    {
                        count = 0;
                        animationDelayTime *= 2;
                    }
                    else
                    {
                        animationDelayTime += animationDelayTime * 2;
                    }

                    c.AnimationDelayTime = string.Concat(animationDelayTime, Constant.S_CHARACTER.ToLower());
                    count++;
                });
            }

            return checklistData;
        }

        public bool InsertChecklist(string checklistName, int userId, int? bookingId)
        {
            bool isChecklistNameExists = false;

            SqlCommand sqlCommand = new SqlCommand(Constant.INSERT_CHECKLIST_SP, connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            sqlCommand.Parameters.Add("@CheckListName", SqlDbType.NVarChar, 100).Value = checklistName;
            sqlCommand.Parameters.Add("@BookingId", SqlDbType.Int).Value = bookingId;
            sqlCommand.Parameters.Add("@ShareLink", SqlDbType.NVarChar, 500).Value = Guid.NewGuid().ToString();
            sqlCommand.Parameters.Add("@UserId", SqlDbType.Int).Value = userId;

            SqlParameter isChecklistNameExistsOutputParameter = sqlCommand.Parameters.Add("@IsChecklistNameExists", SqlDbType.Bit);
            isChecklistNameExistsOutputParameter.Direction = ParameterDirection.Output;

            using (connection)
            {
                connection.Open();
                NoOfRowsAffected = sqlCommand.ExecuteNonQuery();
            }

            if (isChecklistNameExistsOutputParameter.Value != DBNull.Value)
            {
                isChecklistNameExists = Convert.ToBoolean(isChecklistNameExistsOutputParameter.Value);
            }

            return isChecklistNameExists;
        }

        public void DeleteChecklist(int checklistId, int userId, int bookingId)
        {
            SqlCommand sqlCommand = new SqlCommand(Constant.DELETE_CHECKLIST_SP, connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            sqlCommand.Parameters.Add("@CheckListId", SqlDbType.Int).Value = checklistId;
            sqlCommand.Parameters.Add("@BookingId", SqlDbType.Int).Value = bookingId;
            sqlCommand.Parameters.Add("@UserId", SqlDbType.Int).Value = userId;

            using (connection)
            {
                connection.Open();
                NoOfRowsAffected = sqlCommand.ExecuteNonQuery();
            }
        }

        public int InsertUpdateChecklistItem(AddChecklistItem addChecklistItem, int userId, bool isAdd, string createText, string updateText)
        {
            int createdChecklistItemId = 0;
            
            using (connection)
            {
                using (SqlCommand sqlCommand = new SqlCommand(Constant.INSERT_UPDATE_CHECKLIST_ITEM_SP, connection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@ChecklistId", addChecklistItem.ChecklistId);
                    sqlCommand.Parameters.AddWithValue("@ChecklistItemId", addChecklistItem.ChecklistItemId);
                    sqlCommand.Parameters.AddWithValue("@CheckListItemName", addChecklistItem.ChecklistItemName);
                    sqlCommand.Parameters.AddWithValue("@BookingId", addChecklistItem.BookingId);
                    sqlCommand.Parameters.AddWithValue("@UserId", userId);
                    sqlCommand.Parameters.AddWithValue("@IsChecked", addChecklistItem.IsChecked);

                    SqlParameter isChecklistItemExistsOutputParameter = sqlCommand.Parameters.Add("@IsChecklistItemExists", SqlDbType.Bit);
                    isChecklistItemExistsOutputParameter.Direction = ParameterDirection.Output;

                    SqlParameter createdChecklistItemIdOutputParameter = sqlCommand.Parameters.Add("@CreatedChecklistItemId", SqlDbType.Int);
                    createdChecklistItemIdOutputParameter.Direction = ParameterDirection.Output;

                    connection.Open();
                    NoOfRowsAffected = sqlCommand.ExecuteNonQuery();

                    if (Convert.ToBoolean(isChecklistItemExistsOutputParameter.Value))
                    {
                        throw new CustomException(string.Format(Constant.CHECKLIST_ITEM_NAME_ALREADY_EXISTS_ERROR_MESSAGE, (isAdd ? createText : updateText)));
                    }

                    if (isAdd && createdChecklistItemIdOutputParameter.Value != DBNull.Value)
                    {
                        createdChecklistItemId = Convert.ToInt32(createdChecklistItemIdOutputParameter.Value);
                    }
                }
            }

            return createdChecklistItemId;
        }

        public void DeleteChecklistItem(int checklistItemId, int userId, int checklistId, int bookingId)
        {
            SqlCommand sqlCommand = new SqlCommand(Constant.DELETE_CHECKLIST_ITEM_SP, connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            sqlCommand.Parameters.Add("@CheckListItemId", SqlDbType.Int).Value = checklistItemId;
            sqlCommand.Parameters.Add("@CheckListId", SqlDbType.Int).Value = checklistId;
            sqlCommand.Parameters.Add("@BookingId", SqlDbType.Int).Value = bookingId;
            sqlCommand.Parameters.Add("@UserId", SqlDbType.Int).Value = userId;

            using (connection)
            {
                connection.Open();
                NoOfRowsAffected = sqlCommand.ExecuteNonQuery();
            }
        }

        public ChecklistShareResponseData GetChecklistShareData(Checklist checklist, int userId, string fullName, string serverMapPath)
        {
            Checklist checklistData = new Checklist();
            ChecklistShareResponseData checklistShareResponseData = new ChecklistShareResponseData();

            switch (checklist.Option.ToLower())
            {
                case Constant.EMAIL_LOWER:
                    httpResponse.SuccessMessage = Constant.EMAIL_LINK_CHECKLIST_ITEM_SUCCESS_MESSAGE;
                    httpResponse.ErrorMessage = Constant.EMAIL_LINK_CHECKLIST_ITEM_ERROR_MESSAGE;
                    break;
                case Constant.COPY_LINK_LOWER:
                    httpResponse.SuccessMessage = Constant.COPY_LINK_CHECKLIST_ITEM_SUCCESS_MESSAGE;
                    httpResponse.ErrorMessage = Constant.COPY_LINK_CHECKLIST_ITEM_ERROR_MESSAGE;
                    break;
            }

            checklistShareResponseData.HttpResponse = httpResponse;

            using (connection)
            {
                using (SqlDataAdapter dataAdapter = new SqlDataAdapter())
                {
                    dataAdapter.SelectCommand = new SqlCommand(Constant.GET_CHECKLIST_SHARE_DATA_SP, connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    dataAdapter.SelectCommand.Parameters.Add("@ChecklistId", SqlDbType.Int).Value = checklist.ChecklistId;
                    dataAdapter.SelectCommand.Parameters.Add("@CheckListName", SqlDbType.NVarChar, 100).Value = checklist.Name;
                    dataAdapter.SelectCommand.Parameters.Add("@BookingId", SqlDbType.Int).Value = checklist.BookingId;
                    dataAdapter.SelectCommand.Parameters.Add("@UserId", SqlDbType.Int).Value = userId;

                    DataSet dataSet = new DataSet();

                    if (dataSet != null)
                    {
                        dataAdapter.Fill(dataSet, Constant.CHECKLIST_SHARE_DATA);
                        DataTable dt = dataSet.Tables[Constant.CHECKLIST_SHARE_DATA];
                        EntityModel.Checklist entityChecklistData = UtilFunction.DataTableToObject<EntityModel.Checklist>(dt);
                        Mapper mapper = AutoMapperConfiguration.InitializeAutomapper();
                        checklistData = mapper.Map<EntityModel.Checklist, Checklist>(entityChecklistData);
                    }
                }
            }

            if (checklistData != null)
            {
                checklistShareResponseData.Option = checklist.Option;
                checklistShareResponseData.ShareLink = string.Concat(ConfigurationManager.AppSettings[Constant.BASE_URL_KEY], Constant.VIEW_CHECK_LIST_ITEM_LINK, UtilFunction.EncryptString(JsonConvert.SerializeObject(new Checklist
                {
                    ShareLink = checklistData.ShareLink,
                    BookingId = checklist.BookingId
                })));

                if (string.Compare(checklist.Option.ToLower(), Constant.EMAIL_LOWER) == 0)
                {
                    string tripDate = string.Concat(checklistData.TripDate.ToString(Constant.DATETIME_DEFAULT_FORMAT), Constant.STRING_WHITE_SPACE, Constant.UTC_STRING);

                    string emailBody = UtilFunction.GetFileData(Path.Combine(serverMapPath, Constant.TEMPLATE_PATH, Constant.EMAIL_TEMPLATE_FOLDER, Constant.CHECKLIST_SHARE_LINK_TEMPLATE_FILE))
                                       .Replace(Constant.EMAIL_ACTIVATION_USER_FULL_NAME, fullName)
                                       .Replace(Constant.EMAIL_LOCATION_NAME, checklistData.LocationName)
                                       .Replace(Constant.EMAIL_TRIP_DATE, tripDate)
                                       .Replace(Constant.EMAIL_TRIP_DATE, tripDate)
                                       .Replace(Constant.EMAIL_CHECKLIST_SHARE_URL, checklistShareResponseData.ShareLink);

                    EmailService.SendEmail(
                        new MailAddress(checklist.EmailTo, checklist.EmailTo),
                        string.Format(Constant.CHECKLIST_ITEM_SHARED_LINK_SUCCESSFUL_SUBJECT, checklistData.LocationName, tripDate),
                        emailBody
                        );
                }
            }

            return checklistShareResponseData;
        }

        public void UpdateUserEmail(User user, bool isUpdateEmail, int userId, string fullName, string serverMapPath)
        {
            string changeEmailCode = isUpdateEmail ? user.ChangeEmailCode.ToString() : UtilFunction.RandomNumberGenerator(1000, 10000);
            string emailBody = UtilFunction.GetFileData(Path.Combine(serverMapPath, Constant.TEMPLATE_PATH, Constant.EMAIL_TEMPLATE_FOLDER, Constant.USER_EMAIL_CHANGE_TEMPLATE_FILE))
                .Replace(Constant.EMAIL_TEMPLATE_VERIFICATION_CODE, changeEmailCode)
                .Replace(Constant.EMAIL_ACTIVATION_HOME_PAGE_URL, ConfigurationManager.AppSettings[Constant.BASE_URL_KEY])
                .Replace(Constant.EMAIL_FULL_NAME, Constant.FULL_NAME);

            user.ChangeEmailCode = Convert.ToInt32(changeEmailCode);

            SqlCommand sqlCommand = new SqlCommand(Constant.UPDATE_USER_EMAIL_SP, connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            sqlCommand.Parameters.Add("@UserId", SqlDbType.Int).Value = userId;
            sqlCommand.Parameters.Add("@Email", SqlDbType.NVarChar, 100).Value = user.Email;
            sqlCommand.Parameters.Add("@ChangeEmailCode", SqlDbType.Int).Value = user.ChangeEmailCode;
            sqlCommand.Parameters.Add("@ChangeEmailRequested", SqlDbType.NVarChar, 100).Value = user.ChangeEmailRequested;
            sqlCommand.Parameters.Add("@IsUpdateEmail", SqlDbType.Bit).Value = isUpdateEmail;

            using (connection)
            {
                connection.Open();
                NoOfRowsAffected = sqlCommand.ExecuteNonQuery();
            }

            if (NoOfRowsAffected > 0 && !isUpdateEmail)
            {
                EmailService.SendEmail(new MailAddress(user.ChangeEmailRequested, fullName), Constant.CHANGE_USER_EMAIL_SUBJECT, emailBody);
            }
        }

        public void UpdateUserPassword(User user, int userId, string email, string fullName, string serverMapPath)
        {
            EntityModel.User userDetail = new EntityModel.User();

            using (SqlDataAdapter dataAdapter = new SqlDataAdapter())
            {
                userDetail = GetUserPassword(email, fullName, userId, true);

                if (userDetail == null || !UtilFunction.VerifyHashedPassword(userDetail.Password, user.CurrentPassword, userDetail.SaltKey))
                {
                    NoOfRowsAffected = - 1;
                }
            }

            SqlCommand sqlCommand = new SqlCommand(Constant.UPDATE_USER_PASSWORD_SP, connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            sqlCommand.Parameters.Add("@UserId", SqlDbType.Int).Value = userId;
            sqlCommand.Parameters.Add("@Email", SqlDbType.NVarChar, 100).Value = email;
            sqlCommand.Parameters.Add("@Password", SqlDbType.NVarChar, 200).Value = UtilFunction.HashPassword(user.Password, userDetail.SaltKey);

            using (connection)
            {
                connection.Open();
                NoOfRowsAffected = sqlCommand.ExecuteNonQuery();
            }

            if (NoOfRowsAffected > 0)
            {
                string emailBody = UtilFunction.GetFileData(Path.Combine(serverMapPath, Constant.TEMPLATE_PATH, Constant.EMAIL_TEMPLATE_FOLDER, Constant.USER_PASSWORD_CHANGE_TEMPLATE_FILE)).Replace(Constant.EMAIL_ACTIVATION_HOME_PAGE_URL, ConfigurationManager.AppSettings[Constant.BASE_URL_KEY]);

                EmailService.SendEmail(new MailAddress(email, fullName), Constant.CHANGE_USER_PASSWORD_SUCCESSFUL_SUBJECT, emailBody);
            }
        }
    }
}