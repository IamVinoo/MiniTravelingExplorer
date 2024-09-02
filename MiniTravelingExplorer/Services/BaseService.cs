using AutoMapper;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Net;
using System.Web.Mvc;
using MiniTravelingExplorer.Models;
using MiniTravelingExplorer.Models.Configuration;
using MiniTravelingExplorer.Utils;
using SystemWeb = System.Web;

namespace MiniTravelingExplorer.Services
{
    public class BaseService : Controller
    {
        public int NoOfRowsAffected { get; set; }

        public Logger logger = LogManager.GetCurrentClassLogger();

        public bool IsLoggedIn
        {
            get
            {
                return Session[Constant.USER_ID] != null;
            }
        }

        public bool IsAdminLoggedIn
        {
            get
            {
                return Session[Constant.ADMIN_USER_ID] != null;
            }
        }

        protected readonly SqlConnection connection = new SqlConnection()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings[Constant.CONNECTION_STRING_KEY].ConnectionString
        };

        protected HttpResponse httpResponse = new HttpResponse()
        {
            StatusCode = HttpStatusCode.BadRequest
        };

        protected HomePageData GetHomePageData(string userFullName, bool isAdminUser = false)
        {
            HomePageData homePageData = new HomePageData();

            SqlCommand sqlCommand = new SqlCommand(Constant.GET_HOME_PAGE_DATA_SP, connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            sqlCommand.Parameters.Add("@TotalLocation", SqlDbType.Int);
            sqlCommand.Parameters["@TotalLocation"].Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add("@TotalRoom", SqlDbType.Int);
            sqlCommand.Parameters["@TotalRoom"].Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add("@TotalStaff", SqlDbType.Int);
            sqlCommand.Parameters["@TotalStaff"].Direction = ParameterDirection.Output;

            DataSet dataSet = new DataSet();

            using (connection)
            {
                using (SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand))
                {
                    dataAdapter.Fill(dataSet, Constant.HOME_PAGE_DATA);

                    if (dataSet != null)
                    {
                        if (dataAdapter.SelectCommand.Parameters["@TotalLocation"].Value != DBNull.Value)
                        {
                            homePageData.TotalLocation = Convert.ToInt32(dataAdapter.SelectCommand.Parameters["@TotalLocation"].Value);
                        }

                        if (dataAdapter.SelectCommand.Parameters["@TotalRoom"].Value != DBNull.Value)
                        {
                            homePageData.TotalRoom = Convert.ToInt32(dataAdapter.SelectCommand.Parameters["@TotalRoom"].Value);
                        }

                        if (dataAdapter.SelectCommand.Parameters["@TotalStaff"].Value != DBNull.Value)
                        {
                            homePageData.TotalStaff = Convert.ToInt32(dataAdapter.SelectCommand.Parameters["@TotalStaff"].Value);
                        }

                        if (dataSet.Tables != null && dataSet.Tables.Count >= 2)
                        {
                            if (dataSet.Tables[0] != null)
                            {
                                List<EntityModel.Room> featuredRoomList = UtilFunction.DataTableToList<EntityModel.Room>(dataSet.Tables[0]);
                                Mapper mapper = AutoMapperConfiguration.InitializeAutomapper();
                                homePageData.FeaturedRoomList = mapper.Map<List<EntityModel.Room>, List<Room>>(featuredRoomList);
                                homePageData.FeaturedRoomList = UtilFunction.SetRoomCardAnimationTimeDelay(homePageData.FeaturedRoomList);
                            }

                            if (dataSet.Tables[1] != null)
                            {
                                List<EntityModel.Testimonial> testimonialList = UtilFunction.DataTableToList<EntityModel.Testimonial>(dataSet.Tables[1]);
                                Mapper mapper = AutoMapperConfiguration.InitializeAutomapper();
                                homePageData.TestimonialList = mapper.Map<List<EntityModel.Testimonial>, List<Testimonial>>(testimonialList);
                            }
                        }
                    }
                }

                string ip = SystemWeb.HttpContext.Current.Request.ServerVariables[Constant.HTTP_X_FORWARDED_FOR];

                if (string.IsNullOrEmpty(ip))
                {
                    ip = SystemWeb.HttpContext.Current.Request.ServerVariables[Constant.REMOTE_ADDR];
                }

                if (!string.IsNullOrEmpty(ip))
                {
                    IpInfo ipInfo = JsonConvert.DeserializeObject<IpInfo>(new WebClient().DownloadString(string.Concat(ConfigurationManager.AppSettings[Constant.IP_INFO_LINK_KEY], ip)));

                    if (ipInfo != null)
                    {
                        sqlCommand = new SqlCommand(Constant.INSERT_USER_DETAIL_BY_IP_SP, connection)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        sqlCommand.Parameters.Add("@Ip", SqlDbType.NVarChar, 100).Value = ip;
                        sqlCommand.Parameters.Add("@User", SqlDbType.NVarChar, 100).Value = string.IsNullOrEmpty(userFullName) ? Constant.ANONYMOUS : userFullName;
                        sqlCommand.Parameters.Add("@BrowserType", SqlDbType.NVarChar, 100).Value = SystemWeb.HttpContext.Current.Request.Browser.Type;
                        sqlCommand.Parameters.Add("@BrowserName", SqlDbType.NVarChar, 200).Value = SystemWeb.HttpContext.Current.Request.Browser.Browser;
                        sqlCommand.Parameters.Add("@BrowserVersion", SqlDbType.NVarChar, 50).Value = SystemWeb.HttpContext.Current.Request.Browser.Version;
                        sqlCommand.Parameters.Add("@IsMobileDevice", SqlDbType.Bit).Value = SystemWeb.HttpContext.Current.Request.Browser.IsMobileDevice;
                        sqlCommand.Parameters.Add("@Platform", SqlDbType.NVarChar, 100).Value = SystemWeb.HttpContext.Current.Request.Browser.Platform;
                        sqlCommand.Parameters.Add("@Version", SqlDbType.NVarChar, 50).Value = SystemWeb.HttpContext.Current.Request.Browser.Version;
                        sqlCommand.Parameters.Add("@City", SqlDbType.NVarChar, 100).Value = string.IsNullOrEmpty(ipInfo.City) ? (object)DBNull.Value : ipInfo.City;
                        sqlCommand.Parameters.Add("@Region", SqlDbType.NVarChar, 100).Value = string.IsNullOrEmpty(ipInfo.Region) ? (object)DBNull.Value : ipInfo.Region;
                        sqlCommand.Parameters.Add("@Country", SqlDbType.NVarChar, 100).Value = string.IsNullOrEmpty(ipInfo.Country) ? (object)DBNull.Value : new RegionInfo(ipInfo.Country).EnglishName;
                        sqlCommand.Parameters.Add("@TimeZone", SqlDbType.NVarChar, 100).Value = string.IsNullOrEmpty(ipInfo.TimeZone) ? (object)DBNull.Value : ipInfo.TimeZone;
                        sqlCommand.Parameters.Add("@HostName", SqlDbType.NVarChar, 200).Value = string.IsNullOrEmpty(ipInfo.HostName) ? (object)DBNull.Value : ipInfo.HostName;
                        sqlCommand.Parameters.Add("@Organization", SqlDbType.NVarChar, 200).Value = string.IsNullOrEmpty(ipInfo.Organization) ? (object)DBNull.Value : ipInfo.Organization;
                        sqlCommand.Parameters.Add("@IsAdminUser", SqlDbType.Bit).Value = isAdminUser;

                        connection.Open();
                        sqlCommand.ExecuteNonQuery();
                    }
                }
            }

            return homePageData;
        }

