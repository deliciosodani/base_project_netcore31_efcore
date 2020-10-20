
namespace eClinica.WebApi.Models
{
    public class ApiResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Result { get; set; }

        public ApiResponse(bool success, string message = null, object result = null)
        {
            Success = success;
            Message = message;
            Result = result;
        }
    }
}
