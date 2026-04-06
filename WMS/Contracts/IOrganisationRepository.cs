using Entities.Models;

namespace Contracts
{
    public interface IMCompanyRepository
    {
        Task<IEnumerable<MCompany>> GetMCompanysAsync(bool trackChanges);
        Task<MCompany?> GetMCompanyAsync(int companyId, bool trackChanges);
        void CreateMCompany(MCompany company);
        void DeleteMCompany(MCompany company);
    }
}
