using FlbCleanTemplate.Application.Interfaces;
using FlbCleanTemplate.Domain.Models;
using FlbCleanTemplate.Tests.Fixtures;
using Shouldly;


namespace FlbCleanTemplate.Tests;

[CollectionDefinition("Dependency Injection")]
public class IntegrationTests : TestBed<TestFixture>
{

    public IntegrationTests(ITestOutputHelper testOutputHelper, TestFixture fixture)
        : base(testOutputHelper, fixture)
    {
    }

    [Fact]
    public void GetWeatherForecastTest()
    {
        var weatherForecastService = _fixture.GetService<IWeatherForecastService>(_testOutputHelper);
        var result = weatherForecastService?.Get(1).Result;

        result.ShouldBeOfType<WeatherForecast>();

        Assert.True(result.Id == 1);
    }
}