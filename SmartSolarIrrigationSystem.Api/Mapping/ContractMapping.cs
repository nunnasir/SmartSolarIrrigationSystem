using SmartSolarIrrigationSystem.Application.Model;
using SmartSolarIrrigationSystem.Contracts.Request;
using SmartSolarIrrigationSystem.Contracts.Response;

namespace SmartSolarIrrigationSystem.Api.Mapping;

public static class ContractMapping
{
    public static FieldInfo MapToFieldInfo(this CreateFieldInfoRequest request)
    {
        return new FieldInfo
        {
            Id = Guid.NewGuid(),
            FieldId = request.FieldId,
            FieldName = request.FieldName,
            CreatedTime = DateTime.UtcNow,
        };
    }

    public static FieldInfo MapToFieldInfo(this UpdateFieldInfoRequest request, Guid id)
    {
        return new FieldInfo
        {
            Id = id,
            FieldId = request.FieldId,
            FieldName = request.FieldName,
            UpdatedTime = DateTime.UtcNow,
        };
    }

    public static FieldInfoResponse MapToResponse(this FieldInfo fieldInfo)
    {
        return new FieldInfoResponse
        {
            Id = fieldInfo.Id,
            FieldId = fieldInfo.FieldId,
            Name = fieldInfo.FieldName
        };
    }

    public static FieldsInfoResponse MapToResponse(this IEnumerable<FieldInfo> fieldInfoes)
    {
        return new FieldsInfoResponse
        {
            Items = fieldInfoes.Select(MapToResponse)
        };
    }
}
