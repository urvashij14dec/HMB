using Shared.DataTransferObjects.FamilyDetail;

namespace Service.Contracts
{
    public interface IFamilyDetailService
    {
        Task<IEnumerable<FamilyDetailDto>> GetAllAsync(bool trackChanges);
        Task<FamilyDetailDto> GetByIdAsync(int rowId, bool trackChanges);
        Task<FamilyDetailDto> CreateAsync(FamilyDetailForCreationDto dto);
        Task UpdateAsync(int rowId, FamilyDetailForUpdateDto dto, bool trackChanges);
        Task DeleteAsync(int rowId, bool trackChanges);
    }
}
