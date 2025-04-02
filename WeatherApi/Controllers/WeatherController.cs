using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

[Route("api/weather")]
[ApiController]
public class WeatherController : ControllerBase
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey = "a09fe4d35a0943edb18182338250104";
    private readonly string _baseUrl = "http://api.weatherapi.com/v1/forecast.json";

    public WeatherController(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    [HttpGet]
    public async Task<IActionResult> GetWeather([FromQuery] string location)
    {
        if (string.IsNullOrEmpty(location))
        {
            return BadRequest(new { error = "Parameter 'location' is missing." });
        }

        string requestUrl = $"{_baseUrl}?key={_apiKey}&q={location}&days=4";

        try
        {
            var response = await _httpClient.GetStringAsync(requestUrl);
            return Ok(response);
        }
        catch (HttpRequestException ex)
        {
            return StatusCode(500, new { error = "Failed to fetch weather data.", details = ex.Message });
        }
    }
}
