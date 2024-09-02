using System.Net;

namespace MiniTravelingExplorer.Models
{
    public class HttpResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public string SuccessMessage { get; set; }
        public string ErrorMessage { get; set; }
        public object ResponseData { get; set; }
        public bool IsRedirect { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
    }
}