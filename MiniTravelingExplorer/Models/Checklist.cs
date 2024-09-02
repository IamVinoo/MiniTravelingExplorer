using System;

namespace MiniTravelingExplorer.Models
{
    public class Checklist: BaseModel
    {
        public int ChecklistId { get; set; }
        public string Name { get; set; }
        public int BookingId { get; set; }
        public string ShareLink { get; set; }
        public string LocationName { get; set; }
        public DateTime TripDate { get; set; }
    }
}