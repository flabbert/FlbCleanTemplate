using FlbCleanTemplate.Domain.Models;

namespace FlbCleanTemplate.Application.Interfaces;
public interface IWeatherForecastService
{
    public Task<WeatherForecast> Get(int id);
    public Task<List<WeatherForecast>> GetAll();
}
