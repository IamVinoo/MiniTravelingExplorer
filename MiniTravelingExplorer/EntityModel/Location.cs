using System;

namespace MiniTravelingExplorer.EntityModel
{
    public class Location
    {
        public int LocationId { get; set; }
        public string Name { get; set; }
        public string Activity { get; set; }
        public string CurrencySymbol { get; set; }
        public int Rate { get; set; }
        public int TotalNumberOfPerson { get; set; }
        public int Ticket { get; set; }
        public string Description { get; set; }
        public TimeSpan OpeningTime { get; set; }
        public TimeSpan ClosingTime { get; set; }
        public string Lattitude { get; set; }
        public string Longitude { get; set; }
        public string LocationImageUrl { get; set; }
    }
}