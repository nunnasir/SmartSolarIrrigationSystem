namespace SmartSolarIrrigationSystem.Contracts.Response;

public class StandardDatasResponse
{
    public required IEnumerable<StandardDataResponse> Items { get; set; } = Enumerable.Empty<StandardDataResponse>();
}
