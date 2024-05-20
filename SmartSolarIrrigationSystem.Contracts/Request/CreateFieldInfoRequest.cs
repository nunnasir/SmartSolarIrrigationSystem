namespace SmartSolarIrrigationSystem.Contracts.Request;

public class CreateFieldInfoRequest
{
    public required string FieldId { get; init; }
    public required string FieldName { get; init; }
}


