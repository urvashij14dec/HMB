using Shared.DataTransferObjects.Nominee;

namespace Service.Contracts
{
    public interface INomineeService
    {
        Task<IEnumerable<NomineeDto>> GetAllAsync(bool trackChanges);
        Task<NomineeDto> GetByIdAsync(int rowId, bool trackChanges);
        Task<NomineeDto> CreateAsync(NomineeForCreationDto dto);
        Task UpdateAsync(int rowId, NomineeForUpdateDto dto, bool trackChanges);
        Task DeleteAsync(int rowId, bool trackChanges);
    }
}
