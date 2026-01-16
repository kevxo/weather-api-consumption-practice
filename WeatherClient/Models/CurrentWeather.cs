using System.Text.Json.Serialization;

namespace WeatherClient.Models.CurrentWeather;

public class CurrentWeatherResponse
{
    [JsonPropertyName("name")]
    public string City { get; set; } = string.Empty;

    [JsonPropertyName("country")]
    public string Country { get; set; } = string.Empty;

    [JsonPropertyName("region")]
    public string State { get; set; } = string.Empty;

    [JsonPropertyName("localtime")]
    public string LocalTime { get; set; } = string.Empty;

    [JsonPropertyName("tz_id")]
    public string TimeZone { get; set; } = string.Empty;

    [JsonPropertyName("temp_c")]
    public string Celsius { get; set; } = string.Empty;

    [JsonPropertyName("temp_f")]
    public string Fahrenheit { get; set; } = string.Empty;
}
