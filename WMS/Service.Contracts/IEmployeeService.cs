using Shared.DataTransferObjects.Employee;

namespace Service.Contracts
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDto>> GetAllAsync(bool trackChanges);
        Task<EmployeeDto> GetByIdAsync(string ecode, bool trackChanges);
        Task<EmployeeDto> CreateAsync(EmployeeForCreationDto dto);
        Task UpdateAsync(string ecode, EmployeeForUpdateDto dto, bool trackChanges);
        Task DeleteAsync(string ecode, bool trackChanges);
    }
}
