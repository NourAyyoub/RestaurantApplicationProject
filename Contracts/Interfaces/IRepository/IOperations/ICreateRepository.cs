using Contracts.Dtos.Drink;
using Domain.Entities;

namespace Contracts.Interfaces.IRepository.IOperations
{
    public interface ICreateRepository<TEntity, TDto,TCreateDto>
        where TDto : BaseWithIdDto
        where TCreateDto : CreateBaseDto
        where TEntity : FoodDrinkBaseEntity
    {
       Task<TDto> CreateAsync(TCreateDto newEntity);
    }
}
