using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects.FamilyDetail;
using WMS.Presentation.ActionFilters;

namespace WMS.Presentation.Controllers
{
    [ApiController]
    [Route("api/familydetail")]
    public class FamilyDetailController : ControllerBase
    {
        private readonly IServiceManager _service;

        public FamilyDetailController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result =
                await _service.FamilyDetailService.GetAllAsync(false);

            return Ok(result);
        }

        [HttpGet("{id:int}", Name = "FamilyDetailById")]
        public async Task<IActionResult> GetById(int id)
        {
            var result =
                await _service.FamilyDetailService.GetByIdAsync(id, false);

            return Ok(result);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Create(
            [FromBody] FamilyDetailForCreationDto dto)
        {
            var result =
                await _service.FamilyDetailService.CreateAsync(dto);

            return CreatedAtRoute(
                "FamilyDetailById",
                new { id = result.RowId },
                result);
        }

        [HttpPut("{id:int}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Update(
            int id,
            [FromBody] FamilyDetailForUpdateDto dto)
        {
            await _service.FamilyDetailService
                .UpdateAsync(id, dto, true);

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.FamilyDetailService
                .DeleteAsync(id, false);

            return NoContent();
        }
    }
}
