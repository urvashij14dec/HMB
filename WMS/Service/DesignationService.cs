using AutoMapper;
using Contracts;
using Entities.Models;
using Shared.DataTransferObjects.Designation;

public class DesignationService : IDesignationService
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;


    public DesignationService(
        IRepositoryManager repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<DesignationDto>> GetAllAsync(
        bool trackChanges)
    {
        var entities =
            await _repository.Designation.GetAllAsync(trackChanges);

        return _mapper.Map<IEnumerable<DesignationDto>>(entities);
    }

    public async Task<DesignationDto> GetByIdAsync(
        int id, bool trackChanges)
    {
        var entity =
            await _repository.Designation.GetByIdAsync(id, trackChanges);

        if (entity == null)
            throw new Exception("Designation not found");

        return _mapper.Map<DesignationDto>(entity);
    }

    public async Task<DesignationDto> CreateAsync(
        DesignationForCreationDto dto)
    {
        var entity = _mapper.Map<MDesignationMast>(dto);

        _repository.Designation.CreateDesignation(entity);
        await _repository.SaveAsync();

        return _mapper.Map<DesignationDto>(entity);
    }

    public async Task UpdateAsync(
        int id,
        DesignationForUpdateDto dto,
        bool trackChanges)
    {
        var entity =
            await _repository.Designation.GetByIdAsync(id, trackChanges);

        if (entity == null)
            throw new Exception("Designation not found");

        _mapper.Map(dto, entity);
        await _repository.SaveAsync();
    }

    public async Task DeleteAsync(int id, bool trackChanges)
    {
        var entity =
            await _repository.Designation.GetByIdAsync(id, trackChanges);

        if (entity == null)
            throw new Exception("Designation not found");

        _repository.Designation.DeleteDesignation(entity);
        await _repository.SaveAsync();
    }
}