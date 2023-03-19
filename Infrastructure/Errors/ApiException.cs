namespace ClientSelfService.Infrastructure.Errors
{
   public class ApiException
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string Details { get; set; }
        public ApiException(int statusCode, string? message = null, string? details = null)
        {
            StatusCode = statusCode;
            Message = message ?? string.Empty;
            Details = details ?? string.Empty;
        }
    }
}