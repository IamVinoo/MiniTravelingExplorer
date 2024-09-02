using Newtonsoft.Json;
using System.Collections.Generic;
using MiniTravelingExplorer.Utils;
using MiniTravelingExplorer.Models;

namespace MiniTravelingExplorer.Services
{
    public class ViewService : BaseService
    {
        public List<MyChecklistItem> GetChecklistItem(string viewCode, int userId)
        {
            List<MyChecklistItem> myChecklistItemList = new List<MyChecklistItem>();

            if (!string.IsNullOrWhiteSpace(viewCode))
            {
                Checklist checklist = JsonConvert.DeserializeObject<Checklist>(UtilFunction.DecryptString(viewCode));

                myChecklistItemList = GetChecklistItem(0, checklist.BookingId, userId, checklist.ShareLink);
            }

            return myChecklistItemList;
        }
    }
}