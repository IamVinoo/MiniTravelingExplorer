using System;
using System.Configuration;
using System.Web;
using System.Web.Mvc;
using MiniTravelingExplorer.Models;
using MiniTravelingExplorer.Utils;

namespace MiniTravelingExplorer.Filters
{
    public class RenewAuthenticationCookieAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpCookieCollection httpCookieCollection = filterContext.HttpContext.Request.Cookies;

            if (httpCookieCollection.Count > 0)
            {
                HttpCookie httpCookie = HttpContext.Current.Request.Cookies[Constant.JWT_TOKEN];
                if (httpCookie != null && httpCookie.Expires <= DateTime.UtcNow)
                {
                    User user = Authentication.ValidateToken(httpCookie.Value);
                    if (user != null && !string.IsNullOrWhiteSpace(user.Email))
                    {
                        httpCookie.Expires = DateTime.UtcNow.AddMinutes(Convert.ToDouble(ConfigurationManager.AppSettings[Constant.COOKIE_EXPIRATION_TIME_KEY]));
                        HttpContext.Current.Response.Cookies.Set(httpCookie);
                    }
                }
            }

            base.OnActionExecuting(filterContext);
        }
    }
}