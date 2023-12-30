namespace School.Core.Bases
{
    public class ResponseHandler
    {
        public Response<T> Success<T>(string? message, T data)
        {
            return new Response<T>
            {
                StatusCode = HttpStatusCode.OK,
                Success = true,
                Message = message ?? "Success",
                Data = data
            };
        }
        public Response<string> Success(string? message)
        {
            return new Response<string>
            {
                StatusCode = HttpStatusCode.OK,
                Success = true,
                Message = message ?? "Success",
            };
        }
        public Response<string> BadRequest(string? message)
        {
            return new Response<string>
            {
                StatusCode = HttpStatusCode.BadRequest,
                Success = true,
                Message = message ?? "Something Error",
            };
        }
        public Response<string> Unauthorized(string? message)
        {
            return new Response<string>
            {
                StatusCode = HttpStatusCode.Unauthorized,
                Success = true,
                Message = message ?? "Something Error",
            };
        }
    }
}
