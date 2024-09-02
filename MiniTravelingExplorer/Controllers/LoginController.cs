using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using MiniTravelingExplorer.Filters;
using MiniTravelingExplorer.Models;
using MiniTravelingExplorer.Services;
using MiniTravelingExplorer.Utils;
using Web = System.Web;

namespace MiniTravelingExplorer.Controllers
{
    public class LoginController : BaseService
    {
        readonly LoginService loginService = new LoginService();

        [AllowAnonymous]
        public ActionResult Login()
        {
            if (IsLoggedIn)
            {
                return RedirectToAction(Constant.HOME_ACTION, Constant.HOME_CONTROLLER);
            }
            else if (IsAdminLoggedIn)
            {
                return RedirectToAction(Constant.LOGIN_ACTION, Constant.ADMIN_CONTROLLER);
            }

            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult UserActivation(string activationData)
        {
            try
            {
                ViewBag.FullName = loginService.UpdateUserLogin(null, activationData, true);
            }
            catch (Exception exception)
            {
                logger.Error(exception, UtilFunction.ConcatLogMessage(exception.Message));
            }

            return View();
        }

        [AllowAnonymous]
        public ActionResult ResetPassword()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public string UserLogin(User user, string returnUrl)
        {
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
                User responseUser = new User();

                if (Session[Constant.USER_ID] != null)
                {
                    httpResponse.StatusCode = HttpStatusCode.OK;
                    httpResponse.IsRedirect = true;
                    httpResponse.Action = Constant.HOME_ACTION;
                    httpResponse.Controller = Constant.HOME_CONTROLLER;
                }
                else if (user != null)
                {
                    try
                    {
                        responseUser = loginService.LoginUser(new User()
                        {
                            Email = user.Email,
                            Password = user.Password,
                            NoOfAttempt = 0
                        }, returnUrl);

                        if (responseUser != null && responseUser.HttpResponse.StatusCode == HttpStatusCode.OK)
                        {
                            Response.Cookies.Add(new Web.HttpCookie(Constant.JWT_TOKEN)
                            {
                                Value = Authentication.GenerateJwtAuthentication(responseUser.Email, responseUser.FullName),
                            });

                            Session[Constant.USER_ID] = responseUser.UserId;
                            Session[Constant.EMAIL] = responseUser.Email;
                            Session[Constant.FULL_NAME] = responseUser.FullName;
                            Session[Constant.SALT_KEY] = responseUser.SaltKey;
                            Session[Constant.USER_IMAGE] = string.IsNullOrEmpty(responseUser.UserImage) ? Constant.DEFAULT_USER_IMAGE_FILE_PATH : responseUser.UserImage;
                        }

                        httpResponse = responseUser.HttpResponse;
                    }
                    catch (Exception exception)
                    {
                        responseUser.HttpResponse.StatusCode = HttpStatusCode.BadRequest;
                        responseUser.HttpResponse.ErrorMessage = exception.Message;

                        logger.Error(exception, UtilFunction.ConcatLogMessage(exception.Message));
                    }
                }
            }

            return JsonConvert.SerializeObject(httpResponse);
        }

        [AllowAnonymous]
        [HttpPost]
        public string SendPasswordResetLink(User user)
        {
            try
            {
                GoogleRecaptchaResponse googleRecaptchaResponse = UtilFunction.ValidateGoogleRecaptchaResponse(user.GoogleRecaptchaResponse);
                if (googleRecaptchaResponse != null && googleRecaptchaResponse.Success)
                {
                    loginService.UpdateUserLogin(user, string.Empty, false, string.Empty, true, Server.MapPath(Constant.SERVER_MAP_PATH));
                    httpResponse.StatusCode = HttpStatusCode.OK;
                    httpResponse.SuccessMessage = Constant.RESET_PASSWORD_EMAIL_SENT_SUCCESS_MESSAGE;
                    httpResponse.IsRedirect = true;
                    httpResponse.Action = Constant.LOGIN_ACTION;
                    httpResponse.Controller = Constant.LOGIN_CONTROLLER;
                }
                else if (googleRecaptchaResponse.ErrorCodes.Any())
                {
                    httpResponse.ErrorMessage = googleRecaptchaResponse.ErrorCodes.FirstOrDefault();
                }
            }
            catch (Exception exception)
            {
                logger.Error(exception, UtilFunction.ConcatLogMessage(exception.Message));
            }

            return JsonConvert.SerializeObject(httpResponse);
        }

        [AllowAnonymous]
        [HttpGet]
        public string UserPasswordReset(string resetPasswordData, string password)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(loginService.UpdateUserLogin(null, resetPasswordData, false, password)))
                {
                    httpResponse.IsRedirect = true;
                    httpResponse.Action = Constant.LOGIN_ACTION;
                    httpResponse.Controller = Constant.LOGIN_CONTROLLER;
                    httpResponse.StatusCode = HttpStatusCode.OK;
                    httpResponse.SuccessMessage = Constant.RESET_PASSWORD_SUCCESS_MESSAGE;
                }
                else
                {
                    httpResponse.ErrorMessage = Constant.RESET_PASSWORD_INVALID_TOKEN_MESSAGE;

                }
            }
            catch (Exception exception)
            {
                httpResponse.ErrorMessage = string.Concat(Constant.RESET_PASSWORD_ERROR_MESSAGE, Constant.STRING_WHITE_SPACE, Constant.CONTACT_CUSTOMER_SUPPORT_MESSAGE);

                logger.Error(exception, UtilFunction.ConcatLogMessage(exception.Message));
            }

            return JsonConvert.SerializeObject(httpResponse);
        }
        public ActionResult ClearSession()
        {
            Session.Clear();
            return RedirectToAction(Constant.LOGIN_ACTION, Constant.LOGIN_CONTROLLER);
        }
    }
}