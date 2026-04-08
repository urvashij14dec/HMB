namespace Contracts
{
    public interface IRepositoryManager
    {
        IAuditRepository Audit { get; }
        ICustomerRepository Customer { get; }
        IAccountRepository Account { get; }
        IMCompanyRepository MCompany { get; }
        IDesignationRepository Designation { get; }
        Task SaveAsync();
    }
}
