using System.Collections.Generic;

namespace MiniTravelingExplorer.Models
{
    public class ChecklistData
    {
        public List<MyChecklist> ChecklistList { get; set;}
        public List<ActiveBooking> ActiveBookingList { get; set;}
        public string ActiveBooking { get; set; }
    }
}