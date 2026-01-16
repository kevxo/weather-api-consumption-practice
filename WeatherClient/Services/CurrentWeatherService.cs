using System.Net.Http.Json;
using Microsoft.Extensions.Configuration;
using WeatherClient.Models.CurrentWeather;
using Newtonsoft.Json;

namespace WeatherClient.Services.CurrentWeatherService;

class CurrentWeatherService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public CurrentWeatherService(HttpClient httpclient, IConfiguration configuration)
    {
        _httpClient = httpclient;
        _configuration = configuration;
    }

    public async Task<CurrentWeatherResponse?> GetCurrentWeather(string q)
    {
        var apiKey = _configuration["WeatherAPI:APIKEY"];
        var baseUrl = _configuration["WeatherAPI:BaseURL"];

        var url = $"{baseUrl}?q={q}&key={apiKey}";

        var request = await _httpClient.GetAsync(url);

        if (!request.IsSuccessStatusCode)
        {
            Console.WriteLine($"Error: {request.StatusCode}");
            return null;
        }

        var response = await request.Content.ReadAsStringAsync();

        CurrentWeatherResponse currentWeather = new CurrentWeatherResponse();

        var jsonResponse = JsonConvert.DeserializeObject<Newtonsoft.Json.Linq.JObject>(response);
       
        currentWeather.City = jsonResponse?["location"]?["name"]?.ToString() ?? string.Empty;
        currentWeather.Country = jsonResponse?["location"]?["country"]?.ToString() ?? string.Empty;
        currentWeather.State = jsonResponse?["location"]?["region"]?.ToString() ?? string.Empty;
        currentWeather.LocalTime = jsonResponse?["location"]?["localtime"]?.ToString() ?? string.Empty;
        currentWeather.TimeZone = jsonResponse?["location"]?["tz_id"]?.ToString() ?? string.Empty;
        currentWeather.Celsius = jsonResponse?["current"]?["temp_c"]?.ToString() ?? string.Empty;
        currentWeather.Fahrenheit = jsonResponse?["current"]?["temp_f"]?.ToString() ?? string.Empty;

        return currentWeather;    
    }
}
