using AutoMapper;
using Contracts;
using Entities.Exceptions.MCompany;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects.MCompany;

namespace Service
{
    internal sealed class MCompanyService : IMCompanyService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public MCompanyService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MCompanyDto>> GetAllMCompanysAsync(bool trackChanges)
        {
            var companys = await _repository.MCompany.GetMCompanysAsync(trackChanges);

            var companysDto = _mapper.Map<IEnumerable<MCompanyDto>>(companys);

            return companysDto;
        }

        public async Task<MCompanyDto> GetMCompanyAsync(int companyId, bool trackChanges)
        {
            var company = await GetMCompanyAndCheckIfItExists(companyId, trackChanges);

            var companyDto = _mapper.Map<MCompanyDto>(company);
            return companyDto;
        }

        public async Task<MCompanyDto> CreateMCompanyAsync(MCompanyForCreationDto company)
        {
            try
            {
                var companyEntity = _mapper.Map<MCompany>(company);

                _repository.MCompany.CreateMCompany(companyEntity);
                await _repository.SaveAsync();

                var companyToReturn = _mapper.Map<MCompanyDto>(companyEntity);
                return companyToReturn;
            }
            catch(Exception ex)
            {

            }
            return null;
        }

        public async Task UpdateMCompanyAsync(int companyId, MCompanyForUpdateDto companyForUpdate, bool trackChanges)
        {
            var company = await GetMCompanyAndCheckIfItExists(companyId, trackChanges);

            _mapper.Map(companyForUpdate, company);
            await _repository.SaveAsync();
        }

        public async Task DeleteMCompanyAsync(int companyId, bool trackChanges)
        {
            var company = await GetMCompanyAndCheckIfItExists(companyId, trackChanges);

            _repository.MCompany.DeleteMCompany(company);
            await _repository.SaveAsync();
        }

        private async Task<MCompany> GetMCompanyAndCheckIfItExists(int companyId, bool trackChanges)
        {
            var company = await _repository.MCompany.GetMCompanyAsync(companyId, trackChanges);
            if (company is null)
                throw new MCompanyNotFoundException(companyId);

            return company;
        }
    }
}
