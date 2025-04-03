using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

[Route("api/weather")]
[ApiController]
public class WeatherController : ControllerBase
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<WeatherController> _logger;
    private readonly string _apiKey = "a09fe4d35a0943edb18182338250104";
    private readonly string _baseUrl = "http://api.weatherapi.com/v1/forecast.json";

    public WeatherController(HttpClient httpClient, ILogger<WeatherController> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetWeather([FromQuery] string location)
    {
        if (string.IsNullOrEmpty(location))
        {
            _logger.LogWarning("Location parameter is missing");
            return BadRequest(new { error = "Parameter 'location' is missing." });
        }

        string requestUrl = $"{_baseUrl}?key={_apiKey}&q={location}&days=4";

        try
        {
            _logger.LogInformation($"Fetching weather data for location: {location}");
            var response = await _httpClient.GetAsync(requestUrl);

            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError($"Weather API returned error: {response.StatusCode}");
                return StatusCode((int)response.StatusCode, new { error = "Failed to fetch weather data", details = await response.Content.ReadAsStringAsync() });
            }

            var content = await response.Content.ReadAsStringAsync();
            return Ok(content);
        }
        catch (HttpRequestException ex)
        {
            _logger.LogError(ex, "Error fetching weather data");
            return StatusCode(500, new { error = "Failed to fetch weather data", details = ex.Message });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unexpected error occurred");
            return StatusCode(500, new { error = "An unexpected error occurred", details = ex.Message });
        }
    }
}
