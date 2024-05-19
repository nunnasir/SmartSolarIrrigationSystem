namespace SmartSolarIrrigationSystem.Contracts.Response;

public class FieldInfoResponse
{
    public required Guid Id { get; init; }
    public required string FieldId { get; init; }
    public required string Name { get; init; }
}
