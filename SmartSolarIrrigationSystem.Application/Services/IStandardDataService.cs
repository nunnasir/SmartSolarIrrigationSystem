using SmartSolarIrrigationSystem.Application.Model;

namespace SmartSolarIrrigationSystem.Application.Services;

public interface IStandardDataService
{
    Task<bool> CreateAsync(StandardValue standardValue, CancellationToken token = default);
    Task<StandardValue?> GetByIdAsync(Guid id, CancellationToken token = default);
    Task<IEnumerable<StandardValue>> GetAllAsync(CancellationToken token = default);
    Task<StandardValue?> UpdateAsync(StandardValue standardValue, CancellationToken token = default);
    Task<bool> DeleteByIdAsync(Guid id, CancellationToken token = default);
    Task<StandardValue?> GetByFielIdAsync(Guid fieldId, CancellationToken token = default);
}
