using FlbCleanTemplate;
using FlbCleanTemplate.Application;
using FlbCleanTemplate.WeatherService.Mock;
// TODO: this mock should be removed from this project and replaced with a real interface
using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Host.UseSerilog((ctx, lc) =>
    {
        lc.Enrich.FromLogContext();
        lc.WriteTo.Console(theme: AnsiConsoleTheme.Sixteen, applyThemeToRedirectedOutput: true, outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}");
    }
);
// Add services to the container.


// Load environment variables from .env
// The string specifies the path of the .env file
// .env file should only be used in development
// Use real environment variables in your CI/CD pipeline for hosted services (Staging, Production, FeatureBuilds)
// Or implement Azure Keyvault or similar to inject directly into appsettings
var dotenv = Path.Combine(Directory.GetCurrentDirectory(), "../../.env");

if (File.Exists(dotenv)) DotEnv.Load(dotenv);


// TODO: this mock should be removed from this project and replaced with a real interface
// the command that registers the service is purposefully named the same as any real implementation
// so that you only need to replace the import
// this is a semantic call, and it may be smarter to name it RegisterMockWeatherServices to reduce ambiguity
builder.Services.RegisterWeatherServices();
builder.Services.AddOptions();
builder.Configuration.AddEnvironmentVariables();
builder.Services.RegisterApplicationServices();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
