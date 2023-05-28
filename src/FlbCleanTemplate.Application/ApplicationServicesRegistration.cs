using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace FlbCleanTemplate.Application;

public static class ApplicationServicesRegistration
{
    public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
    {
        // here is where we register all core services (mediatr, automapper, our own mapper, and so on if used)

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        return services;
    }

}
