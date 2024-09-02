using AutoMapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using MiniTravelingExplorer.Models;
using MiniTravelingExplorer.Utils;
using System.IO;
using System.Net.Mail;
using MiniTravelingExplorer.Models.Configuration;

namespace MiniTravelingExplorer.Services
{
    public class HomeService : BaseService
    {
        public ContactPageData GetContactPageData()
        {
            ContactPageData contactPageData = new ContactPageData();

            SqlCommand sqlCommand = new SqlCommand(Constant.GET_CONTACT_PAGE_DATA_SP, connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            DataSet dataSet = new DataSet();

            using (connection)
            {
                using (SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand))
                {
                    dataAdapter.Fill(dataSet, Constant.HOME_PAGE_DATA);

                    if (dataSet != null && dataSet.Tables != null && dataSet.Tables.Count >= 2)
                    {
                        if (dataSet.Tables[0] != null)
                        {
                            List<EntityModel.Location> locationList = UtilFunction.DataTableToList<EntityModel.Location>(dataSet.Tables[0]);
                            Mapper mapper = AutoMapperConfiguration.InitializeAutomapper();
                            contactPageData.Location = mapper.Map<List<EntityModel.Location>, List<Location>>(locationList).FirstOrDefault();
                        }

                        if (dataSet.Tables[1] != null)
                        {
                            List<EntityModel.Staff> staffList = UtilFunction.DataTableToList<EntityModel.Staff>(dataSet.Tables[1]);
                            Mapper mapper = AutoMapperConfiguration.InitializeAutomapper();
                            contactPageData.Staff = mapper.Map<List<EntityModel.Staff>, List<Staff>>(staffList);

                            if (contactPageData.Staff.Any())
                            {
                                int count = 1;
                                float animationDelayTime = 0.1f;

                                contactPageData.Staff.ForEach(s =>
                                {
                                    if (count == 1)
                                    {
                                        animationDelayTime = 0.1f;
                                    }
                                    else if (count == 3)

                                    {
                                        count = 0;
                                        animationDelayTime *= 2;
                                    }
                                    else
                                    {
                                        animationDelayTime += animationDelayTime * 2;
                                    }

                                    s.AnimationDelayTime = string.Concat(animationDelayTime, Constant.S_CHARACTER.ToLower());
                                    count++;
                                });
                            }
                        }
                    }
                }
            }

            return contactPageData;
        }

        public void InsertUpdateSubscriber(string email, bool isUnsubscribe, string serverMapPath, out bool isAlreadySubscribed)
        {
            string promoCode = UtilFunction.GeneratePromoCode();

            SqlCommand sqlCommand = new SqlCommand(Constant.INSERT_UPDATE_SUBSCRIBER_SP, connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            sqlCommand.Parameters.Add("@Email", SqlDbType.NVarChar, 100).Value = email;
            sqlCommand.Parameters.Add("@PromoCode", SqlDbType.NVarChar, 20).Value = promoCode;
            sqlCommand.Parameters.Add("@PromotionId", SqlDbType.Int).Value = Convert.ToInt32(ConfigurationManager.AppSettings[Constant.EMAIL_SUBSCRIPTION_PROMOTION_ID_KEY]);
            sqlCommand.Parameters.Add("@IsUnsubscribe", SqlDbType.Bit).Value = isUnsubscribe;

            SqlParameter isAlrieadySubscribedOutputParameter = sqlCommand.Parameters.Add("@IsAlreadySubscribed", SqlDbType.Bit);
            isAlrieadySubscribedOutputParameter.Direction = ParameterDirection.Output;

            using (connection)
            {
                connection.Open();
                NoOfRowsAffected = sqlCommand.ExecuteNonQuery();
            }

            isAlreadySubscribed = isAlrieadySubscribedOutputParameter.Value != DBNull.Value && Convert.ToBoolean(isAlrieadySubscribedOutputParameter.Value);

            if (NoOfRowsAffected > 0 && !isAlreadySubscribed)
            {
                EmailService.SendEmail(
                    new MailAddress(email, email),
                    Constant.SUBSCRIPTION_SUBJECT,
                    UtilFunction.GetFileData(Path.Combine(serverMapPath, Constant.TEMPLATE_PATH, Constant.EMAIL_TEMPLATE_FOLDER, Constant.EMAIL_SUBSCRIPTION_TEMPLATE_FILE))
                           .Replace(Constant.EMAIL_ACTIVATION_HOME_PAGE_URL, ConfigurationManager.AppSettings[Constant.BASE_URL_KEY])
                           .Replace(Constant.EMAIL_PROMO_CODE, promoCode)
                           .Replace(Constant.EMAIL_UNSUBSCRIBE_LINK, string.Concat(ConfigurationManager.AppSettings[Constant.BASE_URL_KEY], Constant.UNSUBSCRIBE_LINK, email)));
            }
        }
    }
}