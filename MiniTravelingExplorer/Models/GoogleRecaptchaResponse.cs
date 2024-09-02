using System.Collections.Generic;

namespace MiniTravelingExplorer.Models
{
    public class GoogleRecaptchaResponse
    {
        public bool Success { get; set; }
        public List<string> ErrorCodes { get; set; }
    }
}