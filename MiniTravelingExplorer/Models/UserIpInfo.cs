namespace MiniTravelingExplorer.Models
{
    public class UserIpInfo : BaseModel
    {
        public string Ip { get; set; }
        public string User { get; set; }
        public string BrowserType { get; set; }
        public string BrowserName { get; set; }
        public string BrowserVersion { get; set; }
        public bool IsMobileDevice { get; set; }
        public string Platform { get; set; }
        public string Version { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public string TimeZone { get; set; }
        public string HostName { get; set; }
        public string Organization { get; set; }
        public bool IsAdminUser { get; set; }
    }
}