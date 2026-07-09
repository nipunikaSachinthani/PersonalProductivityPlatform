namespace ProductivityPlatform.Api.Models;

public class ApiResponse
{
    public object? Data { get; init; }
    public List<ErrorDetail> Errors { get; init; } = [];
    public object? Meta { get; init; }

    public static ApiResponse Success(object? data = null, object? meta = null)
    {
        return new ApiResponse
        {
            Data = data,
            Meta = meta
        };
    }

    public static ApiResponse Failure(string code, string message, object? details = null)
    {
        return new ApiResponse
        {
            Errors = [new ErrorDetail { Code = code, Message = message, Details = details }]
        };
    }

    public static ApiResponse Failure(List<ErrorDetail> errors)
    {
        return new ApiResponse
        {
            Errors = errors
        };
    }
}

public class ErrorDetail
{
    public string Code { get; init; } = string.Empty;
    public string Message { get; init; } = string.Empty;
    public object? Details { get; init; }
}
