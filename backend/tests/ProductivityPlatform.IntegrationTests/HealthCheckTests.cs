using System.Net;
using System.Text.Json;

namespace ProductivityPlatform.IntegrationTests;

public class HealthCheckTests : IClassFixture<CustomWebApplicationFactory>
{
    private readonly HttpClient _client;

    public HealthCheckTests(CustomWebApplicationFactory factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetHealth_ReturnsOk_WithHealthyStatus()
    {
        var response = await _client.GetAsync("/api/v1/health");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var json = await response.Content.ReadAsStringAsync();
        var document = JsonDocument.Parse(json);
        var root = document.RootElement;

        var data = root.GetProperty("data");

        Assert.Equal("Healthy", data.GetProperty("status").GetString());

        Assert.Equal("Connected", data.GetProperty("database").GetString());

        var timestamp = data.GetProperty("timestamp").GetDateTime();
        Assert.Equal(DateTimeKind.Utc, timestamp.Kind);

        var errors = root.GetProperty("errors");
        Assert.Equal(0, errors.GetArrayLength());
    }
}
