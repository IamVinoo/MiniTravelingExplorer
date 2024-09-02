namespace MiniTravelingExplorer.Models
{
    public class Room: BaseModel
    {
        public int RoomId { get; set; }
        public string Name { get; set; }
        public float Rating { get; set; }
        public int Rate { get; set; }
        public string CurrencySymbol { get; set; }
        public string PerDayOrNight { get; set; }
        public int BedNumber { get; set; }
        public int BathNumber { get; set; }
        public bool HasWifi { get; set; }
        public string Description { get; set; }
        public bool IsFeatured { get; set; }
        public string RoomImageUrl { get; set; }
    }
}