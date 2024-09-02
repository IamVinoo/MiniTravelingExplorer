using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using MiniTravelingExplorer.Utils;
using MiniTravelingExplorer.Models;
using EntityModel = MiniTravelingExplorer.EntityModel;
using System.Configuration;
using System.IO;
using System.Net.Mail;
using MiniTravelingExplorer.Models.Configuration;

namespace MiniTravelingExplorer.Services
{
    public class BookingService : BaseService
    {
        public List<Booking> GetBookingList(int userId)
        {
            List<Booking> bookingList = new List<Booking>();

            using (SqlDataAdapter dataAdapter = new SqlDataAdapter())
            {
                dataAdapter.SelectCommand = new SqlCommand(Constant.GET_BOOKING_LIST_SP, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                dataAdapter.SelectCommand.Parameters.AddWithValue("@UserId", userId);

                DataSet dataSet = new DataSet();

                if (dataSet != null)
                {
                    dataAdapter.Fill(dataSet, Constant.BOOKING_TABLE);
                    DataTable dataTable = dataSet.Tables[Constant.BOOKING_TABLE];
                    List<EntityModel.Booking> entityBookingList = UtilFunction.DataTableToList<EntityModel.Booking>(dataTable);
                    Mapper mapper = AutoMapperConfiguration.InitializeAutomapper();
                    bookingList = mapper.Map<List<EntityModel.Booking>, List<Booking>>(entityBookingList);
                }
            }

            return bookingList;
        }

        public Booking GetBookingDetail(string bookingId, int userId)
        {
            Booking booking = new Booking();

            using (SqlDataAdapter dataAdapter = new SqlDataAdapter())
            {
                dataAdapter.SelectCommand = new SqlCommand(Constant.GET_BOOKING_DETAIL_SP, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                dataAdapter.SelectCommand.Parameters.AddWithValue("@BookingId", bookingId);
                dataAdapter.SelectCommand.Parameters.AddWithValue("@UserId", userId);

                DataSet dataSet = new DataSet();

                if (dataSet != null)
                {
                    dataAdapter.Fill(dataSet, Constant.BOOKING_TABLE);
                    DataTable dataTable = dataSet.Tables[Constant.BOOKING_TABLE];
                    EntityModel.Booking entityBooking = UtilFunction.DataTableToObject<EntityModel.Booking>(dataTable);
                    Mapper mapper = AutoMapperConfiguration.InitializeAutomapper();
                    booking = mapper.Map<EntityModel.Booking, Booking>(entityBooking);
                }
            }

            return booking;
        }

        public void BookTicket(BookingDetail bookingDetail, string email, string fullName, int userId, string serverMapPath, out int bookingId, out string amountDisplay)
        {
            if (bookingDetail.IsUserLoginEmail)
            {
                bookingDetail.Email = email;
                bookingDetail.Username = fullName;
            }
            else
            {
                bookingDetail.Username = bookingDetail.Email;
            }

            bookingDetail.TicketNumber = UtilFunction.GenerateTicketNumber();

            SqlCommand sqlCommand = new SqlCommand(Constant.BOOK_TICKET_SP, connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            sqlCommand.Parameters.Add("@LocationId", SqlDbType.Int).Value = bookingDetail.LocationId;
            sqlCommand.Parameters.Add("@UserId", SqlDbType.Int).Value = userId;
            sqlCommand.Parameters.Add("@BookingEmail", SqlDbType.NVarChar, 100).Value = bookingDetail.Email;
            sqlCommand.Parameters.Add("@TicketNumber", SqlDbType.NVarChar, 100).Value = bookingDetail.TicketNumber;
            sqlCommand.Parameters.Add("@NumberOfTicket", SqlDbType.Int).Value = bookingDetail.NumberOfTicket;
            sqlCommand.Parameters.Add("@CardNumber", SqlDbType.NVarChar, 20).Value = UtilFunction.FormatCardNumber(bookingDetail.CardNumber);
            sqlCommand.Parameters.Add("@CardName", SqlDbType.NVarChar, 50).Value = bookingDetail.CardName;
            sqlCommand.Parameters.Add("@TripDate", SqlDbType.DateTime).Value = bookingDetail.TripDate;
            sqlCommand.Parameters.Add("@PromoCode", SqlDbType.NVarChar, 10).Value = bookingDetail.PromoCode;

            SqlParameter sqlBookingIdParameter = sqlCommand.Parameters.Add("@BookingId", SqlDbType.Int);
            sqlBookingIdParameter.Direction = ParameterDirection.Output;

            SqlParameter sqlAmountDisplayParameter = sqlCommand.Parameters.Add("@AmountDisplay", SqlDbType.NVarChar, 100);
            sqlAmountDisplayParameter.Direction = ParameterDirection.Output;

            SqlParameter sqlisIsValidPromoCodeParameter = sqlCommand.Parameters.Add("@IsValidPromoCode", SqlDbType.Bit);
            sqlisIsValidPromoCodeParameter.Direction = ParameterDirection.Output;

            using (connection)
            {
                connection.Open();
                NoOfRowsAffected = sqlCommand.ExecuteNonQuery();
            }

            bookingId = 0;
            amountDisplay = string.Empty;

            if (sqlBookingIdParameter.Value != DBNull.Value)
            {
                bookingId = Convert.ToInt32(sqlBookingIdParameter.Value);
            }

            if (sqlAmountDisplayParameter.Value != DBNull.Value)
            {
                amountDisplay = sqlAmountDisplayParameter.Value.ToString();
            }

            if (sqlisIsValidPromoCodeParameter.Value != DBNull.Value && !Convert.ToBoolean(sqlisIsValidPromoCodeParameter.Value))
            {
                NoOfRowsAffected = -100;
            }

            if (NoOfRowsAffected > 0)
            {
                DateTime currentDateTime = DateTime.UtcNow;
                double tripReminderFromDays = Convert.ToDouble(ConfigurationManager.AppSettings[Constant.TRIP_REMINDER_FROM_DAYS_KEY]);
                DateTime defaultScheduledTime = currentDateTime.AddHours(1);
                DateTime scheduledTime = bookingDetail.TripDate.AddDays(tripReminderFromDays);

                if ((scheduledTime - currentDateTime).TotalDays < -tripReminderFromDays)
                {
                    scheduledTime = defaultScheduledTime;
                }

                string checklistUrl = string.Concat(ConfigurationManager.AppSettings[Constant.BASE_URL_KEY], Constant.CHECKLIST_LIST_LINK);
                string bookingDetailUrl = string.Concat(ConfigurationManager.AppSettings[Constant.BASE_URL_KEY], Constant.BOOKING_DETAIL_LINK, bookingId);
                string tripDateDisplay = bookingDetail.TripDate.ToString(Constant.DATETIME_EMAIL_FORMAT);

                string tripReminderEmailBody = UtilFunction.GetFileData(Path.Combine(serverMapPath, Constant.TEMPLATE_PATH, Constant.EMAIL_TEMPLATE_FOLDER, Constant.TRIP_BOOKING_REMINDER_TEMPLATE_FILE))
                                               .Replace(Constant.EMAIL_ACTIVATION_HOME_PAGE_URL, ConfigurationManager.AppSettings[Constant.BASE_URL_KEY])
                                               .Replace(Constant.EMAIL_CHECKLIST_SHARE_URL, checklistUrl)
                                               .Replace(Constant.EMAIL_BOOKING_DETAIL_URL, bookingDetailUrl)
                                               .Replace(Constant.EMAIL_TICKET_NUMBER, bookingDetail.TicketNumber)
                                               .Replace(Constant.EMAIL_ACTIVATION_USER_FULL_NAME, fullName.ToString())
                                               .Replace(Constant.EMAIL_TRIP_DATE, tripDateDisplay)
                                               .Replace(Constant.EMAIL_NUMBER_OF_TICKET, bookingDetail.NumberOfTicket.ToString())
                                               .Replace(Constant.EMAIL_AMOUNT, amountDisplay);

                string tripBookingConfirmationEmailBody = UtilFunction.GetFileData(Path.Combine(serverMapPath, Constant.TEMPLATE_PATH, Constant.EMAIL_TEMPLATE_FOLDER, Constant.TRIP_BOOKING_CONFIRMATION_TEMPLATE_FILE))
                                               .Replace(Constant.EMAIL_ACTIVATION_HOME_PAGE_URL, ConfigurationManager.AppSettings[Constant.BASE_URL_KEY])
                                               .Replace(Constant.EMAIL_CHECKLIST_SHARE_URL, checklistUrl)
                                               .Replace(Constant.EMAIL_BOOKING_DETAIL_URL, bookingDetailUrl)
                                               .Replace(Constant.EMAIL_TICKET_NUMBER, bookingDetail.TicketNumber)
                                               .Replace(Constant.EMAIL_ACTIVATION_USER_FULL_NAME, fullName.ToString())
                                               .Replace(Constant.EMAIL_TRIP_DATE, tripDateDisplay)
                                               .Replace(Constant.EMAIL_NUMBER_OF_TICKET, bookingDetail.NumberOfTicket.ToString())
                                               .Replace(Constant.EMAIL_AMOUNT, amountDisplay);

                EmailService.ScheduleEmail(bookingDetail.Email, bookingDetail.Username, Constant.BOOKED_TICKET_REMINDER_SUBJECT, tripReminderEmailBody, scheduledTime);
                EmailService.SendEmail(new MailAddress(bookingDetail.Email, bookingDetail.Username), Constant.BOOKED_TICKET_SUBJECT, tripBookingConfirmationEmailBody);
            }
        }

        public Promotion ApplyAndValidatePromoCode(BookingDetail bookingDetail, int userId)
        {
            Promotion promotionInformation = new Promotion();

            SqlCommand sqlCommand = new SqlCommand(Constant.APPLY_AND_VALIDATE_PROMO_CODE_SP, connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            sqlCommand.Parameters.Add("@NumberOfTicket", SqlDbType.Int).Value = bookingDetail.NumberOfTicket;
            sqlCommand.Parameters.Add("@PromoCode", SqlDbType.NVarChar, 10).Value = bookingDetail.PromoCode;
            sqlCommand.Parameters.Add("@UserId", SqlDbType.Int).Value = userId;
            sqlCommand.Parameters.Add("@Rate", SqlDbType.Int).Value = bookingDetail.Rate;

            SqlParameter sqlDiscountedAmountParameter = sqlCommand.Parameters.Add("@DiscountedAmount", SqlDbType.Int);
            sqlDiscountedAmountParameter.Direction = ParameterDirection.Output;

            SqlParameter sqlPromotionValueParameter = sqlCommand.Parameters.Add("@PromotionValue", SqlDbType.Int);
            sqlPromotionValueParameter.Direction = ParameterDirection.Output;

            SqlParameter sqlIsPercentParameter = sqlCommand.Parameters.Add("@IsPercent", SqlDbType.Bit);
            sqlIsPercentParameter.Direction = ParameterDirection.Output;

            using (connection)
            {
                connection.Open();
                sqlCommand.ExecuteNonQuery();
            }

            if (sqlDiscountedAmountParameter.Value != DBNull.Value)
            {
                promotionInformation.DiscountedAmount = Convert.ToInt32(sqlDiscountedAmountParameter.Value);
            }

            if (sqlPromotionValueParameter.Value != DBNull.Value)
            {
                promotionInformation.PromotionValue = Convert.ToInt32(sqlPromotionValueParameter.Value);
            }

            if (sqlIsPercentParameter.Value != DBNull.Value)
            {
                promotionInformation.IsPercent = Convert.ToBoolean(sqlIsPercentParameter.Value);
            }

            return promotionInformation;
        }
    }
}