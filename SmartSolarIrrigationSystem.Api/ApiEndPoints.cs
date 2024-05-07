namespace SmartSolarIrrigationSystem.Api;

public class ApiEndPoints
{
    private const string ApiBase = "api";

    public static class DeviceData
    {
        private const string Base = $"{ApiBase}/deviceData";

        public const string LastData = $"{Base}/lastData";
    }
}
