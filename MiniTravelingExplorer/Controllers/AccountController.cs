using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Net;
using System.Web.Mvc;
using MiniTravelingExplorer.Exceptions;
using MiniTravelingExplorer.Filters;
using MiniTravelingExplorer.Models;
using MiniTravelingExplorer.Services;
using MiniTravelingExplorer.Utils;
using SystemWeb = System.Web;

namespace MiniTravelingExplorer.Controllers
{
    public class AccountController : BaseService
    {
        readonly AccountService accountService = new AccountService();

        [JwtAuthenticationFilter]
        [HttpGet]
        public ActionResult UserProfile()
        {
            if (!IsLoggedIn)
            {
                return RedirectToAction(Constant.HOME_ACTION, Constant.HOME_CONTROLLER);
            }

            try
            {
                ViewData[Constant.USER_TABLE] = accountService.GetUserDetail(Session[Constant.EMAIL].ToString(), Convert.ToInt32(Session[Constant.USER_ID]));
                ViewData[Constant.SECURITY_QUESTION_TABLE] = GetSecurityQuestion();
            }
            catch (Exception exception)
            {
                logger.Error(exception, UtilFunction.ConcatLogMessage(exception.Message));
            }

            return View();
        }

        [JwtAuthenticationFilter]
        public ActionResult ChangeEmail()
        {
            if (!IsLoggedIn)
            {
                return RedirectToAction(Constant.HOME_ACTION, Constant.HOME_CONTROLLER);
            }

            return View();
        }

        [JwtAuthenticationFilter]
        public ActionResult ChangePassword()
        {
            if (!IsLoggedIn)
            {
                return RedirectToAction(Constant.HOME_ACTION, Constant.HOME_CONTROLLER);
            }

            return View();
        }

        [JwtAuthenticationFilter]
        public ActionResult MyChecklist()
        {
            if (!IsLoggedIn)
            {
                return RedirectToAction(Constant.HOME_ACTION, Constant.HOME_CONTROLLER);
            }

            try
            {
                ViewData[Constant.CHECKLIST_DATA] = accountService.GetMyChecklistData(Convert.ToInt32(Session[Constant.USER_ID]));
            }
            catch (Exception exception)
            {
                logger.Error(exception, UtilFunction.ConcatLogMessage(exception.Message));
            }

            return View();
        }

        [JwtAuthenticationFilter]
        public ActionResult MyChecklistItem(int? checklistId, int? bookingId)   
        {
            if (!IsLoggedIn)
            {
                return RedirectToAction(Constant.HOME_ACTION, Constant.HOME_CONTROLLER);
            }

            try
            {
                ViewData[Constant.CHECKLIST_ITEM_TABLE] = GetChecklistItem(checklistId, bookingId, Convert.ToInt32(Session[Constant.USER_ID]));
            }
            catch (Exception exception)
            {
                logger.Error(exception, UtilFunction.ConcatLogMessage(exception.Message));
            }

            return View();
        }

        [JwtAuthenticationFilter]
        [HttpGet]
        public string InsertMyChecklist(string checklistName, int? bookingId)
        {
            try
            {
                if (accountService.InsertChecklist(checklistName, Convert.ToInt32(Session[Constant.USER_ID]), bookingId))
                {
                    httpResponse.ErrorMessage = Constant.CHECKLIST_NAME_ALREADY_EXISTS_ERROR_MESSAGE;
                }
                else
                {
                    if (accountService.NoOfRowsAffected > 0)
                    {
                        httpResponse.StatusCode = HttpStatusCode.OK;
                        httpResponse.SuccessMessage = Constant.INSERT_CHECKLIST_SUCCESS_MESSAGE;
                    }
                    else
                    {
                        httpResponse.ErrorMessage = Constant.INSERT_CHECKLIST_ERROR_MESSAGE;
                    }
                }
            }
            catch (Exception exception)
            {
                httpResponse.ErrorMessage = Constant.INSERT_CHECKLIST_ERROR_MESSAGE;

                logger.Error(exception, UtilFunction.ConcatLogMessage(exception.Message));
            }

            return JsonConvert.SerializeObject(httpResponse);
        }

