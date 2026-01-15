using WeatherClient.Models.CurrentWeather;

namespace WeatherClient.APIs;

class CurrentWeatherAPI
{
    private string APIKEY = "336a9cf9eaa04734ab2191831261301";
    private string URL = "https://api.weatherapi.com/v1/current.json";

    public async Task<CurrentWeather> GetCurrentWeather(string q)
    {
        
    }


}