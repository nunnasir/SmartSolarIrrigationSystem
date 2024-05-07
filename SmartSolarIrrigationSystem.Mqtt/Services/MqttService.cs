using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using MQTTnet;
using MQTTnet.Client;
using SmartSolarIrrigationSystem.Mqtt.Models;
using System.Text;

namespace SmartSolarIrrigationSystem.Mqtt.Services;

public class MqttService : IHostedService
{
    private readonly MqttFactory _mqttFactory;
    private readonly IMqttClient _mqttClient;
    private readonly MqttSettings _mqttSettings;

    public MqttService(IOptions<MqttSettings> mqttSettings)
    {
        _mqttFactory = new MqttFactory();
        _mqttClient = _mqttFactory.CreateMqttClient();
        _mqttSettings = mqttSettings.Value;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        var mqttClientOptions = new MqttClientOptionsBuilder()
                .WithTcpServer(_mqttSettings.BrokerAddress, _mqttSettings.Port)
                .WithCleanSession()
                .Build();

        _mqttClient.ApplicationMessageReceivedAsync += e =>
        {
            Console.WriteLine($"Received application message - {Encoding.UTF8.GetString(e.ApplicationMessage.PayloadSegment)}");

            return Task.CompletedTask;
        };

        await _mqttClient.ConnectAsync(mqttClientOptions, cancellationToken);

        var mqttSubscribeOptions = new MqttClientSubscribeOptionsBuilder()
            .WithTopicFilter(
                f =>
                {
                    f.WithTopic(_mqttSettings.SubscriberTopic);
                })
            .Build();

        await _mqttClient.SubscribeAsync(mqttSubscribeOptions, CancellationToken.None);
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return _mqttClient.DisconnectAsync();
    }
}
