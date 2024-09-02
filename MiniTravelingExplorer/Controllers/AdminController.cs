using MiniTravelingExplorer.Filters;
using MiniTravelingExplorer.Models;
using MiniTravelingExplorer.Services;
using MiniTravelingExplorer.Utils;
using Newtonsoft.Json;
using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Web.Mvc;
using SystemIO = System.IO;

namespace MiniTravelingExplorer.Controllers
{
    public class AdminController : BaseService
    {
        readonly AdminService adminService = new AdminService();

        public ActionResult Login()
        {
            if (IsLoggedIn)
            {
                return RedirectToAction(Constant.HOME_ACTION, Constant.HOME_CONTROLLER);
            }
            else if (IsAdminLoggedIn) {
                return RedirectToAction(Constant.HOME_ACTION, Constant.ADMIN_CONTROLLER);
            }

            return View();
        }

        [AdminAuthenticationFilter]
        public ActionResult Home()
        {
            ViewData[Constant.ADMIN_HOME_PAGE_DATA] = GetHomePageData(Session[Constant.ADMIN_USER_FULL_NAME].ToString(), true);

            return View();
        }

        [AdminAuthenticationFilter]
        public ActionResult Users(bool isAdmin)
        {
            try
            {
                ViewData[Constant.USER_TABLE] = adminService.GetUserList(Convert.ToInt32(Session[Constant.ADMIN_USER_ID]), isAdmin);
            }
            catch (Exception exception)
            {
                logger.Error(exception, UtilFunction.ConcatLogMessage(exception.Message));
            }

            return View();
        }

        [AdminAuthenticationFilter]
        public ActionResult UserIpInfo()
        {
            try
            {
                ViewData[Constant.USER_IP_INFO_TABLE] = adminService.GetUserIpInfoList(Convert.ToInt32(Session[Constant.ADMIN_USER_ID]));
            }
            catch (Exception exception)
            {
                logger.Error(exception, UtilFunction.ConcatLogMessage(exception.Message));
            }

            return View();
        }

        [AllowAnonymous]
        public string UserLogin(User user)
        {
            httpResponse.ErrorMessage = Constant.ADMIN_VALIDATION_ERROR_MESSAGE;

            if (IsLoggedIn)
            {
                httpResponse.StatusCode = HttpStatusCode.OK;
                httpResponse.IsRedirect = true;
                httpResponse.Controller = Constant.LOGIN_CONTROLLER;
                httpResponse.Action = Constant.LOGIN_ACTION;
            }
            else if (IsAdminLoggedIn)
            {
                httpResponse.StatusCode = HttpStatusCode.OK;
                httpResponse.IsRedirect = true;
                httpResponse.Controller = Constant.ADMIN_CONTROLLER;
                httpResponse.Action = Constant.LOGIN_ACTION;
            }
            else if (!IsLoggedIn && !IsAdminLoggedIn)
            {
                try
                {
                    User userDetail = adminService.ValidateAdmin(user);
                    if (userDetail != null && userDetail.UserId > 0)
                    {
                        Session[Constant.ADMIN_USER_ID] = userDetail.UserId;
                        Session[Constant.ADMIN_USER_EMAIL] = userDetail.UserId;
                        Session[Constant.ADMIN_USER_FULL_NAME] = userDetail.FullName;
                        Session[Constant.ADMIN_USER_IMAGE] = string.IsNullOrEmpty(userDetail.UserImage) ? Constant.DEFAULT_USER_IMAGE_FILE_PATH : userDetail.UserImage;

                        httpResponse.StatusCode = HttpStatusCode.OK;
                        httpResponse.SuccessMessage = Constant.ADMIN_VALIDATION_SUCCESS_MESSAGE;
                        httpResponse.ResponseData = userDetail;
                    }
                }
                catch (Exception exception)
                {
                    httpResponse.ErrorMessage = exception.Message;

                    logger.Error(exception, UtilFunction.ConcatLogMessage(exception.Message));
                }
            }

            return JsonConvert.SerializeObject(httpResponse);
        }

        [AdminAuthenticationFilter]
        public FileContentResult GetLogFile()
        {
            string logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ConfigurationManager.AppSettings[Constant.LOG_FILE_PATH_KEY]);

            return SystemIO.File.Exists(logFilePath) ? File(SystemIO.File.ReadAllBytes(logFilePath), System.Web.MimeMapping.GetMimeMapping(logFilePath), Path.GetFileName(logFilePath)) : null;
        }

        [AdminAuthenticationFilter]
        [HttpPost]
        public string Logout()
        {
            try
            {
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
                    Controller = Constant.ADMIN_CONTROLLER
                });
        }
    }
}