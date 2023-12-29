namespace School.Core.Bases;

public class Response<T>
{
    public HttpStatusCode StatusCode { get; set; }
    public bool Success { get; set; }
    public string Message { get; set; } = string.Empty;
    public T? Data { get; set; }
}
