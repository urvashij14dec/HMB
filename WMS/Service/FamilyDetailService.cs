using AutoMapper;
using Contracts;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects.FamilyDetail;

namespace Service
{
    public class FamilyDetailService : IFamilyDetailService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public FamilyDetailService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FamilyDetailDto>> GetAllAsync(bool trackChanges)
        {
            var entities = await _repository.FamilyDetail.GetAllAsync(trackChanges);
            return _mapper.Map<IEnumerable<FamilyDetailDto>>(entities);
        }

        public async Task<FamilyDetailDto> GetByIdAsync(int rowId, bool trackChanges)
        {
            var entity = await _repository.FamilyDetail.GetByIdAsync(rowId, trackChanges);

            if (entity == null)
                throw new Exception("Family Detail not found");

            return _mapper.Map<FamilyDetailDto>(entity);
        }

        public async Task<FamilyDetailDto> CreateAsync(FamilyDetailForCreationDto dto)
        {
            var entity = _mapper.Map<MFamilyDetail>(dto);

            _repository.FamilyDetail.CreateFamilyDetail(entity);
            await _repository.SaveAsync();

            return _mapper.Map<FamilyDetailDto>(entity);
        }

        public async Task UpdateAsync(int rowId, FamilyDetailForUpdateDto dto, bool trackChanges)
        {
            var entity = await _repository.FamilyDetail.GetByIdAsync(rowId, trackChanges);

            if (entity == null)
                throw new Exception("Family Detail not found");

            _mapper.Map(dto, entity);
            await _repository.SaveAsync();
        }

        public async Task DeleteAsync(int rowId, bool trackChanges)
        {
            var entity = await _repository.FamilyDetail.GetByIdAsync(rowId, trackChanges);

            if (entity == null)
                throw new Exception("Family Detail not found");

            _repository.FamilyDetail.DeleteFamilyDetail(entity);
            await _repository.SaveAsync();
        }
    }
}
