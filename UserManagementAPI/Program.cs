using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddOpenApi();
builder.Services.AddLogging();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSingleton<UserService>();

var app = builder.Build();

// // Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
	app.MapOpenApi();
	app.MapScalarApiReference(options =>
	{
		options.Title = "User Management API";
		options.DefaultHttpClient = new(ScalarTarget.CSharp, ScalarClient.HttpClient);
		options.Theme = ScalarTheme.DeepSpace;
		options.ShowSidebar = true;
	});
}

// // Add middleware in the correct order
app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseMiddleware<LoggingMiddleware>();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
