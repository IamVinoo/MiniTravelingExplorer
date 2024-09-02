using System;

namespace MiniTravelingExplorer.Models
{
    public class BaseModel
    {
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string MapUrl { get; set; }
        public string GoogleRecaptchaResponse { get; set; }
        public string AnimationDelayTime { get; set; }
        public bool IsFirstItem { get; set; }
        public bool IsNotAvailable { get; set; }
        public string Option { get; set; }
        public string EmailTo { get; set; }
        public HttpResponse HttpResponse { get; set; }
    }
}