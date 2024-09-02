namespace MiniTravelingExplorer.Models
{
    public class WeatherDisplay: BaseModel
    {
        public string WeatherIconUrl { get; set; }
        public double TemperatureDouble { get; set; }
        public string Temperature { get; set; }
        public string FeelsLikeTemperature { get; set; }
        public string MinimumTemperature { get; set; }
        public string MaximumTemperature { get; set; }
        public string Description { get; set; }
        public string CloudPercentage { get; set; }
        public string Wind { get; set; }
        public string WindDirection { get; set; }
        public string Gust { get; set; }
        public string Pressure { get; set; }
        public string SunriseTime { get; set; }
        public string SunsetTime { get; set; }
        public bool IsDay { get; set; }
        public string Url { get; set; }
    }
}