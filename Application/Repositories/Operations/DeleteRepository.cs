using Contracts.Interfaces.IRepository.IOperations;
using Domain.Entities;
using Domain.Shared.ExceptionShared;
using EFC;

namespace Application.Repositories.Operations
{
    public class DeleteRepository<TEntity> : IDeleteRepository<TEntity>
        where TEntity : BaseEntity
    {
        private readonly AppDbContext _context;

        public DeleteRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id)
                        ?? throw new NotFoundException();

            entity.SetIsDeleted();
            await _context.SaveChangesAsync();
        }
    }
}
