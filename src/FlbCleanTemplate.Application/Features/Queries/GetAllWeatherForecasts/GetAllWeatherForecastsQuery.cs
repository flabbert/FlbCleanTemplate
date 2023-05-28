using FlbCleanTemplate.Domain.Models;
using MediatR;

namespace FlbCleanTemplate.Application.Features.Queries.GetAllWeatherForecasts;
public class GetAllWeatherForecastsQuery : IRequest<List<WeatherForecast>>
{

}
