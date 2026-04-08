using Entities.Models;

namespace Contracts
{
    public interface IFamilyDetailRepository
    {
        Task<IEnumerable<MFamilyDetail>> GetAllAsync(bool trackChanges);
        Task<MFamilyDetail?> GetByIdAsync(int rowId, bool trackChanges);
        void CreateFamilyDetail(MFamilyDetail familyDetail);
        void DeleteFamilyDetail(MFamilyDetail familyDetail);
    }
}
