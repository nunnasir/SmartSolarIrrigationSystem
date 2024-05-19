namespace SmartSolarIrrigationSystem.Contracts.Request;

public class UpdateFieldInfoRequest
{
    public required string FieldId { get; init; }
    public required string FieldName { get; init; }
}
