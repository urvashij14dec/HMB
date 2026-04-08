using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects.Employee;
using WMS.Presentation.ActionFilters;

[ApiController]
[Route("api/employee")]
public class EmployeeController : ControllerBase
{
    private readonly IServiceManager _service;

    public EmployeeController(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result =
            await _service.EmployeeService.GetAllAsync(false);

        return Ok(result);
    }

    [HttpGet("{id}", Name = "EmployeeById")]
    public async Task<IActionResult> GetById(string id)
    {
        var result =
            await _service.EmployeeService.GetByIdAsync(id, false);

        return Ok(result);
    }

    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> Create(
        [FromBody] EmployeeForCreationDto dto)
    {
        var result =
            await _service.EmployeeService.CreateAsync(dto);

        return CreatedAtRoute(
            "EmployeeById",
            new { id = result.Ecode },
            result);
    }

    [HttpPut("{id}")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> Update(
        string id,
        [FromBody] EmployeeForUpdateDto dto)
    {
        await _service.EmployeeService
            .UpdateAsync(id, dto, true);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await _service.EmployeeService
            .DeleteAsync(id, false);

        return NoContent();
    }
}
