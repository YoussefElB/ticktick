using System.Net;

namespace TickTick.App.ResponseWrappers
{
    public class Response<T>
    {
        public T Data { get; set; }
        public string[] Errors { get; set; }
        public HttpStatusCode Status { get; set; }
        public string Message { get; set; }

        public Response(T data, string[] errors, HttpStatusCode status, string message)
        {
            Data = data;
            Errors = errors;
            Status = status;
            Message = message;
        }
        public Response()
        {
        }
    }
}
