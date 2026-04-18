namespace TaskFlow.API.Common
{
    public class ApiResponse<T>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }
        public List<string>? Errors { get; set; }
        public DateTime Timestamp { get; set; }

        public ApiResponse()
        {
            Timestamp = DateTime.UtcNow;
        }

        public static ApiResponse<T> SuccessResponse(T? data, string message = "Success")
        {
            return new ApiResponse<T>
            {
                IsSuccess = true,
                Message = message,
                Data = data,
                Errors = null
            };
        }

        public static ApiResponse<T> FailureResponse(string message, List<string>? errors = null)
        {
            return new ApiResponse<T>
            {
                IsSuccess = false,
                Message = message,
                Data = default,
                Errors = errors ?? new List<string> { message }
            };
        }
    }

    public class ApiResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = string.Empty;
        public List<string>? Errors { get; set; }
        public DateTime Timestamp { get; set; }

        public ApiResponse()
        {
            Timestamp = DateTime.UtcNow;
        }

        public static ApiResponse SuccessResponse(string message = "Success")
        {
            return new ApiResponse
            {
                IsSuccess = true,
                Message = message,
                Errors = null
            };
        }

        public static ApiResponse FailureResponse(string message, List<string>? errors = null)
        {
            return new ApiResponse
            {
                IsSuccess = false,
                Message = message,
                Errors = errors ?? new List<string> { message }
            };
        }
    }
}