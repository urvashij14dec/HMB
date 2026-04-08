using Shared.DataTransferObjects.Salary;

namespace Service.Contracts
{
    public interface ISalaryService
    {
        Task<IEnumerable<SalaryDto>> GetAllAsync(bool trackChanges);
        Task<SalaryDto> GetByIdAsync(long tabId, bool trackChanges);
        Task<SalaryDto> CreateAsync(SalaryForCreationDto dto);
        Task UpdateAsync(long tabId, SalaryForUpdateDto dto, bool trackChanges);
        Task DeleteAsync(long tabId, bool trackChanges);
    }
}
