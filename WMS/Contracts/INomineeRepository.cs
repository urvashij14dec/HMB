using Entities.Models;

namespace Contracts
{
    public interface INomineeRepository
    {
        Task<IEnumerable<MNominee>> GetAllAsync(bool trackChanges);
        Task<MNominee> GetByIdAsync(int rowId, bool trackChanges);
        void CreateNominee(MNominee nominee);
        void DeleteNominee(MNominee nominee);
    }
}
