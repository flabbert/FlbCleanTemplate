using FlbCleanTemplate.Application.Interfaces;
using FlbCleanTemplate.WeatherService.Mock;
using Xunit.Microsoft.DependencyInjection;

namespace FlbCleanTemplate.Tests.Fixtures;
public class TestFixture : TestBedFixture
{
    protected override ValueTask DisposeAsyncCore()
        => new();


    // this is where we register our mocks
    // alternative is to not have mocks, but use a library like Moq
    // https://github.com/Moq/moq4/wiki/Quickstart
    protected override void AddServices(IServiceCollection services, IConfiguration? configuration)
    {
        services.AddScoped<IWeatherForecastService, MockWeatherService>();
    }

    protected override IEnumerable<TestAppSettings> GetTestAppSettings()
    {
        yield return new() { Filename = "appsettings.Test.json", IsOptional = false };
    }
}