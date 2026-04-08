using AutoMapper;
using Contracts;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects.Nominee;

namespace Service
{
    public class NomineeService : INomineeService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public NomineeService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<NomineeDto>> GetAllAsync(bool trackChanges)
        {
            var entities = await _repository.Nominee.GetAllAsync(trackChanges);
            return _mapper.Map<IEnumerable<NomineeDto>>(entities);
        }

        public async Task<NomineeDto> GetByIdAsync(int rowId, bool trackChanges)
        {
            var entity = await _repository.Nominee.GetByIdAsync(rowId, trackChanges);

            if (entity == null)
                throw new Exception("Nominee not found");

            return _mapper.Map<NomineeDto>(entity);
        }

        public async Task<NomineeDto> CreateAsync(NomineeForCreationDto dto)
        {
            var entity = _mapper.Map<MNominee>(dto);

            _repository.Nominee.CreateNominee(entity);
            await _repository.SaveAsync();

            return _mapper.Map<NomineeDto>(entity);
        }

        public async Task UpdateAsync(int rowId, NomineeForUpdateDto dto, bool trackChanges)
        {
            var entity = await _repository.Nominee.GetByIdAsync(rowId, trackChanges);

            if (entity == null)
                throw new Exception("Nominee not found");

            _mapper.Map(dto, entity);
            await _repository.SaveAsync();
        }

        public async Task DeleteAsync(int rowId, bool trackChanges)
        {
            var entity = await _repository.Nominee.GetByIdAsync(rowId, trackChanges);

            if (entity == null)
                throw new Exception("Nominee not found");

            _repository.Nominee.DeleteNominee(entity);
            await _repository.SaveAsync();
        }
    }
}
