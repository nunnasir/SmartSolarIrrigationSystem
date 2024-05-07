namespace SmartSolarIrrigationSystem.Mqtt.Models;

public class SensorData
{
    public required string Ph { get; init; }
    public required string Mos { get; init; }
    public required string Nit { get; init; }
    public required string Phos { get; init; }
    public required string Pot { get; init; }
    public required string Water { get; init; }
    public required string Wfr { get; init; }
    public required string N { get; init; }
    public required string F { get; init; }
}

