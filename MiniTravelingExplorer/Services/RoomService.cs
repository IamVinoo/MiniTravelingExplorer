using System.Collections.Generic;
using AutoMapper;
using System.Data;
using System.Data.SqlClient;
using MiniTravelingExplorer.Models;
using EntityModel = MiniTravelingExplorer.EntityModel;
using MiniTravelingExplorer.Utils;
using MiniTravelingExplorer.Models.Configuration;

namespace MiniTravelingExplorer.Services
{
    public class RoomService : BaseService
    {
        public List<Room> GetRoomList()
        {
            List<Room> roomList = new List<Room>();

            using (connection)
            {
                using (SqlDataAdapter dataAdapter = new SqlDataAdapter())
                {
                    dataAdapter.SelectCommand = new SqlCommand(Constant.GET_ROOM_LIST_SP, connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    DataSet dataSet = new DataSet();

                    if (dataSet != null)
                    {
                        dataAdapter.Fill(dataSet, Constant.ROOM_TABLE);
                        DataTable dt = dataSet.Tables[Constant.ROOM_TABLE];
                        List<EntityModel.Room> entityRoomList = UtilFunction.DataTableToList<EntityModel.Room>(dt);
                        Mapper mapper = AutoMapperConfiguration.InitializeAutomapper();
                        roomList = mapper.Map<List<EntityModel.Room>, List<Room>>(entityRoomList);
                        roomList = UtilFunction.SetRoomCardAnimationTimeDelay(roomList);
                    }
                }
            }

            return roomList;
        }
    }
}