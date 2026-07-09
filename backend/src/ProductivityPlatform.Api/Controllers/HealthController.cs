using Microsoft.AspNetCore.Mvc;
using ProductivityPlatform.Api.Models;
using ProductivityPlatform.Infrastructure.Persistence;

namespace ProductivityPlatform.Api.Controllers;

[ApiController]
[Route("api/v1")]
public class HealthController : ControllerBase
{
    private readonly AppDbContext _dbContext;

    public HealthController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet("health")]
    public async Task<ActionResult<ApiResponse>> GetHealth()
    {
        var databaseStatus = "Disconnected";

        try
        {
            var canConnect = await _dbContext.Database.CanConnectAsync();
            databaseStatus = canConnect ? "Connected" : "Disconnected";
        }
        catch
        {
            databaseStatus = "Disconnected";
        }

        return Ok(ApiResponse.Success(new
        {
            Status = "Healthy",
            Timestamp = DateTime.UtcNow,
            Database = databaseStatus
        }));
    }
}
