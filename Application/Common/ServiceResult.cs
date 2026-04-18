namespace TaskFlow.Application.Common
{
    public class ServiceResult
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public object? Data { get; set; }

        // Static factory methods
        public static ServiceResult SuccessResult(object? data = null, string? message = null)
        {
            return new ServiceResult
            {
                IsSuccess = true,
                Data = data,
                Message = message
            };
        }

        public static ServiceResult FailureResult(string message)
        {
            return new ServiceResult
            {
                IsSuccess = false,
                Message = message
            };
        }
    }
}
