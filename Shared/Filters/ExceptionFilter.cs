using System.Text.Json;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(
        RequestDelegate next,
        ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unhandled exception");

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = ex switch
            {
                BadHttpRequestException => StatusCodes.Status400BadRequest,
                _ => StatusCodes.Status500InternalServerError
            };

            var response = new
            {
                success = false,
                message = "Request failed",
                statusCode = context.Response.StatusCode,
                detail = ex.Message
            };

            await context.Response.WriteAsync(
                JsonSerializer.Serialize(response)
            );
        }
    }
}