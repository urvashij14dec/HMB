using Contracts;
using Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Repository
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<ICustomerRepository> _customerRepository;
        private readonly Lazy<IAccountRepository> _accountRepository;
        private readonly Lazy<IAuditRepository> _auditRepository;
        private readonly Lazy<IMCompanyRepository> _companyRepository;
        private readonly Lazy<IDesignationRepository> _designationRepository;
        private readonly Lazy<IEmployeeRepository> _employeeRepository;

       
        public RepositoryManager(
            RepositoryContext repositoryContext,
            RoleManager<UserRole> roleManager)
        {
      
            _repositoryContext = repositoryContext;

            _customerRepository =
                new Lazy<ICustomerRepository>(
                    () => new CustomerRepository(_repositoryContext));

            _accountRepository =
                new Lazy<IAccountRepository>(
                    () => new AccountRepository(_repositoryContext));

            _auditRepository =
                new Lazy<IAuditRepository>(
                    () => new AuditRepository(_repositoryContext));

            _companyRepository =
                new Lazy<IMCompanyRepository>(
                    () => new MCompanyRepository(_repositoryContext));

            _designationRepository =
                new Lazy<IDesignationRepository>(
                    () => new DesignationRepository(_repositoryContext));

            _employeeRepository =
                new Lazy<IEmployeeRepository>(
                    () => new EmployeeRepository(_repositoryContext));
        }

        #region Repository Accessors
        public ICustomerRepository Customer => _customerRepository.Value;
        public IAccountRepository Account => _accountRepository.Value;
        public IAuditRepository Audit => _auditRepository.Value;
        public IMCompanyRepository MCompany => _companyRepository.Value;
        public IDesignationRepository Designation => _designationRepository.Value;
        public IEmployeeRepository Employee => _employeeRepository.Value;
        #endregion

        public async Task SaveAsync() =>
            await _repositoryContext.SaveChangesAsync();
    }
}