using System;
using MiniTravelingExplorer.Utils;

namespace MiniTravelingExplorer.Models
{
    public class Location: BaseModel
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
        public string OpeningTimeDisplay
        {
            get => UtilFunction.CustomTimespanFormat(OpeningTime);
            set
            {
                OpeningTimeDisplay = value;
            }

        }
        public string ClosingTimeDisplay
        {
            get => UtilFunction.CustomTimespanFormat(ClosingTime);
            set
            {
                ClosingTimeDisplay = value;
            }
        }
        public string Lattitude { get; set; }
        public string Longitude { get; set; }
        public string LocationImageUrl { get; set; }
        public WeatherDisplay Weather { get; set; }
    }
}