namespace SmartSolarIrrigationSystem.Contracts.Request;

public class CreateStandardDataRequest
{
    public required Guid FieldInfoId { get; init; }
    public required decimal Ph { get; set; }
    public required decimal Mos { get; set; }
    public required decimal Nit { get; set; }
    public required decimal Phos { get; set; }
    public required decimal Pot { get; set; }
    public required decimal Water { get; set; }
    public required decimal Wfr { get; set; }
    public required decimal Node { get; set; }
}
