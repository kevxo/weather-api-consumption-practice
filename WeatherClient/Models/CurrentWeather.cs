namespace WeatherClient.Models.CurrentWeather;

public class CurrentWeatherResponse
{
    public string City { get; set; } = string.Empty;

    public string Country { get; set; } = string.Empty;

    public string State { get; set; } = string.Empty;

    public string LocalTime { get; set; } = string.Empty;

    public string TimeZone { get; set; } = string.Empty;

    public string Celsius { get; set; } = string.Empty;

    public string Fahrenheit { get; set; } = string.Empty;
}
