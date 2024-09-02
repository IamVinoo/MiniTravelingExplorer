using AutoMapper;
using MiniTravelingExplorer.Models;
using MiniTravelingExplorer.Models.Configuration;
using MiniTravelingExplorer.Utils;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace MiniTravelingExplorer.Services
{
    public class AdminService : BaseService
    {
        public User ValidateAdmin(User user)
        {
            EntityModel.User userPasswordDetail = GetUserPassword(user.Email, string.Empty, 0, false, true);

            if (userPasswordDetail == null || !UtilFunction.VerifyHashedPassword(userPasswordDetail.Password, user.Password, userPasswordDetail.SaltKey))
            {
                return null;
            }

            Mapper mapper = AutoMapperConfiguration.InitializeAutomapper();
            return mapper.Map<EntityModel.User, User>(userPasswordDetail);
        }

        public List<User> GetUserList(int userId, bool isAdmin)
        {
            List<User> userList = new List<User>();

            using (SqlDataAdapter dataAdapter = new SqlDataAdapter())
            {
                dataAdapter.SelectCommand = new SqlCommand(Constant.GET_USER_LIST_SP, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                dataAdapter.SelectCommand.Parameters.AddWithValue("@UserId", userId);
                dataAdapter.SelectCommand.Parameters.AddWithValue("@IsAdmin", isAdmin);

                DataSet dataSet = new DataSet();

                if (dataSet != null)
                {
                    dataAdapter.Fill(dataSet, Constant.USER_TABLE);
                    DataTable dataTable = dataSet.Tables[Constant.USER_TABLE];
                    List<EntityModel.User> entityUserList = UtilFunction.DataTableToList<EntityModel.User>(dataTable);
                    Mapper mapper = AutoMapperConfiguration.InitializeAutomapper();
                    userList = mapper.Map<List<EntityModel.User>, List<User>>(entityUserList);
                }
            }

            return userList;
        }

        public List<UserIpInfo> GetUserIpInfoList(int userId)
        {
            List<UserIpInfo> userIpInfoList = new List<UserIpInfo>();

            using (SqlDataAdapter dataAdapter = new SqlDataAdapter())
            {
                dataAdapter.SelectCommand = new SqlCommand(Constant.GET_USER_IP_INFO_LIST_SP, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                dataAdapter.SelectCommand.Parameters.AddWithValue("@UserId", userId);

                DataSet dataSet = new DataSet();

                if (dataSet != null)
                {
                    dataAdapter.Fill(dataSet, Constant.USER_IP_INFO_TABLE);
                    DataTable dataTable = dataSet.Tables[Constant.USER_IP_INFO_TABLE];
                    List<EntityModel.UserIpInfo> entityUserIpInfoList = UtilFunction.DataTableToList<EntityModel.UserIpInfo>(dataTable);
                    Mapper mapper = AutoMapperConfiguration.InitializeAutomapper();
                    userIpInfoList = mapper.Map<List<EntityModel.UserIpInfo>, List<UserIpInfo>>(entityUserIpInfoList);
                }
            }

            return userIpInfoList;
        }
    }
}