        protected EntityModel.User GetUserPassword(string email, string fullName, int userId, bool isUpdatePassword, bool isVerifyAdmin = false)
        {
            EntityModel.User userDetail = new EntityModel.User();

            SqlCommand sqlCommand = new SqlCommand(Constant.GET_USER_PASSWORD_SP, connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            sqlCommand.Parameters.AddWithValue("@Email", email);
            sqlCommand.Parameters.AddWithValue("@FullName", fullName);
            sqlCommand.Parameters.AddWithValue("@UserId", userId);
            sqlCommand.Parameters.AddWithValue("@IsUpdatePassword", isUpdatePassword);
            sqlCommand.Parameters.AddWithValue("@IsVerifyAdmin", isVerifyAdmin);

            DataSet dataSet = new DataSet();

            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand))
            {
                dataAdapter.Fill(dataSet, Constant.USER_TABLE);

                if (dataSet != null)
                {
                    dataAdapter.Fill(dataSet, Constant.USER_TABLE);
                    DataTable dataTable = dataSet.Tables[Constant.USER_TABLE];
                    userDetail = UtilFunction.DataTableToObject<EntityModel.User>(dataTable);
                }
            }

            return userDetail;
        }

        protected List<SecurityQuestions> GetSecurityQuestion()
        {
            List<SecurityQuestions> securityQuestionList = new List<SecurityQuestions>();

            using (connection)
            {
                using (SqlDataAdapter dataAdapter = new SqlDataAdapter())
                {
                    dataAdapter.SelectCommand = new SqlCommand(Constant.GET_SECURITY_QUESTION_SP, connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    DataSet dataSet = new DataSet();

                    if (dataSet != null)
                    {
                        dataAdapter.Fill(dataSet, Constant.SECURITY_QUESTION_TABLE);
                        DataTable dt = dataSet.Tables[Constant.SECURITY_QUESTION_TABLE];
                        List<EntityModel.SecurityQuestions> entitySecurityQuestionList = UtilFunction.DataTableToList<EntityModel.SecurityQuestions>(dt);
                        Mapper mapper = AutoMapperConfiguration.InitializeAutomapper();
                        securityQuestionList = mapper.Map<List<EntityModel.SecurityQuestions>, List<SecurityQuestions>>(entitySecurityQuestionList);
                    }
                }
            }

            return securityQuestionList;
        }

        protected List<MyChecklistItem> GetChecklistItem(int? checklistId, int? bookingId, int userId, string linkId = "")
        {
            List<MyChecklistItem> myChecklistItemList = new List<MyChecklistItem>();

            if (checklistId.HasValue)
            {
                using (connection)
                {
                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter())
                    {
                        dataAdapter.SelectCommand = new SqlCommand(Constant.GET_CHECKLIST_ITEM_SP, connection)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        dataAdapter.SelectCommand.Parameters.Add("@CheckListId", SqlDbType.Int).Value = checklistId;
                        dataAdapter.SelectCommand.Parameters.Add("@BookingId", SqlDbType.Int).Value = bookingId;
                        dataAdapter.SelectCommand.Parameters.Add("@UserId", SqlDbType.Int).Value = userId;
                        dataAdapter.SelectCommand.Parameters.Add("@ShareLink", SqlDbType.NVarChar, 500).Value = linkId;

                        DataSet dataSet = new DataSet();

                        if (dataSet != null)
                        {
                            dataAdapter.Fill(dataSet, Constant.CHECKLIST_ITEM_TABLE);
                            DataTable dataTable = dataSet.Tables[Constant.CHECKLIST_ITEM_TABLE];
                            List<EntityModel.MyChecklistItem> entityMyChecklistItemList = UtilFunction.DataTableToList<EntityModel.MyChecklistItem>(dataTable);
                            Mapper mapper = AutoMapperConfiguration.InitializeAutomapper();
                            myChecklistItemList = mapper.Map<List<EntityModel.MyChecklistItem>, List<MyChecklistItem>>(entityMyChecklistItemList);
                        }
                    }
                }
            }

            return myChecklistItemList;
        }
    }
}