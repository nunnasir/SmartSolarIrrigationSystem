namespace SmartSolarIrrigationSystem.Contracts.Response;

public class FieldsInfoResponse
{
    public required IEnumerable<FieldInfoResponse> Items { get; set; } = Enumerable.Empty<FieldInfoResponse>();
}
