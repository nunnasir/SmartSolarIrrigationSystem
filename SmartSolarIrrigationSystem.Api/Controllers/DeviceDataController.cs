using Microsoft.AspNetCore.Mvc;
using SmartSolarIrrigationSystem.Application.Services;

namespace SmartSolarIrrigationSystem.Api.Controllers;

[ApiController]
public class DeviceDataController : ControllerBase
{
    private readonly IDeviceDataService _deviceDataService;

    public DeviceDataController(IDeviceDataService deviceDataService)
    {
        _deviceDataService = deviceDataService;
    }

    [HttpGet(ApiEndPoints.DeviceData.LastData)]
    public async Task<IActionResult> Get(CancellationToken token)
    {
        var deviceData = await _deviceDataService.GetLastData(token);
            
        if (deviceData is null)
        {
            return NotFound();
        }

        return Ok(deviceData);
    }
}
