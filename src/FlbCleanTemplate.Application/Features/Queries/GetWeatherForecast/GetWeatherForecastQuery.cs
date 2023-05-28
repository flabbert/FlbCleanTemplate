using FlbCleanTemplate.Domain.Models;
using MediatR;

namespace FlbCleanTemplate.Application.Features.Queries.GetWeatherForecast;
public class GetWeatherForecastQuery : IRequest<WeatherForecast>
{
    public GetWeatherForecastQuery(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}
