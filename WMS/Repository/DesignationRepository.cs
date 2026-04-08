using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository;

public class DesignationRepository
    : RepositoryBase<MDesignationMast>,
      IDesignationRepository
{
    public DesignationRepository(RepositoryContext context)
        : base(context)
    {
    }

    public async Task<IEnumerable<MDesignationMast>> GetAllAsync(bool trackChanges) =>
        await FindAll(trackChanges)
              .OrderBy(x => x.OrderNumber)
              .ToListAsync();

    public async Task<MDesignationMast> GetByIdAsync(
        int id, bool trackChanges) =>
        await FindByCondition(x => x.TableId == id, trackChanges)
              .SingleOrDefaultAsync();

    public void CreateDesignation(MDesignationMast designation) =>
        Create(designation);

    public void DeleteDesignation(MDesignationMast designation) =>
        Delete(designation);
}