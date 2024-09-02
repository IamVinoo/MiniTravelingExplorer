using System;
using System.Web;
using System.Web.Mvc;
using MiniTravelingExplorer.Models;
using MiniTravelingExplorer.Utils;

namespace MiniTravelingExplorer.Filters
{
    public class JwtAuthenticationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string clearSessionPath = string.Concat(Constant.SERVER_MAP_PATH, Constant.LOGIN_CONTROLLER, Constant.FORWARD_SLASH, Constant.CLEAR_SESSION_ACTION);

            HttpContextBase context = filterContext.HttpContext;
            HttpCookie httpCookie = context.Request.Cookies[Constant.JWT_TOKEN];

            if (httpCookie != null)
            {
                string token = httpCookie.Value;

                if (!string.IsNullOrEmpty(token))
                {
                    User user = Authentication.ValidateToken(token);

                    if (user == null || string.IsNullOrWhiteSpace(user.Email) || user.ExpiryDate < DateTime.UtcNow)
                    {
                        filterContext.Result = new RedirectResult(clearSessionPath);
                    }
                }
                else
                {
                    filterContext.Result = new RedirectResult(clearSessionPath);
                }
            }

            base.OnActionExecuting(filterContext);
        }
    }
}