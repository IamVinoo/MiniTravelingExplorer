using System;

namespace MiniTravelingExplorer.EntityModel
{
    public class Checklist
    {
        public int ChecklistId { get; set; }
        public string Name { get; set; }
        public int BookingId { get; set; }
        public string ShareLink { get; set; }
        public string LocationName { get; set; }
        public DateTime TripDate { get; set; }
    }
}