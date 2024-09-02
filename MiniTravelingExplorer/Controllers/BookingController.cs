using System.Web.Mvc;
using MiniTravelingExplorer.Services;
using MiniTravelingExplorer.Utils;
using MiniTravelingExplorer.Models;
using Newtonsoft.Json;
using System.Net;
using System;
using MiniTravelingExplorer.Filters;

namespace MiniTravelingExplorer.Controllers
{
    public class BookingController : BaseService
    {
        readonly BookingService bookingService = new BookingService();

        [JwtAuthenticationFilter]
        [HttpGet]
        public ActionResult List()
        {
            if (!IsLoggedIn)
            {
                return RedirectToAction(Constant.LOGIN_ACTION, Constant.LOGIN_CONTROLLER);
            }

            try
            {
                ViewData[Constant.BOOKING_TABLE] = bookingService.GetBookingList(Convert.ToInt32(Session[Constant.USER_ID]));
            }
            catch (Exception exception)
            {
                logger.Error(exception, UtilFunction.ConcatLogMessage(exception.Message));
            }

            return View();
        }

        [JwtAuthenticationFilter]
        [HttpGet]
        public ActionResult Detail(string bookingId)
        {
            if (!IsLoggedIn || string.IsNullOrEmpty(bookingId))
            {
                return RedirectToAction(Constant.LOGIN_ACTION, Constant.LOGIN_CONTROLLER);
            }

            try
            {
                Booking bookingDetail = bookingService.GetBookingDetail(bookingId, Convert.ToInt32(Session[Constant.USER_ID]));
                if (bookingDetail.BookingId > 0)
                {
                    ViewData[Constant.BOOKING_DETAIL] = bookingDetail;
                }
                else
                {
                    return RedirectToAction(Constant.BOOKING_LIST_ACTION, Constant.BOOKING_CONTROLLER);
                }
            }
            catch (Exception exception)
            {
                logger.Error(exception, UtilFunction.ConcatLogMessage(exception.Message));
            }

            return View();
        }

        [JwtAuthenticationFilter]
        [HttpPost]
        public string ValidatePromoCode(BookingDetail bookingDetail)
        {
            try
            {
                Promotion promotionInformation = bookingService.ApplyAndValidatePromoCode(bookingDetail, Convert.ToInt32(Session[Constant.USER_ID]));

                if (promotionInformation != null && promotionInformation.PromotionValue > 0)
                {
                    httpResponse.StatusCode = HttpStatusCode.OK;
                    httpResponse.SuccessMessage = Constant.VALID_PROMO_CODE_SUCCESS_MESSAGE;
                    httpResponse.ResponseData = promotionInformation;
                }
                else
                {
                    httpResponse.ErrorMessage = Constant.INVALID_PROMO_CODE_ERROR_MESSAGE;
                }
            }
            catch (Exception exception)
            {
                logger.Error(exception, UtilFunction.ConcatLogMessage(exception.Message));
            }

            return JsonConvert.SerializeObject(httpResponse);
        }

        [JwtAuthenticationFilter]
        [HttpPost]
        public string BookMyTicket(BookingDetail bookingDetail)
        {
            try
            {
                bookingService.BookTicket(bookingDetail, Session[Constant.EMAIL].ToString(), Session[Constant.FULL_NAME].ToString(), Convert.ToInt32(Session[Constant.USER_ID]), Server.MapPath(Constant.SERVER_MAP_PATH), out int bookingId, out string amountDisplay);

                if (bookingService.NoOfRowsAffected > 0)
                {
                    httpResponse.StatusCode = HttpStatusCode.OK;
                    httpResponse.SuccessMessage = Constant.BOOK_TICKET_SUCCESS_MESSAGE;
                    httpResponse.ResponseData = new { BookingId = bookingId };
                }
                else if (bookingService.NoOfRowsAffected == -100)
                {
                    httpResponse.ErrorMessage = Constant.INVALID_PROMO_CODE_ERROR_MESSAGE;
                    httpResponse.ResponseData = new { IsInvalidPromoCode = true };
                }
                else
                {
                    httpResponse.ErrorMessage = Constant.BOOK_TICKET_ERROR_MESSAGE;
                }
            }
            catch (Exception exception)
            {
                httpResponse.ErrorMessage = Constant.BOOK_TICKET_ERROR_MESSAGE;

                logger.Error(exception, UtilFunction.ConcatLogMessage(exception.Message));
            }

            return JsonConvert.SerializeObject(httpResponse);
        }
    }
}