using Microsoft.Extensions.DependencyInjection;
using SmartSolarIrrigationSystem.Application.Database;
using SmartSolarIrrigationSystem.Application.Repositories;
using SmartSolarIrrigationSystem.Application.Services;

namespace SmartSolarIrrigationSystem.Application;

public static class ApplicationServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddSingleton<IDeviceDataRepository, DeviceDataRepository>();
        services.AddSingleton<IDeviceDataService, DeviceDataService>();

        return services;
    }

    public static IServiceCollection AddDatabase(this IServiceCollection services, string connectionString)
    {
        services.AddSingleton<IDbConnectionFactory>(_ => new MSqlConnectionFactory(connectionString));

        services.AddSingleton<DbInitializer>();

        return services;
    }
}