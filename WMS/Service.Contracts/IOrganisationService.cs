using Shared.DataTransferObjects.Organisation;

namespace Service.Contracts
{
    public interface IOrganisationService
    {
        Task<IEnumerable<OrganisationDto>> GetAllOrganisationsAsync(bool trackChanges);
        Task<OrganisationDto> GetOrganisationAsync(int organisationId, bool trackChanges);
        Task<OrganisationDto> CreateOrganisationAsync(OrganisationForCreationDto customer);
        Task DeleteOrganisationAsync(int organisationId, bool trackChanges);
        Task UpdateOrganisationAsync(int organisationId, OrganisationForUpdateDto customerForUpdate, bool trackChanges);
    }
}
