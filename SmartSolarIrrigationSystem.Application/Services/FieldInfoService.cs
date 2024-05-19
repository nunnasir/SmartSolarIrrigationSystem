using FluentValidation;
using SmartSolarIrrigationSystem.Application.Model;

namespace SmartSolarIrrigationSystem.Application.Services;

public class FieldInfoService : IFieldInfoService
{
    private readonly IFieldInfoService _fieldInfoService;
    private readonly IValidator<FieldInfo> _fieldInfoValidator;

    public FieldInfoService(IFieldInfoService fieldInfoService, IValidator<FieldInfo> fieldInfoValidator)
    {
        _fieldInfoService = fieldInfoService;
        _fieldInfoValidator = fieldInfoValidator;
    }

    public async Task<bool> CreateAsync(FieldInfo fieldInfo, CancellationToken token = default)
    {
        await _fieldInfoValidator.ValidateAndThrowAsync(fieldInfo, cancellationToken: token);

        return await _fieldInfoService.CreateAsync(fieldInfo);
    }

    public async Task<bool> DeleteByIdAsync(Guid id, CancellationToken token = default)
    {
        return await _fieldInfoService.DeleteByIdAsync(id);
    }

    public async Task<IEnumerable<FieldInfo>> GetAllAsync(CancellationToken token = default)
    {
        return await _fieldInfoService.GetAllAsync(token);
    }

    public async Task<FieldInfo?> GetByIdAsync(Guid id, CancellationToken token = default)
    {
        return await _fieldInfoService.GetByIdAsync(id, token);
    }

    public async Task<FieldInfo?> UpdateAsync(FieldInfo fieldInfo, CancellationToken token = default)
    {
        await _fieldInfoValidator.ValidateAndThrowAsync(fieldInfo, cancellationToken: token);

        await _fieldInfoService.UpdateAsync(fieldInfo, token);

        return fieldInfo;
    }
}
