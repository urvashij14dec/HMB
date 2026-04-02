using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Models;

namespace Repository
{
    internal sealed class OrganisationRepository : RepositoryBase<MOrganisation>, IOrganisationRepository
    {
        public OrganisationRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateOrganisation(MOrganisation organisation)
        {
            Create(organisation);
        }

        public void DeleteOrganisation(MOrganisation organisation)
        {
            Delete(organisation);
        }

        public async Task<MOrganisation?> GetOrganisationAsync(int organisationId, bool trackChanges)
        {
            return await FindByCondition(c => c.TableId.Equals(organisationId), trackChanges).FirstOrDefaultAsync();

        }

        public async Task<IEnumerable<MOrganisation>> GetOrganisationsAsync(bool trackChanges)
        {
            return await FindAll(trackChanges).OrderBy(c => c.Name).ToListAsync();
        }

        
    }
}
 