        [JwtAuthenticationFilter]
        [HttpGet]
        public string DeleteMyChecklist(int checklistId, int bookingId)
        {
            try
            {
                accountService.DeleteChecklist(checklistId, Convert.ToInt32(Session[Constant.USER_ID]), bookingId);

                if (accountService.NoOfRowsAffected > 0)
                {
                    httpResponse.StatusCode = HttpStatusCode.OK;
                    httpResponse.SuccessMessage = Constant.DELETE_CHECKLIST_SUCCESS_MESSAGE;
                }
                else
                {
                    httpResponse.ErrorMessage = Constant.DELETE_CHECKLIST_ERROR_MESSAGE;
                }
            }
            catch (Exception exception)
            {
                httpResponse.ErrorMessage = Constant.DELETE_CHECKLIST_ERROR_MESSAGE;

                logger.Error(exception, UtilFunction.ConcatLogMessage(exception.Message));
            }

            return JsonConvert.SerializeObject(httpResponse);
        }

        [JwtAuthenticationFilter]
        [HttpPost]
        public string InsertUpdateMyChecklistItem(AddChecklistItem addChecklistItem)
        {
            bool isAdd = (addChecklistItem != null && addChecklistItem.ChecklistItemId == 0);
            string errorMessage;
            string successMessage;
            string createText = Constant.CREATE_STRING.ToLower();
            string updateText = Constant.UPDATE_STRING.ToLower();

            if (isAdd)
            {
                successMessage = Constant.INSERT_CHECKLIST_ITEM_SUCCESS_MESSAGE;
                errorMessage = string.Format(Constant.CHECKLIST_ITEM_ERROR_MESSAGE, createText);
            }
            else
            {
                successMessage = Constant.UPDATE_CHECKLIST_ITEM_SUCCESS_MESSAGE;
                errorMessage = string.Format(Constant.CHECKLIST_ITEM_ERROR_MESSAGE, updateText);
            }

            try
            {
                int createdChecklistItemId = accountService.InsertUpdateChecklistItem(addChecklistItem, Convert.ToInt32(Session[Constant.USER_ID]), isAdd, createText, updateText);

                MyChecklistItem myChecklistItem = new MyChecklistItem();

                if (accountService.NoOfRowsAffected > 0)
                {
                    httpResponse.StatusCode = HttpStatusCode.OK;
                    httpResponse.SuccessMessage = successMessage;

                    if (isAdd)
                    {
                        myChecklistItem.ChecklistItemId = createdChecklistItemId;
                        myChecklistItem.Name = addChecklistItem.ChecklistItemName;
                        httpResponse.ResponseData = myChecklistItem;
                    }
                }
                else
                {
                    httpResponse.ErrorMessage = errorMessage;
                }

                if (!isAdd)
                {
                    myChecklistItem.ChecklistItemId = addChecklistItem.ChecklistItemId;
                    httpResponse.ResponseData = myChecklistItem;
                }
            }
            catch (CustomException customException)
            {
                httpResponse.ErrorMessage = customException.Message;

                logger.Error(customException, UtilFunction.ConcatLogMessage(customException.Message));
            }
            catch (Exception exception)
            {
                httpResponse.ErrorMessage = errorMessage;

                logger.Error(exception, UtilFunction.ConcatLogMessage(exception.Message));
            }

            return JsonConvert.SerializeObject(httpResponse);
        }

        [JwtAuthenticationFilter]
        public string DeleteMyChecklistItem(int checklistItemId, int checklistId, int bookingId)
        {
            try
            {
                accountService.DeleteChecklistItem(checklistItemId, Convert.ToInt32(Session[Constant.USER_ID]), checklistId, bookingId);

                if (accountService.NoOfRowsAffected > 0)
                {
                    httpResponse.StatusCode = HttpStatusCode.OK;
                    httpResponse.SuccessMessage = Constant.DELETE_CHECKLIST_ITEM_SUCCESS_MESSAGE;
                    httpResponse.ResponseData = new { checklistItemId };
                }
                else
                {
                    httpResponse.ErrorMessage = Constant.DELETE_CHECKLIST_ITEM_ERROR_MESSAGE;
                }
            }
            catch (Exception exception)
            {
                httpResponse.ErrorMessage = Constant.DELETE_CHECKLIST_ITEM_ERROR_MESSAGE;

                logger.Error(exception, UtilFunction.ConcatLogMessage(exception.Message));
            }

            return JsonConvert.SerializeObject(httpResponse);
        }

