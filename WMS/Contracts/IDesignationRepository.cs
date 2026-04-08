using Entities.Models;

namespace Contracts
{
    public interface IDesignationRepository
    {

        Task<IEnumerable<MDesignationMast>> GetAllAsync(bool trackChanges);
        Task<MDesignationMast> GetByIdAsync(int id, bool trackChanges);
        void CreateDesignation(MDesignationMast designation);
        void DeleteDesignation(MDesignationMast designation);

    }
}