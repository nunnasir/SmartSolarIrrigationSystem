namespace SmartSolarIrrigationSystem.Mqtt.Models;

public class MqttSettings
{
    public required string BrokerAddress { get; init; }
    public required int Port { get; init; }
    public required string ClientId { get; init; }
    public required string SubscriberTopic { get; init; }
    public required string PublisherTopic { get; init; }
}
