using System.Net.Http.Json;
using Microsoft.Extensions.Configuration;
using WeatherClient.Models.CurrentWeather;

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

        var response = await _httpClient.GetAsync(url);

        if (!response.IsSuccessStatusCode)
        {
            Console.WriteLine($"Error: {response.StatusCode}");
            return null;
        }

        Console.WriteLine(response.Content);
        return await response.Content.ReadFromJsonAsync<CurrentWeatherResponse>();        
    }
}
