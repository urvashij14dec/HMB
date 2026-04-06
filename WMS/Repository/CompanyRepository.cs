using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    internal sealed class MCompanyRepository : RepositoryBase<MCompany>, IMCompanyRepository
    {
        public MCompanyRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateMCompany(MCompany company)
        {
            Create(company);
        }

        public void DeleteMCompany(MCompany company)
        {
            Delete(company);
        }

        public async Task<MCompany?> GetMCompanyAsync(int companyId, bool trackChanges)
        {
            return await FindByCondition(c => c.TableId.Equals(companyId), trackChanges).FirstOrDefaultAsync();

        }

        public async Task<IEnumerable<MCompany>> GetMCompanysAsync(bool trackChanges)
        {
            return await FindAll(trackChanges).OrderBy(c => c.CompanyDesc).ToListAsync();
        }


    }
}
