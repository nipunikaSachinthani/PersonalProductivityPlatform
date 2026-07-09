using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using ProductivityPlatform.Api.Middleware;
using ProductivityPlatform.Infrastructure.Persistence;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Serilog bootstrap: read from appsettings + environment overrides
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

builder.Host.UseSerilog();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new()
    {
        Title = "Productivity Platform API",
        Version = "v1"
    });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowViteDevServer", policy =>
    {
        policy.WithOrigins("http://localhost:5173", "http://localhost:5175")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

app.UseMiddleware<GlobalExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowViteDevServer");

app.MapControllers();

app.Lifetime.ApplicationStarted.Register(() =>
{
    Log.Information("Productivity Platform API started on {Environment}", app.Environment.EnvironmentName);
});

app.Run();
