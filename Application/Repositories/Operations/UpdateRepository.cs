using Contracts.Dtos.Drink;
using Contracts.Interfaces.IRepository.IOperations;
using Domain.Entities;
using Domain.Shared.ExceptionShared;
using AutoMapper;
using EFC;

namespace Application.Repositories.Operations
{
    public class UpdateRepository<TEntity, TDto, TUpdateDto> : IUpdateRepository<TEntity, TDto, TUpdateDto>
        where TDto : BaseWithIdDto
        where TUpdateDto : UpdateBaseDto
        where TEntity : FoodDrinkBaseEntity
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public UpdateRepository(AppDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<TDto> UpdateAsync(TUpdateDto updatedEntity)
        {
            var existingEntity = await _context.Set<TEntity>().FindAsync(updatedEntity.Id)
                                    ?? throw new NotFoundException();

            _mapper.Map(updatedEntity, existingEntity);

            await _context.SaveChangesAsync();

            return _mapper.Map<TDto>(existingEntity);
        }
    }
}
