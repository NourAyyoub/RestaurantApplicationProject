using AutoMapper;
using Contracts.Dtos.Drink;
using Contracts.Interfaces.IRepository.IOperations;
using Domain.Entities;
using EFC;

namespace Application.Repositories.Operations
{
    public class CreateRepository<TEntity, TDto, TCreateDto> : ICreateRepository<TEntity, TDto, TCreateDto>
        where TDto : BaseWithIdDto
        where TCreateDto : CreateBaseDto
        where TEntity : FoodDrinkBaseEntity
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public CreateRepository(AppDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<TDto> CreateAsync(TCreateDto newEntity)
        {
            var entity = _mapper.Map<TEntity>(newEntity);

            _context.Set<TEntity>().Add(entity);

            await _context.SaveChangesAsync();

            return _mapper.Map<TDto>(entity);
        }
    }
}