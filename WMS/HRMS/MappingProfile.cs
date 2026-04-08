using AutoMapper;
using Entities.Identity;
using Entities.Models;
using Shared.DataTransferObjects.Account;
using Shared.DataTransferObjects.AuditLog;
using Shared.DataTransferObjects.Authentication;
using Shared.DataTransferObjects.Customer;
using Shared.DataTransferObjects.User;
using Shared.DataTransferObjects.UserRole;
using Shared.DataTransferObjects.MCompany;
using Shared.DataTransferObjects.Designation;

namespace WMS
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<Customer, CustomerDto>()
                .ForMember(d => d.accountCount, o => o.MapFrom(s => s.Accounts.Count));
            CreateMap<Account, AccountDto>();
            CreateMap<AccountForCreationDto, AccountDto>();
            CreateMap<CustomerForCreationDto, Customer>();
            CreateMap<AccountForCreationDto, Account>();
            CreateMap<AccountForUpdateDto, Account>().ReverseMap();
            CreateMap<CustomerForUpdateDto, Customer>();
            CreateMap<UserForRegistrationDto, User>();
            CreateMap<User, UserDto>();
            CreateMap<UserRole, UserRoleDto>();
            CreateMap<UserForUpdateDto, User>();
            CreateMap<UserRoleForCreationDto, UserRole>();
            CreateMap<UserRoleForUpdateDto, UserRole>();
            CreateMap<AuditLog, AuditLogDto>();

            // MCompany mappings
            CreateMap<MCompany, MCompanyDto>();
            CreateMap<MCompanyForCreationDto, MCompany>();
            CreateMap<MCompanyForUpdateDto, MCompany>();

            /// MDesignationMast mappings
            CreateMap<MDesignationMast, DesignationDto>();
            CreateMap<DesignationForCreationDto, MDesignationMast>();
            CreateMap<DesignationForUpdateDto, MDesignationMast>();

        }
    }
}
