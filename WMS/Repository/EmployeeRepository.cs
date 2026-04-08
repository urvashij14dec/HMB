using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class EmployeeRepository : RepositoryBase<MEmpMast>, IEmployeeRepository
    {
        public EmployeeRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<MEmpMast>> GetAllAsync(bool trackChanges) =>
            await FindAll(trackChanges)
                .OrderBy(c => c.EmpName)
                .ToListAsync();

        public async Task<MEmpMast> GetByIdAsync(string ecode, bool trackChanges) =>
            await FindByCondition(c => c.Ecode.Equals(ecode), trackChanges)
                .SingleOrDefaultAsync();

        public void CreateEmployee(MEmpMast employee) => Create(employee);

        public void DeleteEmployee(MEmpMast employee) => Delete(employee);
    }
}