        [JwtAuthenticationFilter]
        [HttpPost]
        public string GetChecklistShareData(Checklist checklist)
        {
            if (checklist != null)
            {
                ChecklistShareResponseData checklistShareResponseData = new ChecklistShareResponseData();

                try
                {
                    checklistShareResponseData = accountService.GetChecklistShareData(checklist, Convert.ToInt32(Session[Constant.USER_ID]), Session[Constant.FULL_NAME].ToString(), Server.MapPath(Constant.SERVER_MAP_PATH));
                    
                    if (checklistShareResponseData != null)
                    {
                        httpResponse.StatusCode = HttpStatusCode.OK;
                        httpResponse.SuccessMessage = checklistShareResponseData.HttpResponse.SuccessMessage;
                        httpResponse.ResponseData = checklistShareResponseData;
                    }
                    else if (!string.IsNullOrEmpty(checklistShareResponseData.HttpResponse.ErrorMessage))
                    {
                        httpResponse.ErrorMessage = checklistShareResponseData.HttpResponse.ErrorMessage;
                    }
                }
                catch (Exception exception)
                {
                    httpResponse.ErrorMessage = checklistShareResponseData.HttpResponse.ErrorMessage;

                    logger.Error(exception, UtilFunction.ConcatLogMessage(exception.Message));
                }
            }
            else
            {
                httpResponse.ErrorMessage = Constant.CHECKLIST_SHARE_ERROR_MESSAGE;
            }

            return JsonConvert.SerializeObject(httpResponse);
        }

        [JwtAuthenticationFilter]
        [HttpGet]
        public string SendEmailVerificationCode(User user)
        {
            try
            {
                if (string.Compare(user.ChangeEmailRequested.ToLower(), Session[Constant.EMAIL].ToString().ToLower()) == 0)
                {
                    httpResponse.ErrorMessage = Constant.USER_EMAIL_UPDATE_INVALID_ERROR_MESSAGE;
                }
                else
                {
                    user.Email = Session[Constant.EMAIL].ToString();
                    accountService.UpdateUserEmail(user, false, Convert.ToInt32(Session[Constant.USER_ID]), Session[Constant.FULL_NAME].ToString(), Server.MapPath(Constant.SERVER_MAP_PATH));

                    if (accountService.NoOfRowsAffected > 0)
                    {
                        httpResponse.StatusCode = HttpStatusCode.OK;
                        httpResponse.SuccessMessage = Constant.USER_EMAIL_CODE_SEND_SUCCESS_MESSAGE;
                    }
                    else
                    {
                        httpResponse.ErrorMessage = Constant.USER_EMAIL_CODE_SEND_ERROR_MESSAGE;
                    }
                }
            }
            catch (Exception exception)
            {
                httpResponse.ErrorMessage = Constant.USER_EMAIL_CODE_SEND_ERROR_MESSAGE;

                logger.Error(exception, UtilFunction.ConcatLogMessage(exception.Message));
            }

            return JsonConvert.SerializeObject(httpResponse);
        }

