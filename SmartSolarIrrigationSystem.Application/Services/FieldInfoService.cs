using SmartSolarIrrigationSystem.Application.Model;
using SmartSolarIrrigationSystem.Application.Repositories;

namespace SmartSolarIrrigationSystem.Application.Services;

public class FieldInfoService : IFieldInfoService
{
    private readonly IFieldInfoRepository _fieldInfoRepository;

    public FieldInfoService(IFieldInfoRepository fieldInfoRepository)
    {
        _fieldInfoRepository = fieldInfoRepository;
    }

    public async Task<bool> CreateAsync(FieldInfo fieldInfo, CancellationToken token = default)
    {
        return await _fieldInfoRepository.CreateAsync(fieldInfo);
    }

    public async Task<bool> DeleteByIdAsync(Guid id, CancellationToken token = default)
    {
        return await _fieldInfoRepository.DeleteByIdAsync(id);
    }

    public async Task<IEnumerable<FieldInfo>> GetAllAsync(CancellationToken token = default)
    {
        return await _fieldInfoRepository.GetAllAsync(token);
    }

    public async Task<FieldInfo?> GetByIdAsync(Guid id, CancellationToken token = default)
    {
        return await _fieldInfoRepository.GetByIdAsync(id, token);
    }

    public async Task<FieldInfo?> UpdateAsync(FieldInfo fieldInfo, CancellationToken token = default)
    {
        await _fieldInfoRepository.UpdateAsync(fieldInfo, token);

        return fieldInfo;
    }
}
