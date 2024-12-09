using Contracts.Dtos.Drink;
using Contracts.Interfaces.IRepository.IOperations;
using Domain.Entities;

namespace Contracts.Interfaces.IRepository
{
    public interface IRepository<TEntity, TDto, TCreateDto, TUpdateDto>
       :IDeleteRepository<TEntity>,
        IGetRepository<TEntity, TDto>,
        ICreateRepository<TEntity, TDto, TCreateDto>,
        IUpdateRepository<TEntity, TDto, TUpdateDto>
        
        where TDto : BaseWithIdDto
        where TCreateDto : CreateBaseDto
        where TUpdateDto : UpdateBaseDto
        where TEntity : FoodDrinkBaseEntity
    {
    }
}
