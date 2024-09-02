using System;
using System.Web;
using System.Web.Mvc;
using MiniTravelingExplorer.Utils;

namespace MiniTravelingExplorer.Filters
{
    public class AdminAuthenticationFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var adminUserId = HttpContext.Current.Session[Constant.ADMIN_USER_ID];

            if(adminUserId == null || Convert.ToInt32(adminUserId) < 1)
            {
                filterContext.Result = new RedirectResult(string.Concat(Constant.SERVER_MAP_PATH, Constant.ADMIN_CONTROLLER, Constant.FORWARD_SLASH, Constant.LOGIN_ACTION));
            }

            base.OnActionExecuting(filterContext);
        }
    }
}