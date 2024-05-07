using SmartSolarIrrigationSystem.Application.Model;

namespace SmartSolarIrrigationSystem.Application.Repositories;

public interface IDeviceDataRepository
{
    Task<bool> CreateAsync(DeviceData deviceData, CancellationToken token = default);
    Task<DeviceData?> GetLastData(CancellationToken token = default);
}
