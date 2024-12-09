using Domain.Entities;

namespace Contracts.Interfaces.IRepository.IOperations
{
    public interface IDeleteRepository<TEntity>
        where TEntity : BaseEntity
    {
        Task DeleteAsync(Guid id);
    }
}
