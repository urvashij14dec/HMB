using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects.Designation;
using WMS.Presentation.ActionFilters;

[ApiController]
[Route("api/designation")]
public class DesignationController : ControllerBase
{
    private readonly IServiceManager _service;

    public DesignationController(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result =
            await _service.DesignationService.GetAllAsync(false);

        return Ok(result);
    }

    [HttpGet("{id:int}", Name = "DesignationById")]
    public async Task<IActionResult> GetById(int id)
    {
        var result =
            await _service.DesignationService.GetByIdAsync(id, false);

        return Ok(result);
    }

    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> Create(
        [FromBody] DesignationForCreationDto dto)
    {
        var result =
            await _service.DesignationService.CreateAsync(dto);

        return CreatedAtRoute(
            "DesignationById",
            new { id = result.TableId },
            result);
    }

    [HttpPut("{id:int}")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> Update(
        int id,
        [FromBody] DesignationForUpdateDto dto)
    {
        await _service.DesignationService
            .UpdateAsync(id, dto, true);

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DesignationService
            .DeleteAsync(id, false);

        return NoContent();
    }
}