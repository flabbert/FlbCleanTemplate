using FlbCleanTemplate.Application.Interfaces;
using FlbCleanTemplate.Domain.Models;
using MediatR;

namespace FlbCleanTemplate.Application.Features.Queries.GetWeatherForecast;
public class GetWeatherForecastQueryHandler : IRequestHandler<GetWeatherForecastQuery, WeatherForecast>
{
    private readonly IWeatherForecastService _weatherForecastInterface;

    public GetWeatherForecastQueryHandler(IWeatherForecastService weatherForecastInterface)
    {
        _weatherForecastInterface = weatherForecastInterface;
    }

    public async Task<WeatherForecast> Handle(GetWeatherForecastQuery request, CancellationToken cancellationToken)
    {
        // remember to implement the actual WeatherForecast service
        return await _weatherForecastInterface.Get(request.Id);
    }
}
