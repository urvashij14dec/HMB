using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects.Salary;
using WMS.Presentation.ActionFilters;

namespace WMS.Presentation.Controllers
{
    [ApiController]
    [Route("api/salary")]
    public class SalaryController : ControllerBase
    {
        private readonly IServiceManager _service;

        public SalaryController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.SalaryService.GetAllAsync(false);
            return Ok(result);
        }

        [HttpGet("{id:long}", Name = "SalaryById")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _service.SalaryService.GetByIdAsync(id, false);
            return Ok(result);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Create([FromBody] SalaryForCreationDto dto)
        {
            var result = await _service.SalaryService.CreateAsync(dto);
            return CreatedAtRoute("SalaryById", new { id = result.TabId }, result);
        }

        [HttpPut("{id:long}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Update(long id, [FromBody] SalaryForUpdateDto dto)
        {
            await _service.SalaryService.UpdateAsync(id, dto, true);
            return NoContent();
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _service.SalaryService.DeleteAsync(id, false);
            return NoContent();
        }
    }
}
