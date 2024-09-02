using System.Collections.Generic;

namespace MiniTravelingExplorer.EntityModel
{
    public class HomePageData
    {
        public int TotalRoom { get; set; }
        public int TotalStaff { get; set; }
        public List<Room> FeaturedRoomList { get; set; }
    }
}