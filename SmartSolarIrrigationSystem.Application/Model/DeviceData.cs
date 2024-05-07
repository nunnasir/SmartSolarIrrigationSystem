namespace SmartSolarIrrigationSystem.Application.Model;

public class DeviceData
{
    public required Guid Id { get; init; }
    public required decimal Ph { get; set; }
    public required decimal Mos { get; set; }
    public required decimal Nit { get; set; }
    public required decimal Phos { get; set; }
    public required decimal Pot { get; set; }
    public required decimal Water { get; set; }
    public required decimal Wfr { get; set; }
    public required decimal Node { get; set; }
    public required decimal Sensor { get; set; }
    public required DateTime CreatedTime { get; init; }
}
