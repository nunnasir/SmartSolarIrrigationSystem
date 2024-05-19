using SmartSolarIrrigationSystem.Application.Model;

namespace SmartSolarIrrigationSystem.Application.Repositories;

public interface IFieldInfoRepository
{
    Task<bool> CreateAsync(FieldInfo fieldInfo, CancellationToken token = default);
    Task<FieldInfo?> GetByIdAsync(Guid id, CancellationToken token = default);
    Task<IEnumerable<FieldInfo>> GetAllAsync(CancellationToken token = default);
    Task<bool> UpdateAsync(FieldInfo fieldInfo, CancellationToken token = default);
    Task<bool> DeleteByIdAsync(Guid id, CancellationToken token = default);
}
