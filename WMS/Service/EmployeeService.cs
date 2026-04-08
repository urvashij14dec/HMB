using AutoMapper;
using Contracts;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects.Employee;

namespace Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public EmployeeService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EmployeeDto>> GetAllAsync(bool trackChanges)
        {
            var entities = await _repository.Employee.GetAllAsync(trackChanges);
            return _mapper.Map<IEnumerable<EmployeeDto>>(entities);
        }

        public async Task<EmployeeDto> GetByIdAsync(string ecode, bool trackChanges)
        {
            var entity = await _repository.Employee.GetByIdAsync(ecode, trackChanges);

            if (entity == null)
                throw new Exception("Employee not found");

            return _mapper.Map<EmployeeDto>(entity);
        }

        public async Task<EmployeeDto> CreateAsync(EmployeeForCreationDto dto)
        {
            var entity = _mapper.Map<MEmpMast>(dto);

            _repository.Employee.CreateEmployee(entity);
            await _repository.SaveAsync();

            return _mapper.Map<EmployeeDto>(entity);
        }

        public async Task UpdateAsync(string ecode, EmployeeForUpdateDto dto, bool trackChanges)
        {
            var entity = await _repository.Employee.GetByIdAsync(ecode, trackChanges);

            if (entity == null)
                throw new Exception("Employee not found");

            _mapper.Map(dto, entity);
            await _repository.SaveAsync();
        }

        public async Task DeleteAsync(string ecode, bool trackChanges)
        {
            var entity = await _repository.Employee.GetByIdAsync(ecode, trackChanges);

            if (entity == null)
                throw new Exception("Employee not found");

            _repository.Employee.DeleteEmployee(entity);
            await _repository.SaveAsync();
        }
    }
}
