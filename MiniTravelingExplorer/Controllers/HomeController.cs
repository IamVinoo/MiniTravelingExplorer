using Newtonsoft.Json;
using System;
using System.Data.SqlClient;
using System.Net;
using System.Web.Mvc;
using MiniTravelingExplorer.Services;
using MiniTravelingExplorer.Utils;

namespace MiniTravelingExplorer.Controllers
{
    public class HomeController : BaseService
    {
        readonly HomeService homeService = new HomeService();

        public ActionResult Home()
        {
            try
            {
                ViewData[Constant.HOME_PAGE_DATA] = GetHomePageData(Session[Constant.FULL_NAME]?.ToString());
            }
            catch (Exception exception)
            {
                logger.Error(exception, UtilFunction.ConcatLogMessage(exception.Message));
            }

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            try
            {
                ViewData[Constant.CONTACT_PAGE_DATA] = homeService.GetContactPageData();
            }
            catch (Exception exception)
            {
                logger.Error(exception, UtilFunction.ConcatLogMessage(exception.Message));
            }

            return View();
        }

        [HttpGet]
        public string EmailSubscription(string email)
        {
            try
            {
                if (!string.IsNullOrEmpty(email))
                {
                    homeService.InsertUpdateSubscriber(email, false, Server.MapPath(Constant.SERVER_MAP_PATH), out bool isAlreadySubscribed);

                    if (homeService.NoOfRowsAffected > 0)
                    {
                        httpResponse.StatusCode = HttpStatusCode.OK;
                        httpResponse.SuccessMessage = Constant.USER_SUBSCRIBE_SUCCESS_MESSAGE;
                    }
                    else if (isAlreadySubscribed)
                    {
                        httpResponse.ErrorMessage = Constant.EMAIL_SUBSCRIBER_ALREADY_EXISTS_ERROR_MESSAGE;
                    }
                    else
                    {
                        httpResponse.ErrorMessage = Constant.USER_SUBSCRIBE_ERROR_MESSAGE;
                    }
                }
            }
            catch (SqlException sqlException)
            {
                if (sqlException.Number == 2627)
                {
                    httpResponse.ErrorMessage = Constant.EMAIL_SUBSCRIBER_ALREADY_EXISTS_ERROR_MESSAGE;
                }
                else
                {
                    httpResponse.ErrorMessage = string.Concat(Constant.ERROR_OCCURRED_ERROR_MESSAGE, Constant.STRING_WHITE_SPACE, Constant.CONTACT_CUSTOMER_SUPPORT_MESSAGE);
                }

                logger.Error(sqlException, UtilFunction.ConcatLogMessage(sqlException.Message));
            }
            catch (Exception exception)
            {
                logger.Error(exception, UtilFunction.ConcatLogMessage(exception.Message));
            }

            return JsonConvert.SerializeObject(httpResponse);
        }

        [HttpGet]
        public ActionResult Unsubscribe(string email)
        {
            try
            {
                homeService.InsertUpdateSubscriber(email, true, Server.MapPath(Constant.SERVER_MAP_PATH), out bool isAlreadySubscribed);
            }
            catch (Exception exception)
            {
                logger.Error(exception, UtilFunction.ConcatLogMessage(exception.Message));
            }

            return View();
        }
    }
}