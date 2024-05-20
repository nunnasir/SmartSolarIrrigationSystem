namespace SmartSolarIrrigationSystem.Api;

public class ApiEndPoints
{
    private const string ApiBase = "api";

    public static class DeviceData
    {
        private const string Base = $"{ApiBase}/deviceData";

        public const string LastData = $"{Base}/lastData";
    }

    public static class FieldInfo
    {
        private const string Base = $"{ApiBase}/fieldInfo";

        public const string Create = Base;
        public const string Get = $"{Base}/{{id}}";
        public const string GetAll = Base;
        public const string Update = $"{Base}/{{id:Guid}}";
        public const string Delete = $"{Base}/{{id:Guid}}";
    }

    public static class StandardData
    {
        private const string Base = $"{ApiBase}/standardData";

        public const string Create = Base;
        public const string Get = $"{Base}/{{id}}";
        public const string GetByFieldId = $"{Base}/{{fieldId}}";
        public const string GetAll = Base;
        public const string Update = $"{Base}/{{id:Guid}}";
        public const string Delete = $"{Base}/{{id:Guid}}";
    }
}
