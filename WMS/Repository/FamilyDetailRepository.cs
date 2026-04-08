using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class FamilyDetailRepository : RepositoryBase<MFamilyDetail>, IFamilyDetailRepository
    {
        public FamilyDetailRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<MFamilyDetail>> GetAllAsync(bool trackChanges) =>
            await FindAll(trackChanges)
                .OrderBy(f => f.PersonName)
                .ToListAsync();

        public async Task<MFamilyDetail?> GetByIdAsync(int rowId, bool trackChanges) =>
            await FindByCondition(f => f.RowId.Equals(rowId), trackChanges)
                .SingleOrDefaultAsync();

        public void CreateFamilyDetail(MFamilyDetail familyDetail) => Create(familyDetail);

        public void DeleteFamilyDetail(MFamilyDetail familyDetail) => Delete(familyDetail);
    }
}
