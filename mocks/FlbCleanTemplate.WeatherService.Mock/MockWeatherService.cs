using System.Text.RegularExpressions;
using FlbCleanTemplate.Application.Interfaces;
using FlbCleanTemplate.Domain.Models;

namespace FlbCleanTemplate.WeatherService.Mock;
public class MockWeatherService : IWeatherForecastService
{
    public Task<WeatherForecast> Get(int id)
    {
        var forecast = new WeatherForecast();

        // we purposefully do not use object initializer
        // as it is harder to track null errors when using it
        forecast.Id = id;

        return Task.FromResult(forecast);
    }

    public Task<List<WeatherForecast>> GetAll()
    {
        var forecasts = new List<WeatherForecast>();

        const int limit = 5;
        var counter = 0;
        while (counter <= limit)
        {
            counter++;
            // we generate a random id, and inject it with constructor initialization
            forecasts.Add(new WeatherForecast(new Random(12345).Next()));
        }

        return Task.FromResult(forecasts);
    }
}
