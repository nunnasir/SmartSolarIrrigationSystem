﻿namespace SmartSolarIrrigationSystem.Application.Model;

public class FieldInfo
{
    public required Guid Id { get; init; }
    public required string FieldId { get; set; }
    public required string FieldName { get; set; }
    public DateTime CreatedTime { get; set; }
    public DateTime? UpdatedTime { get; set; }
}
