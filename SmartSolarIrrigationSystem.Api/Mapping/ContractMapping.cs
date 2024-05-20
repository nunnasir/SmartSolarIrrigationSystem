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

    public static StandardValue MapToStandardData(this CreateStandardDataRequest request)
    {
        return new StandardValue
        {
            Id = Guid.NewGuid(),
            FieldInfoId = request.FieldInfoId,
            Ph = request.Ph,
            Mos = request.Mos,
            Nit = request.Nit,
            Phos = request.Phos,
            Pot = request.Pot,
            Water = request.Water,
            Wfr = request.Wfr,
            Node = request.Node,
            CreatedTime = DateTime.UtcNow,
        };
    }

    public static StandardValue MapToStandardData(this UpdateStandardDataRequest request, Guid id)
    {
        return new StandardValue
        {
            Id = id,
            Ph = request.Ph,
            Mos = request.Mos,
            Nit = request.Nit,
            Phos = request.Phos,
            Pot = request.Pot,
            Water = request.Water,
            Wfr = request.Wfr,
            UpdatedTime = DateTime.UtcNow,
        };
    }

    public static StandardDataResponse MapToResponse(this StandardValue standardValue)
    {
        return new StandardDataResponse
        {
            Id = standardValue.Id,
            FieldInfoId = standardValue.FieldInfoId,
            FieldId = standardValue.FieldId,
            FieldName = standardValue.FieldName,
            Ph = standardValue.Ph,
            Mos = standardValue.Mos,
            Nit = standardValue.Nit,
            Phos = standardValue.Phos,
            Pot = standardValue.Pot,
            Water = standardValue.Water,
            Wfr = standardValue.Wfr,
            Node = standardValue.Node,
        };
    }

    public static StandardDatasResponse MapToResponse(this IEnumerable<StandardValue> standardValues)
    {
        return new StandardDatasResponse
        {
            Items = standardValues.Select(MapToResponse)
        };
    }
}
