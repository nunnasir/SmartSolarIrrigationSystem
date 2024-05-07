using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using MQTTnet;
using MQTTnet.Client;
using Newtonsoft.Json;
using SmartSolarIrrigationSystem.Application.Model;
using SmartSolarIrrigationSystem.Application.Services;
using SmartSolarIrrigationSystem.Mqtt.Models;
using System.Text;

namespace SmartSolarIrrigationSystem.Mqtt.Services;

public class MqttService : IHostedService
{
    private readonly MqttFactory _mqttFactory;
    private readonly IMqttClient _mqttClient;
    private readonly MqttSettings _mqttSettings;
    private readonly IDeviceDataService _deviceDataService;

    public MqttService(IOptions<MqttSettings> mqttSettings, IDeviceDataService deviceDataService)
    {
        _mqttFactory = new MqttFactory();
        _mqttClient = _mqttFactory.CreateMqttClient();
        _mqttSettings = mqttSettings.Value;
        _deviceDataService = deviceDataService;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        var mqttClientOptions = new MqttClientOptionsBuilder()
                .WithTcpServer(_mqttSettings.BrokerAddress, _mqttSettings.Port)
                .WithCleanSession()
                .Build();

        _mqttClient.ApplicationMessageReceivedAsync += async e =>
        {
            var jsonDataString = Encoding.UTF8.GetString(e.ApplicationMessage.PayloadSegment);
            var sensorData = JsonConvert.DeserializeObject<SensorData>(jsonDataString);

            if (sensorData != null)
            {
                var deviceData = new DeviceData
                {
                    Ph = decimal.Parse(sensorData.Ph),
                    Mos = decimal.Parse(sensorData.Mos),
                    Nit = decimal.Parse(sensorData.Nit),
                    Phos = decimal.Parse(sensorData.Phos),
                    Pot = decimal.Parse(sensorData.Pot),
                    Water = decimal.Parse(sensorData.Water),
                    Wfr = decimal.Parse(sensorData.Wfr),
                    Node = decimal.Parse(sensorData.N),
                    Sensor = decimal.Parse(sensorData.F),
                    CreatedTime = DateTime.Now,
                    Id = Guid.NewGuid()
                };

                await _deviceDataService.CreateAsync(deviceData);
            }
            //Console.WriteLine($"Received application message - {Encoding.UTF8.GetString(e.ApplicationMessage.PayloadSegment)}");

            return;
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
