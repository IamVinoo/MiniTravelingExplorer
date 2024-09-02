using Newtonsoft.Json;
using System;
using System.Data.SqlClient;
using System.Net;
using System.Web.Mvc;
using MiniTravelingExplorer.Filters;
using MiniTravelingExplorer.Models;
using MiniTravelingExplorer.Services;
using MiniTravelingExplorer.Utils;

namespace MiniTravelingExplorer.Controllers
{
    public class RegisterController : BaseService
    {
        readonly RegisterService registerService = new RegisterService();

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Register()
        {
            if (Session[Constant.USER_ID] != null)
            {
                return RedirectToAction(Constant.HOME_ACTION, Constant.HOME_CONTROLLER);
            }

            try
            {
                ViewData[Constant.SECURITY_QUESTION_TABLE] = GetSecurityQuestion();
            }
            catch (Exception exception)
            {
                logger.Error(exception, UtilFunction.ConcatLogMessage(exception.Message));
            }

            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public string InsertUser(User user)
        {
            try
            {
                user.FullName = string.Concat(user.FirstName + Constant.STRING_WHITE_SPACE + user.LastName);
                registerService.InsertUpdateUserProfile(user, true, Convert.ToInt32(Session[Constant.USER_ID]), Server.MapPath(Constant.SERVER_MAP_PATH));

                if (registerService.NoOfRowsAffected > 0)
                {
                    httpResponse.StatusCode = HttpStatusCode.OK;
                    httpResponse.SuccessMessage = Constant.USER_ADDED_SUCCESS_MESSAGE;
                    httpResponse.IsRedirect = true;
                    httpResponse.Action = Constant.LOGIN_ACTION;
                    httpResponse.Controller = Constant.LOGIN_CONTROLLER;
                }
                else
                {
                    httpResponse.StatusCode = HttpStatusCode.InternalServerError;
                    httpResponse.ErrorMessage = string.Concat(Constant.USER_NOT_ADDED_ERROR_MESSAGE, Constant.STRING_WHITE_SPACE, Constant.CONTACT_CUSTOMER_SUPPORT_MESSAGE);
                }
            }
            catch (SqlException sqlException)
            {
                if (sqlException.Number == 2627)
                {
                    httpResponse.ErrorMessage = Constant.EMAIL_ALREADY_EXISTS_ERROR_MESSAGE;
                }
                else
                {
                    httpResponse.ErrorMessage = sqlException.Message;
                }

                logger.Error(sqlException, UtilFunction.ConcatLogMessage(sqlException.Message));
            }
            catch (Exception exception)
            {
                httpResponse.ErrorMessage = exception.Message;

                logger.Error(exception, UtilFunction.ConcatLogMessage(exception.Message));
            }

            return JsonConvert.SerializeObject(httpResponse);
        }

        [JwtAuthenticationFilter]
        [HttpPost]
        public string UpdateUser(User user)
        {
            try
            {
                user.FullName = string.Concat(user.FirstName + Constant.STRING_WHITE_SPACE + user.LastName);
                registerService.InsertUpdateUserProfile(user, false, Convert.ToInt32(Session[Constant.USER_ID]));

                if (registerService.NoOfRowsAffected > 0)
                {
                    httpResponse.StatusCode = HttpStatusCode.OK;
                    httpResponse.SuccessMessage = Constant.USER_UPDATED_SUCCESS_MESSAGE;
                    httpResponse.IsRedirect = true;
                    httpResponse.Action = Constant.LOGIN_ACTION;
                    httpResponse.Controller = Constant.LOGIN_CONTROLLER;

                    Session[Constant.FULL_NAME] = user.FullName;
                    Session[Constant.USER_IMAGE] = string.IsNullOrEmpty(user.UserImage) ? Constant.DEFAULT_USER_IMAGE_FILE_PATH : user.UserImage;
                }
                else
                {
                    httpResponse.StatusCode = HttpStatusCode.InternalServerError;
                    httpResponse.ErrorMessage = string.Concat(Constant.USER_NOT_UPDATED_ERROR_MESSAGE, Constant.STRING_WHITE_SPACE, Constant.CONTACT_CUSTOMER_SUPPORT_MESSAGE);
                }
            }
            catch (SqlException sqlException)
            {
                if (sqlException.Number == 2627)
                {
                    httpResponse.ErrorMessage = Constant.EMAIL_ALREADY_EXISTS_ERROR_MESSAGE;
                }
                else
                {
                    httpResponse.ErrorMessage = sqlException.Message;
                }

                logger.Error(sqlException, UtilFunction.ConcatLogMessage(sqlException.Message));
            }
            catch (Exception exception)
            {
                httpResponse.ErrorMessage = exception.Message;

                logger.Error(exception, UtilFunction.ConcatLogMessage(exception.Message));
            }

            return JsonConvert.SerializeObject(httpResponse);
        }
    }
}