using Microsoft.AspNetCore.Mvc;
using WMS.Presentation.ActionFilters;
using Service.Contracts;
using Shared.DataTransferObjects.MCompany;

namespace WMS.Presentation.Controllers
{
    [Route("api/companys")]
    [ApiController]
    public class MCompanyController : ControllerBase
    {
        private readonly IServiceManager _service;

        public MCompanyController(IServiceManager service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetMCompanys()
        {
            var companys = await _service.MCompanyService.GetAllMCompanysAsync(trackChanges: false);

            return Ok(companys);
        }

        [HttpGet("{id:int}", Name = "MCompanyById")]
        public async Task<IActionResult> GetMCompany(int id)
        {
            var company = await _service.MCompanyService.GetMCompanyAsync(id, trackChanges: false);
            return Ok(company);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateMCompany([FromBody] MCompanyForCreationDto company)
        {
            var createdMCompany = await _service.MCompanyService.CreateMCompanyAsync(company);

            return CreatedAtRoute("MCompanyById", new { id = createdMCompany.TableId }, createdMCompany);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteMCompany(int id)
        {
            await _service.MCompanyService.DeleteMCompanyAsync(id, trackChanges: false);

            return NoContent();
        }

        [HttpPut("{id:int}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateMCompany(int id, [FromBody] MCompanyForUpdateDto company)
        {
            await _service.MCompanyService.UpdateMCompanyAsync(id, company, trackChanges: true);

            return NoContent();
        }
    }
}
