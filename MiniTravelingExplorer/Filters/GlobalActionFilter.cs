using System;
using System.Web;
using System.Web.Mvc;
using MiniTravelingExplorer.Models;
using MiniTravelingExplorer.Utils;

namespace MiniTravelingExplorer.Filters
{
    public class GlobalActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            string clearSessionPath = string.Concat(Constant.SERVER_MAP_PATH, Constant.LOGIN_CONTROLLER, Constant.FORWARD_SLASH, Constant.CLEAR_SESSION_ACTION);

            HttpContextBase context = filterContext.HttpContext;
            HttpCookie httpCookie = context.Request.Cookies[Constant.JWT_TOKEN];

            string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            string actionName = filterContext.ActionDescriptor.ActionName;

            if (httpCookie != null && string.Compare(controllerName, Constant.LOGIN_CONTROLLER) != 0 && string.Compare(actionName, Constant.USER_LOGIN_ACTION) != 0 && string.Compare(controllerName, Constant.ACCOUNT_CONTROLLER) != 0 && string.Compare(actionName, Constant.KEEP_SESSION_ACTION) != 0)
            {
                string token = httpCookie.Value;
                if (!string.IsNullOrEmpty(token))
                {
                    User user = Authentication.ValidateToken(token);
                    bool isValidUser = (user != null && !string.IsNullOrWhiteSpace(user.Email));

                    if (isValidUser)
                    {
                        if(user.ExpiryDate > DateTime.UtcNow)
                        {
                            httpCookie.Value = Authentication.GenerateJwtAuthentication(user.Email, user.FullName);
                            context.Response.Cookies.Set(httpCookie);
                        }
                        else
                        {
                            filterContext.HttpContext.Request.Cookies.Remove(Constant.JWT_TOKEN);
                            filterContext.Result = new RedirectResult(clearSessionPath);
                        }
                    }

                    var userId = HttpContext.Current.Session[Constant.USER_ID];
                    if (userId != null && !isValidUser)
                    {
                        filterContext.HttpContext.Request.Cookies.Remove(Constant.JWT_TOKEN);
                        filterContext.Result = new RedirectResult(clearSessionPath);
                    }
                }
            }

            base.OnActionExecuted(filterContext);
        }
    }
}