using Entities.Models;

namespace Contracts
{
    public interface ISalaryRepository
    {
        Task<IEnumerable<EmpSalaryStructure>> GetAllAsync(bool trackChanges);
        Task<EmpSalaryStructure?> GetByIdAsync(long tabId, bool trackChanges);
        void CreateSalary(EmpSalaryStructure salary);
        void DeleteSalary(EmpSalaryStructure salary);
    }
}
