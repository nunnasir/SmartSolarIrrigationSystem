namespace SmartSolarIrrigationSystem.Application.Model;

public class StandardValue
{
    public required Guid Id { get; init; }
    public required Guid FieldInfoId { get; init; }
    public required string FieldId { get; set; }
    public required string FieldName { get; set; }
    public required decimal Ph { get; set; }
    public required decimal Mos { get; set; }
    public required decimal Nit { get; set; }
    public required decimal Phos { get; set; }
    public required decimal Pot { get; set; }
    public required decimal Water { get; set; }
    public required decimal Wfr { get; set; }
    public required decimal Node { get; set; }
}
