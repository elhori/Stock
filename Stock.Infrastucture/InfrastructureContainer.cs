using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Stock.Application.Contracts.Repositories;
using System;
using Microsoft.EntityFrameworkCore;
using Stock.Infrastructure.Persistence;
using Stock.Infrastructure.Persistence.Repositories;

namespace Stock.Infrastructure;

public static class InfrastructureContainer
{
    public static IServiceCollection AddInfraServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContextFactory<AppDbContext>(options =>
            options.UseSqlServer(config.GetConnectionString("default")));

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}