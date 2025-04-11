using System.IdentityModel.Tokens.Jwt;

public class AuthenticationMiddleware(RequestDelegate next, ILogger<AuthenticationMiddleware> logger)
{
	private readonly RequestDelegate _next = next;
	private readonly ILogger<AuthenticationMiddleware> _logger = logger;

	public async Task InvokeAsync(HttpContext httpContext)
	{
		// Log the Authorization header for debugging
		var authorizationHeader = httpContext.Request.Headers.Authorization.FirstOrDefault();
		_logger.LogInformation("Authorization Header: {AuthorizationHeader}", authorizationHeader);

		var token = authorizationHeader?.Split(" ").Last();

		if (string.IsNullOrEmpty(token) || !ValidateToken(token))
		{
			httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
			await httpContext.Response.WriteAsync("{\"error\": \"Unauthorized\"}");
			return;
		}

		await _next(httpContext);
	}

	private bool ValidateToken(string token)
	{
		try
		{
			var handler = new JwtSecurityTokenHandler();
			var jwtToken = handler.ReadJwtToken(token);
			return jwtToken != null; // Implement actual token validation logic
		}
		catch
		{
			return false;
		}
	}
}
