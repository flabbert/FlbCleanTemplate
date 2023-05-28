using FlbCleanTemplate.Application.Interfaces;
using FlbCleanTemplate.Domain.Models;
using MediatR;

namespace FlbCleanTemplate.Application.Features.Queries.GetAllWeatherForecasts;
public class GetAllWeatherForecastQueryHandler : IRequestHandler<GetAllWeatherForecastsQuery, List<WeatherForecast>>
{
    private readonly IWeatherForecastService _weatherForecastService;

    public GetAllWeatherForecastQueryHandler(IWeatherForecastService weatherForecastService)
    {
        _weatherForecastService = weatherForecastService;
    }

    public async Task<List<WeatherForecast>> Handle(GetAllWeatherForecastsQuery request, CancellationToken cancellationToken)
    {
        // remember to implement the actual WeatherForecast service
        return await _weatherForecastService.GetAll();
    }
}
