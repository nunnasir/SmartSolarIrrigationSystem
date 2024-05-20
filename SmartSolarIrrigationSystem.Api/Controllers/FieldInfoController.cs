using Microsoft.AspNetCore.Mvc;
using SmartSolarIrrigationSystem.Api.Mapping;
using SmartSolarIrrigationSystem.Application.Services;
using SmartSolarIrrigationSystem.Contracts.Request;

namespace SmartSolarIrrigationSystem.Api.Controllers;

[ApiController]
public class FieldInfoController : ControllerBase
{
    private readonly IFieldInfoService _fieldInfoService;

    public FieldInfoController(IFieldInfoService fieldInfoService)
    {
        _fieldInfoService = fieldInfoService;
    }

    [HttpPost(ApiEndPoints.FieldInfo.Create)]
    public async Task<IActionResult> Create([FromBody] CreateFieldInfoRequest request, CancellationToken token)
    {
        var fieldInfo = request.MapToFieldInfo();
        await _fieldInfoService.CreateAsync(fieldInfo, token);
        return CreatedAtAction(nameof(Get), new { id = fieldInfo.Id }, fieldInfo);
    }

    [HttpGet(ApiEndPoints.FieldInfo.Get)]
    public async Task<IActionResult> Get([FromRoute] Guid id, CancellationToken token)
    {
        var fieldInfo = await _fieldInfoService.GetByIdAsync(id, token);

        if (fieldInfo is null)
        {
            return NotFound();
        }

        var response = fieldInfo.MapToResponse();
        return Ok(response);
    }

    [HttpGet(ApiEndPoints.FieldInfo.GetAll)]
    public async Task<IActionResult> GetAll(CancellationToken token)
    {
        var movies = await _fieldInfoService.GetAllAsync(token);
        var response = movies.MapToResponse();

        return Ok(response);
    }

    [HttpPut(ApiEndPoints.FieldInfo.Update)]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateFieldInfoRequest request, CancellationToken token)
    {
        var fieldInfo = request.MapToFieldInfo(id);

        var updatedMovie = await _fieldInfoService.UpdateAsync(fieldInfo, token);
        if (updatedMovie is null)
        {
            return NotFound();
        }

        var response = fieldInfo.MapToResponse();
        return Ok(response);
    }

    [HttpDelete(ApiEndPoints.FieldInfo.Delete)]
    public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken token)
    {
        var deleted = await _fieldInfoService.DeleteByIdAsync(id, token);
        if (!deleted)
        {
            return NotFound();
        }

        return Ok();
    }
}
