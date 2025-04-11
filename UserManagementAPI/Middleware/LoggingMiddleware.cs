public class LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
{
	private readonly RequestDelegate _next = next;
	private readonly ILogger<LoggingMiddleware> _logger = logger;

	public async Task InvokeAsync(HttpContext httpContext)
	{
		// Log incoming request
		_logger.LogInformation("Incoming Request: {Method} {Path}", httpContext.Request.Method, httpContext.Request.Path);

		// Call the next middleware in the pipeline
		await _next(httpContext);

		// Log outgoing response
		_logger.LogInformation("Outgoing Response: {StatusCode}", httpContext.Response.StatusCode);
	}
}
