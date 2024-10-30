using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Stock.Application;

public static class ApplicationContainer
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        return services;
    }
}