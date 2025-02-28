using System.Net;

namespace Application.DTOs.Response
{
    public class ApiResponseErrorModel
    {
        public string Errors { get; set; }
        public HttpStatusCode Status { get; set; } = HttpStatusCode.InternalServerError;
    }
}
