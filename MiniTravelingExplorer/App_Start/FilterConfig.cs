using System.Web.Mvc;
using MiniTravelingExplorer.Filters;

namespace MiniTravelingExplorer
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new RenewAuthenticationCookieAttribute());
            filters.Add(new GlobalActionFilter());
        }
    }
}