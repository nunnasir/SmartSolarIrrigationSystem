using Microsoft.Extensions.DependencyInjection;
using SmartSolarIrrigationSystem.Mqtt.Services;

namespace SmartSolarIrrigationSystem.Mqtt;

public static class MqttServiceCollectionExtensions
{
    public static IServiceCollection AddMqtt(this IServiceCollection services)
    {
        services.AddHostedService<MqttService>();

        return services;
    }
}
