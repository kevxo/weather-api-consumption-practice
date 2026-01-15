namespace WeatherClient.Models;

public class CurrentWeather
{
    public string City { get; set; }
    public string Country { get; set; }
    public string State { get; set; }
    public string LocalTime { get; set; }
    public string TimeZone { get; set; }
    public string Celsius { get; set; }
    public string Fahrenheit { get; set; }

    public CurrentWeather(
        string city, 
        string country, 
        string state = "", 
        string localTime, 
        string timeZone,
        string celsius,
        string fahrenheit
    )
    {
        City = city;
        Country = country;
        State = state;
        LocalTime = localTime;
        TimeZone = timeZone;
        Celsius = celsius;
        Fahrenheit = fahrenheit;
    }
}