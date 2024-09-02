using MiniTravelingExplorer.Utils;

namespace MiniTravelingExplorer.Models
{
    public class Staff: BaseModel
    {
        public int StaffId { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public string LinkedInUrl { get; set; }
        public string FacebookUrl { get; set; }
        public string InstagramUrl { get; set; }
        public byte[] StaffImage { get; set; }
        public string StaffImageType { get; set; }
        public string StaffDisplayImage
        {
            get => UtilFunction.GetFileDataFromBytes(StaffImage, StaffImageType);
            set
            {
                StaffDisplayImage = value;
            }
        }
    }
}