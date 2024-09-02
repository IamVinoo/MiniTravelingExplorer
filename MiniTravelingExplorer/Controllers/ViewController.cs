using System;
using System.Web.Mvc;
using MiniTravelingExplorer.Services;
using MiniTravelingExplorer.Utils;

namespace MiniTravelingExplorer.Controllers
{
    public class ViewController : BaseService
    {
        [HttpGet]
        public ActionResult ChecklistItem(string viewCode)
        {
            ViewService viewService = new ViewService();

            try
            {
                ViewData[Constant.CHECKLIST_ITEM_TABLE] = viewService.GetChecklistItem(viewCode, Convert.ToInt32(Session[Constant.USER_ID]));
            }
            catch (Exception exception)
            {
                logger.Error(exception, UtilFunction.ConcatLogMessage(exception.Message));
            }

            return View();
        }
    }
}