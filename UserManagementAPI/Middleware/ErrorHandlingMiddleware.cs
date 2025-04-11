using System.Net;

public class ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
{
	private readonly RequestDelegate _next = next;
	private readonly ILogger<ErrorHandlingMiddleware> _logger = logger;

	public async Task InvokeAsync(HttpContext httpContext)
	{
		try
		{
			await _next(httpContext);
		}
		catch (Exception ex)
		{
			// Log the error
			_logger.LogError(ex, "An unexpected error occurred.");

			// Return a standardized error response
			httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
			httpContext.Response.ContentType = "application/json";
			await httpContext.Response.WriteAsync("{\"error\": \"Internal server error.\"}");
		}
	}
}
