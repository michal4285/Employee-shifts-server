using System.Net;

namespace API.Models
{
    public class Response
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool IsError { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}