using SmartSolarIrrigationSystem.Application.Model;

namespace SmartSolarIrrigationSystem.Application.Services;

public interface IFieldInfoService
{
    Task<bool> CreateAsync(FieldInfo fieldInfo, CancellationToken token = default);
    Task<FieldInfo?> GetByIdAsync(Guid id, CancellationToken token = default);
    Task<IEnumerable<FieldInfo>> GetAllAsync(CancellationToken token = default);
    Task<FieldInfo?> UpdateAsync(FieldInfo fieldInfo, CancellationToken token = default);
    Task<bool> DeleteByIdAsync(Guid id, CancellationToken token = default);
}
