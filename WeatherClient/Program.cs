using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using WeatherClient.Services.CurrentWeatherService;

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

var services = new ServiceCollection();
services.AddSingleton<IConfiguration>(configuration);
services.AddHttpClient<CurrentWeatherService>();

var provider = services.BuildServiceProvider();
var currentWeatherService = provider.GetRequiredService<CurrentWeatherService>();

Console.WriteLine("Enter Pass US Zipcode, UK Postcode, Canada Postalcode, IP address, Latitude/Longitude (decimal degree) or city name.");
var location = Console.ReadLine();

var currentWeather = await currentWeatherService.GetCurrentWeather(location!);

if (currentWeather != null)
{
    Console.WriteLine($"City -> {currentWeather.City}");
    Console.WriteLine($"Country -> {currentWeather.Country}");
    Console.WriteLine($"State -> {currentWeather.State}");
    Console.WriteLine($"Local Time -> {currentWeather.LocalTime}");
    Console.WriteLine($"Time Zone -> {currentWeather.TimeZone}");
    Console.WriteLine($"Celsius -> {currentWeather.Celsius}");
    Console.WriteLine($"Fahrenheit -> {currentWeather.Fahrenheit}");
}
