using System;

namespace MiniTravelingExplorer.EntityModel
{
    public class MyChecklist
    {
        public int ChecklistId { get; set; }
        public string ChecklistName { get; set; }
        public string LocationName { get; set; }
        public DateTime TripDate { get; set; }
        public int BookingId { get; set; }
        public int ChecklistItemCount { get; set; }
    }
}