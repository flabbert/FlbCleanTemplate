using FlbCleanTemplate.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace FlbCleanTemplate.WeatherService.Mock;

public static class MockWeatherServiceRegistrations
{
    public static IServiceCollection RegisterWeatherServices(this IServiceCollection services)
    {
        services.AddScoped<IWeatherForecastService, MockWeatherService>();
        return services;
    }
}
