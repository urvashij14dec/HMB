using Entities.Models;

namespace Contracts
{
    public interface IOrganisationRepository
    {
        Task<IEnumerable<MOrganisation>> GetOrganisationsAsync(bool trackChanges);
        Task<MOrganisation?> GetOrganisationAsync(int organisationId, bool trackChanges);
        void CreateOrganisation(MOrganisation organisation);
        void DeleteOrganisation(MOrganisation organisation);
    }
}
