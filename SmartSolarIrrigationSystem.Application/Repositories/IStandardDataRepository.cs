using SmartSolarIrrigationSystem.Application.Model;

namespace SmartSolarIrrigationSystem.Application.Repositories;

public interface IStandardDataRepository
{
    Task<bool> CreateAsync(StandardValue standardValue, CancellationToken token = default);
    Task<StandardValue?> GetByIdAsync(Guid id, CancellationToken token = default);
    Task<IEnumerable<StandardValue>> GetAllAsync(CancellationToken token = default);
    Task<bool> UpdateAsync(StandardValue standardValue, CancellationToken token = default);
    Task<bool> DeleteByIdAsync(Guid id, CancellationToken token = default);
    Task<StandardValue?> GetByFielIdAsync(Guid fieldId, CancellationToken token = default);
}
