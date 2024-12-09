using Contracts.Dtos.Drink;
using Contracts.Interfaces.IRepository.IOperations;
using Domain.Entities;
using Domain.Shared.ExceptionShared;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using EFC;

namespace Application.Repositories.Operations
{
    public class GetRepository<TEntity, TDto> : IGetRepository<TEntity, TDto>
        where TDto : BaseWithIdDto
        where TEntity : BaseEntity
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public GetRepository(AppDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<TDto?> GetAsync(Guid id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id)
                         ?? throw new NotFoundException();

            return _mapper.Map<TDto>(entity);
        }

        public async Task<IEnumerable<TDto>?> GetAllAsync()
        {
            var entities = await _context.Set<TEntity>().ToListAsync();

            if (entities is null || !entities.Any())
            {
                return Enumerable.Empty<TDto>();
            }

            return _mapper.Map<IEnumerable<TDto>>(entities);
        }
    }
}
