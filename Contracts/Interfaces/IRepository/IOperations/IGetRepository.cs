using Contracts.Dtos.Drink;
using Domain.Entities;

namespace Contracts.Interfaces.IRepository.IOperations
{
    public interface IGetRepository<TEntity, TDto>
        where TDto : BaseWithIdDto
        where TEntity : BaseEntity
    {
        Task<TDto?> GetAsync(Guid id);
        Task<IEnumerable<TDto>?> GetAllAsync();
    }
}
