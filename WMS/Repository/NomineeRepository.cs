using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class NomineeRepository : RepositoryBase<MNominee>, INomineeRepository
    {
        public NomineeRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<MNominee>> GetAllAsync(bool trackChanges) =>
            await FindAll(trackChanges)
                .OrderBy(c => c.NomineeName)
                .ToListAsync();

        public async Task<MNominee> GetByIdAsync(int rowId, bool trackChanges) =>
            await FindByCondition(c => c.RowId.Equals(rowId), trackChanges)
                .SingleOrDefaultAsync();

        public void CreateNominee(MNominee nominee) => Create(nominee);

        public void DeleteNominee(MNominee nominee) => Delete(nominee);
    }
}
