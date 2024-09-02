using System.Collections.Generic;

namespace MiniTravelingExplorer.Models
{
    public class HomePageData
    {
        public int TotalLocation { get; set; }
        public int TotalRoom { get; set; }
        public int TotalStaff { get; set; }
        public List<Room> FeaturedRoomList { get; set; }
        public List<Testimonial> TestimonialList { get; set; }
    }
}