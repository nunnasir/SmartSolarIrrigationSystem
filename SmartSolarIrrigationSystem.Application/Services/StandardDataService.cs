using FluentValidation;
using SmartSolarIrrigationSystem.Application.Model;
using SmartSolarIrrigationSystem.Application.Repositories;

namespace SmartSolarIrrigationSystem.Application.Services;

public class StandardDataService : IStandardDataService
{
    private readonly IStandardDataRepository _standardDataRepository;

    public StandardDataService(IStandardDataRepository standardDataRepository)
    {
        _standardDataRepository = standardDataRepository;
    }

    public async Task<bool> CreateAsync(StandardValue standardValue, CancellationToken token = default)
    {
        return await _standardDataRepository.CreateAsync(standardValue, token);
    }

    public async Task<bool> DeleteByIdAsync(Guid id, CancellationToken token = default)
    {
        return await _standardDataRepository.DeleteByIdAsync(id, token);
    }

    public async Task<IEnumerable<StandardValue>> GetAllAsync(CancellationToken token = default)
    {
        return await _standardDataRepository.GetAllAsync(token);
    }

    public async Task<StandardValue?> GetByFielIdAsync(Guid fieldId, CancellationToken token = default)
    {
        return await _standardDataRepository.GetByFielIdAsync(fieldId, token);
    }

    public async Task<StandardValue?> GetByIdAsync(Guid id, CancellationToken token = default)
    {
        return await _standardDataRepository.GetByIdAsync(id, token);
    }

    public async Task<StandardValue?> UpdateAsync(StandardValue standardValue, CancellationToken token = default)
    {
        await _standardDataRepository.UpdateAsync(standardValue, token);

        return standardValue;
    }
}
