using Microsoft.AspNetCore.Mvc;
using SmartSolarIrrigationSystem.Api.Mapping;
using SmartSolarIrrigationSystem.Application.Services;
using SmartSolarIrrigationSystem.Contracts.Request;

namespace SmartSolarIrrigationSystem.Api.Controllers;

[ApiController]
public class StandardDataController : ControllerBase
{
    private readonly IStandardDataService _standardDataService;

    public StandardDataController(IStandardDataService standardDataService)
    {
        _standardDataService = standardDataService;
    }

    [HttpPost(ApiEndPoints.StandardData.Create)]
    public async Task<IActionResult> Create([FromBody] CreateStandardDataRequest request, CancellationToken token)
    {
        var standardValue = request.MapToStandardData();
        await _standardDataService.CreateAsync(standardValue, token);
        return CreatedAtAction(nameof(Get), new { id = standardValue.Id }, standardValue);
    }

    [HttpGet(ApiEndPoints.StandardData.Get)]
    public async Task<IActionResult> Get([FromRoute] Guid id, CancellationToken token)
    {
        var standardValue = await _standardDataService.GetByIdAsync(id, token);

        if (standardValue is null)
        {
            return NotFound();
        }

        var response = standardValue.MapToResponse();
        return Ok(response);
    }

    [HttpGet(ApiEndPoints.StandardData.GetByFieldId)]
    public async Task<IActionResult> GetByFieldId([FromRoute] Guid fieldId, CancellationToken token)
    {
        var standardValue = await _standardDataService.GetByFielIdAsync(fieldId, token);

        if (standardValue is null)
        {
            return NotFound();
        }

        var response = standardValue.MapToResponse();
        return Ok(response);
    }

    [HttpGet(ApiEndPoints.StandardData.GetAll)]
    public async Task<IActionResult> GetAll(CancellationToken token)
    {
        var standardValue = await _standardDataService.GetAllAsync(token);
        var response = standardValue.MapToResponse();

        return Ok(response);
    }

    [HttpPut(ApiEndPoints.StandardData.Update)]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateStandardDataRequest request, CancellationToken token)
    {
        var standardValue = request.MapToStandardData(id);

        var updatedstandardValue = await _standardDataService.UpdateAsync(standardValue, token);
        if (updatedstandardValue is null)
        {
            return NotFound();
        }

        var response = standardValue.MapToResponse();
        return Ok(response);
    }

    [HttpDelete(ApiEndPoints.StandardData.Delete)]
    public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken token)
    {
        var deleted = await _standardDataService.DeleteByIdAsync(id, token);
        if (!deleted)
        {
            return NotFound();
        }

        return Ok();
    }
}
