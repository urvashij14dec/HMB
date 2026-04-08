using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class SalaryRepository : RepositoryBase<EmpSalaryStructure>, ISalaryRepository
    {
        public SalaryRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<EmpSalaryStructure>> GetAllAsync(bool trackChanges) =>
            await FindAll(trackChanges)
                .OrderBy(s => s.Ecode)
                .ToListAsync();

        public async Task<EmpSalaryStructure?> GetByIdAsync(long tabId, bool trackChanges) =>
            await FindByCondition(s => s.TabId.Equals(tabId), trackChanges)
                .SingleOrDefaultAsync();

        public void CreateSalary(EmpSalaryStructure salary) => Create(salary);

        public void DeleteSalary(EmpSalaryStructure salary) => Delete(salary);
    }
}
