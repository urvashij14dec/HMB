using Microsoft.AspNetCore.Mvc;
using WMS.Presentation.ActionFilters;
using Service.Contracts;
using Shared.DataTransferObjects.Organisation;

namespace WMS.Presentation.Controllers
{
    [Route("api/organisations")]
    [ApiController]
    public class OrganisationController : ControllerBase
    {
        private readonly IServiceManager _service;

        public OrganisationController(IServiceManager service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetOrganisations()
        {
            var organisations = await _service.OrganisationService.GetAllOrganisationsAsync(trackChanges: false);

            return Ok(organisations);
        }

        [HttpGet("{id:int}", Name = "OrganisationById")]
        public async Task<IActionResult> GetOrganisation(int id)
        {
            var organisation = await _service.OrganisationService.GetOrganisationAsync(id, trackChanges: false);
            return Ok(organisation);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateOrganisation([FromBody] OrganisationForCreationDto organisation)
        {
            var createdOrganisation = await _service.OrganisationService.CreateOrganisationAsync(organisation);

            return CreatedAtRoute("OrganisationById", new { id = createdOrganisation.TableId }, createdOrganisation);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteOrganisation(int id)
        {
            await _service.OrganisationService.DeleteOrganisationAsync(id, trackChanges: false);

            return NoContent();
        }

        [HttpPut("{id:int}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateOrganisation(int id, [FromBody] OrganisationForUpdateDto organisation)
        {
            await _service.OrganisationService.UpdateOrganisationAsync(id, organisation, trackChanges: true);

            return NoContent();
        }
    }
}
