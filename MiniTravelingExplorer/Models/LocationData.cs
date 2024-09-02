using System.Collections.Generic;

namespace MiniTravelingExplorer.Models
{
    public class LocationData
    {
        public List<Location> LocationList { get; set; }
        public List<Activity> Activity { get; set; }
        public List<WeatherDescription> Weather { get; set; }
        public int MinimumPrice { get; set; }
        public int MaximumPrice { get; set; }
        public double MinimumTemperature { get; set; }
        public double MaximumTemperature { get; set; }
        public int MinimumRate { get; set; }
        public int MaximumRate { get; set; }
    }
}