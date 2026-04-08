using Shared.DataTransferObjects.Designation;


public interface IDesignationService
{
    Task<IEnumerable<DesignationDto>> GetAllAsync(bool trackChanges);
    Task<DesignationDto> GetByIdAsync(int id, bool trackChanges);
    Task<DesignationDto> CreateAsync(DesignationForCreationDto dto);
    Task UpdateAsync(
        int id,
        DesignationForUpdateDto dto,
        bool trackChanges);
    Task DeleteAsync(int id, bool trackChanges);
}
