using Entities.Models;

namespace Contracts
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<MEmpMast>> GetAllAsync(bool trackChanges);
        Task<MEmpMast> GetByIdAsync(string ecode, bool trackChanges);
        void CreateEmployee(MEmpMast employee);
        void DeleteEmployee(MEmpMast employee);
    }
}
