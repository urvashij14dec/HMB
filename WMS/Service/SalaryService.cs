using AutoMapper;
using Contracts;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects.Salary;

namespace Service
{
    public class SalaryService : ISalaryService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public SalaryService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SalaryDto>> GetAllAsync(bool trackChanges)
        {
            var entities = await _repository.Salary.GetAllAsync(trackChanges);
            return _mapper.Map<IEnumerable<SalaryDto>>(entities);
        }

        public async Task<SalaryDto> GetByIdAsync(long tabId, bool trackChanges)
        {
            var entity = await _repository.Salary.GetByIdAsync(tabId, trackChanges);
            if (entity == null)
                throw new Exception("Salary structure not found");

            return _mapper.Map<SalaryDto>(entity);
        }

        public async Task<SalaryDto> CreateAsync(SalaryForCreationDto dto)
        {
            var entity = _mapper.Map<EmpSalaryStructure>(dto);
            _repository.Salary.CreateSalary(entity);
            await _repository.SaveAsync();

            return _mapper.Map<SalaryDto>(entity);
        }

        public async Task UpdateAsync(long tabId, SalaryForUpdateDto dto, bool trackChanges)
        {
            var entity = await _repository.Salary.GetByIdAsync(tabId, trackChanges);
            if (entity == null)
                throw new Exception("Salary structure not found");

            _mapper.Map(dto, entity);
            await _repository.SaveAsync();
        }

        public async Task DeleteAsync(long tabId, bool trackChanges)
        {
            var entity = await _repository.Salary.GetByIdAsync(tabId, trackChanges);
            if (entity == null)
                throw new Exception("Salary structure not found");

            _repository.Salary.DeleteSalary(entity);
            await _repository.SaveAsync();
        }
    }
}
