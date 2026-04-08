namespace Contracts
{
    public interface IRepositoryManager
    {
        IAuditRepository Audit { get; }
        ICustomerRepository Customer { get; }
        IAccountRepository Account { get; }
        IMCompanyRepository MCompany { get; }
        IDesignationRepository Designation { get; }
        IEmployeeRepository Employee { get; }
        INomineeRepository Nominee { get; }
        IFamilyDetailRepository FamilyDetail { get; }
        Task SaveAsync();
    }
}
