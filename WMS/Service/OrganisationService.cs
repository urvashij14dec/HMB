using AutoMapper;
using Contracts;
using Entities.Exceptions.Organisation;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects.Organisation;

namespace Service
{
    internal sealed class OrganisationService : IOrganisationService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public OrganisationService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrganisationDto>> GetAllOrganisationsAsync(bool trackChanges)
        {
            var organisations = await _repository.Organisation.GetOrganisationsAsync(trackChanges);

            var organisationsDto = _mapper.Map<IEnumerable<OrganisationDto>>(organisations);

            return organisationsDto;
        }

        public async Task<OrganisationDto> GetOrganisationAsync(int organisationId, bool trackChanges)
        {
            var organisation = await GetOrganisationAndCheckIfItExists(organisationId, trackChanges);

            var organisationDto = _mapper.Map<OrganisationDto>(organisation);
            return organisationDto;
        }

        public async Task<OrganisationDto> CreateOrganisationAsync(OrganisationForCreationDto organisation)
        {
            try
            {
                var organisationEntity = _mapper.Map<MOrganisation>(organisation);

                _repository.Organisation.CreateOrganisation(organisationEntity);
                await _repository.SaveAsync();

                var organisationToReturn = _mapper.Map<OrganisationDto>(organisationEntity);
                return organisationToReturn;
            }
            catch(Exception ex)
            {

            }
            return null;
        }

        public async Task UpdateOrganisationAsync(int organisationId, OrganisationForUpdateDto organisationForUpdate, bool trackChanges)
        {
            var organisation = await GetOrganisationAndCheckIfItExists(organisationId, trackChanges);

            _mapper.Map(organisationForUpdate, organisation);
            await _repository.SaveAsync();
        }

        public async Task DeleteOrganisationAsync(int organisationId, bool trackChanges)
        {
            var organisation = await GetOrganisationAndCheckIfItExists(organisationId, trackChanges);

            _repository.Organisation.DeleteOrganisation(organisation);
            await _repository.SaveAsync();
        }

        private async Task<MOrganisation> GetOrganisationAndCheckIfItExists(int organisationId, bool trackChanges)
        {
            var organisation = await _repository.Organisation.GetOrganisationAsync(organisationId, trackChanges);
            if (organisation is null)
                throw new OrganisationNotFoundException(organisationId);

            return organisation;
        }
    }
}
