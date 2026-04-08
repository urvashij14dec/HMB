namespace Service.Contracts
{
    public interface IServiceManager
    {
        IAuditService AuditService { get; }
        IAuthenticationService AuthenticationService { get; }
        ICustomerService CustomerService { get; }
        IAccountService AccountService { get; }
        IUserService UserService { get; }
        IRoleService RoleService { get; }
        IMCompanyService MCompanyService { get; }

        IDesignationService DesignationService { get; }
    }
}
