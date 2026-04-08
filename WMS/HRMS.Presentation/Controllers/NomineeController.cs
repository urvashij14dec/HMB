using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects.Nominee;
using WMS.Presentation.ActionFilters;

namespace WMS.Presentation.Controllers
{
    [ApiController]
    [Route("api/nominee")]
    public class NomineeController : ControllerBase
    {
        private readonly IServiceManager _service;

        public NomineeController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result =
                await _service.NomineeService.GetAllAsync(false);

            return Ok(result);
        }

        [HttpGet("{id:int}", Name = "NomineeById")]
        public async Task<IActionResult> GetById(int id)
        {
            var result =
                await _service.NomineeService.GetByIdAsync(id, false);

            return Ok(result);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Create(
            [FromBody] NomineeForCreationDto dto)
        {
            var result =
                await _service.NomineeService.CreateAsync(dto);

            return CreatedAtRoute(
                "NomineeById",
                new { id = result.RowId },
                result);
        }

        [HttpPut("{id:int}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Update(
            int id,
            [FromBody] NomineeForUpdateDto dto)
        {
            await _service.NomineeService
                .UpdateAsync(id, dto, true);

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.NomineeService
                .DeleteAsync(id, false);

            return NoContent();
        }
    }
}
