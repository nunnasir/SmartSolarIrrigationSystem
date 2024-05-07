using SmartSolarIrrigationSystem.Application.Model;

namespace SmartSolarIrrigationSystem.Application.Services;

public interface IDeviceDataService
{
    Task<bool> CreateAsync(DeviceData deviceData, CancellationToken token = default);
    Task<DeviceData?> GetLastData(CancellationToken token = default);
}
