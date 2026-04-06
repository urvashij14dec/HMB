using Shared.DataTransferObjects.MCompany;

namespace Service.Contracts
{
    public interface IMCompanyService
    {
        Task<IEnumerable<MCompanyDto>> GetAllMCompanysAsync(bool trackChanges);
        Task<MCompanyDto> GetMCompanyAsync(int companyId, bool trackChanges);
        Task<MCompanyDto> CreateMCompanyAsync(MCompanyForCreationDto customer);
        Task DeleteMCompanyAsync(int companyId, bool trackChanges);
        Task UpdateMCompanyAsync(int companyId, MCompanyForUpdateDto customerForUpdate, bool trackChanges);
    }
}
