namespace DenounceBeasts.API.Models.Responses
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        //public bool ISSuccess { get; set; }
        //public string Message { get; set; } = string.Empty;
        public string ErrorMessage { get; set; } = string.Empty;
        public int StatusCode { get; set; }
        //public StatusCode StatusCode { get; set; }
        public T? Data { get; set; }

        public static ApiResponse<T> SuccessResponse(T data, int statusCode = 200)
        {
            return new ApiResponse<T>
            {
                Success = true,
                StatusCode = statusCode,
                Data = data
            };
        }
        public static ApiResponse<T> FailureResponse(string errorMessage, int statusCode = 500)
        {
            return new ApiResponse<T>
            {
                Success = false,
                ErrorMessage = errorMessage,
                StatusCode = statusCode
            };
        }
    }
}
