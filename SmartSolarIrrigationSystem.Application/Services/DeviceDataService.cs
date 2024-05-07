using SmartSolarIrrigationSystem.Application.Model;
using SmartSolarIrrigationSystem.Application.Repositories;

namespace SmartSolarIrrigationSystem.Application.Services;

public class DeviceDataService : IDeviceDataService
{
    private readonly IDeviceDataRepository _deviceDataRepository;

    public DeviceDataService(IDeviceDataRepository deviceDataRepository)
    {
        _deviceDataRepository = deviceDataRepository;
    }

    public async Task<bool> CreateAsync(DeviceData deviceData, CancellationToken token = default)
    {
        return await _deviceDataRepository.CreateAsync(deviceData, token);
    }
}
