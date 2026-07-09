using System.Net;
using System.Text.Json;
using ProductivityPlatform.Api.Models;
using Serilog;

namespace ProductivityPlatform.Api.Middleware;

public class GlobalExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    public GlobalExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (NotFoundException ex)
        {
            Log.Warning(ex, "Not found: {Resource} {Identifier}", ex.Resource, ex.Identifier);
            context.Response.StatusCode = (int)HttpStatusCode.NotFound;
            context.Response.ContentType = "application/json";

            var response = ApiResponse.Failure(
                "RESOURCE_NOT_FOUND",
                $"Resource '{ex.Resource}' with identifier '{ex.Identifier}' was not found."
            );
            await context.Response.WriteAsJsonAsync(response, JsonOptions);
        }
        catch (BadRequestException ex)
        {
            Log.Warning(ex, "Bad request: {Message}", ex.Message);
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            context.Response.ContentType = "application/json";

            var response = ApiResponse.Failure("BAD_REQUEST", ex.Message, ex.Details);
            await context.Response.WriteAsJsonAsync(response, JsonOptions);
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Unhandled exception: {Message}", ex.Message);
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";

            var response = ApiResponse.Failure(
                "INTERNAL_SERVER_ERROR",
                "An unexpected error occurred."
            );
            await context.Response.WriteAsJsonAsync(response, JsonOptions);
        }
    }
}
