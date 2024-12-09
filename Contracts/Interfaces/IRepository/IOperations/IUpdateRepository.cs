using Contracts.Dtos.Drink;
using Domain.Entities;

namespace Contracts.Interfaces.IRepository.IOperations
{
    public interface IUpdateRepository<TEntity, TDto, TUpdateDto>
        where TDto : BaseWithIdDto
        where TUpdateDto : UpdateBaseDto
        where TEntity : FoodDrinkBaseEntity
    {
        Task<TDto> UpdateAsync(TUpdateDto entity);
    }
}
