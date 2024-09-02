using System;
using System.Web.Mvc;
using MiniTravelingExplorer.Services;
using MiniTravelingExplorer.Utils;

namespace MiniTravelingExplorer.Controllers
{
    public class RoomController : BaseService
    {
        readonly RoomService roomService = new RoomService();

        public ActionResult List()
        {
            try
            {
                ViewData[Constant.ROOM_TABLE] = roomService.GetRoomList();
            }
            catch (Exception exception)
            {
                logger.Error(exception, UtilFunction.ConcatLogMessage(exception.Message));
            }

            return View();
        }
    }
}