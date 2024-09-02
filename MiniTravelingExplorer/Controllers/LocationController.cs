using System.Web.Mvc;
using MiniTravelingExplorer.Services;
using MiniTravelingExplorer.Utils;
using MiniTravelingExplorer.Models;
using System;

namespace MiniTravelingExplorer.Controllers
{
    public class LocationController : BaseService
    {
        readonly LocationService locationService = new LocationService();

        [HttpGet]
        public ActionResult List(string searchString, string activitySearchString, string weatherSearchString, string minRate, string maxRate, string minTemperature, string maxTemperature)
        {
            try
            {
                ViewData[Constant.LOCATION_DATA] = locationService.GetLocationData(searchString, activitySearchString, weatherSearchString, minRate, maxRate, minTemperature, maxTemperature);
            }
            catch (Exception exception)
            {
                logger.Error(exception, UtilFunction.ConcatLogMessage(exception.Message));
            }
            return View();
        }

        [HttpGet]
        public ActionResult Detail(string locationId)
        {
            if (string.IsNullOrWhiteSpace(locationId))
            {
                return ReturnToLocationListPage();
            }

            try
            {
                Location locationDetail = locationService.GetLocationDetail(locationId);
                if (locationDetail.LocationId > 0)
                {
                    if (IsLoggedIn)
                    {
                        ViewData[Constant.USER_LOGIN_EMAIL] = Session[Constant.EMAIL].ToString();
                    }

                    ViewData[Constant.LOCATION_DETAIL] = locationDetail;
                }
                else
                {
                    return ReturnToLocationListPage();
                }
            }
            catch (Exception exception)
            {
                logger.Error(exception, UtilFunction.ConcatLogMessage(exception.Message));
                return ReturnToLocationListPage();
            }

            return View();
        }

        private ActionResult ReturnToLocationListPage()
        {
            return RedirectToAction(Constant.LIST_ACTION, Constant.LOCATION_CONTROLLER);
        }
    }
}