        [JwtAuthenticationFilter]
        [HttpGet]
        public string ChangeUserEmail(User user)
        {
            try
            {
                if (string.Compare(user.ChangeEmailRequested.ToLower(), Session[Constant.EMAIL].ToString().ToLower()) == 0)
                {
                    httpResponse.ErrorMessage = Constant.USER_EMAIL_UPDATE_INVALID_ERROR_MESSAGE;
                }
                else
                {
                    user.Email = Session[Constant.EMAIL].ToString();
                    accountService.UpdateUserEmail(user, true, Convert.ToInt32(Session[Constant.USER_ID]), Session[Constant.FULL_NAME].ToString(), Server.MapPath(Constant.SERVER_MAP_PATH));

                    if (accountService.NoOfRowsAffected > 0)
                    {
                        Session[Constant.EMAIL] = user.ChangeEmailRequested;
                        httpResponse.IsRedirect = true;
                        httpResponse.Action = Constant.HOME_ACTION;
                        httpResponse.Controller = Constant.HOME_CONTROLLER;
                        httpResponse.StatusCode = HttpStatusCode.OK;
                        httpResponse.SuccessMessage = Constant.USER_EMAIL_UPDATE_SUCCESS_MESSAGE;
                    }
                    else
                    {
                        httpResponse.ErrorMessage = Constant.USER_EMAIL_UPDATE_ERROR_MESSAGE;
                    }
                }
            }
            catch (Exception exception)
            {
                httpResponse.ErrorMessage = Constant.USER_EMAIL_UPDATE_ERROR_MESSAGE;

                logger.Error(exception, UtilFunction.ConcatLogMessage(exception.Message));
            }

            return JsonConvert.SerializeObject(httpResponse);
        }

        [JwtAuthenticationFilter]
        [HttpGet]
        public string ChangeUserPassword(User user)
        {
            try
            {
                accountService.UpdateUserPassword(user, Convert.ToInt32(Session[Constant.USER_ID]), Session[Constant.EMAIL].ToString(), Session[Constant.FULL_NAME].ToString(), Server.MapPath(Constant.SERVER_MAP_PATH));

                if (accountService.NoOfRowsAffected == -1)
                {
                    httpResponse.ErrorMessage = Constant.USER_CURRENT_PASSWORD_INVALID_ERROR_MESSAGE;
                }
                else if (accountService.NoOfRowsAffected > 0)
                {
                    Logout();
                    httpResponse.IsRedirect = true;
                    httpResponse.Action = Constant.LOGIN_ACTION;
                    httpResponse.Controller = Constant.LOGIN_CONTROLLER;
                    httpResponse.StatusCode = HttpStatusCode.OK;
                    httpResponse.SuccessMessage = Constant.USER_PASSWORD_UPDATE_SUCCESS_MESSAGE;
                }
                else
                {
                    httpResponse.ErrorMessage = Constant.USER_PASSWORD_UPDATE_ERROR_MESSAGE;
                }
            }
            catch (Exception exception)
            {
                httpResponse.ErrorMessage = Constant.USER_PASSWORD_UPDATE_ERROR_MESSAGE;

                logger.Error(exception, UtilFunction.ConcatLogMessage(exception.Message));
            }

            return JsonConvert.SerializeObject(httpResponse);
        }

        [JwtAuthenticationFilter]
        [HttpGet]
        public string KeepSessionAlive()
        {
            httpResponse.ErrorMessage = Constant.UNATUHORIZED_ERROR_MESSAGE;

            if (Session != null)
            {
                httpResponse.StatusCode = HttpStatusCode.OK;
                httpResponse.ErrorMessage = string.Empty;
                httpResponse.SuccessMessage = Constant.SESSION_ALIVE_SUCCESS_MESSAGE;
            }

            return JsonConvert.SerializeObject(httpResponse);
        }

        [JwtAuthenticationFilter]
        [HttpPost]
        public string Logout()
        {
            try
            {
                SystemWeb.HttpCookie httpCookie = SystemWeb.HttpContext.Current.Request.Cookies[Constant.JWT_TOKEN];

                if (httpCookie != null)
                {
                    httpCookie.Expires = DateTime.UtcNow.AddMinutes(Convert.ToDouble(ConfigurationManager.AppSettings[Constant.COOKIE_LOGOUT_EXPIRATION_TIME_KEY]));
                    Response.Cookies.Add(httpCookie);
                }

                Session.Clear();
            }
            catch (Exception exception)
            {
                logger.Error(exception, UtilFunction.ConcatLogMessage(exception.Message));
            }

            return JsonConvert.SerializeObject(
                new HttpResponse
                {
                    StatusCode = HttpStatusCode.OK,
                    SuccessMessage = Constant.LOGOUT_SUCCESS_MESSAGE,
                    IsRedirect = true,
                    Action = Constant.LOGIN_ACTION,
                    Controller = Constant.LOGIN_CONTROLLER
                });
        }
    }
}