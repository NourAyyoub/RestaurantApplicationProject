using Contracts.Dtos.Drink;
using Domain.Entities;

namespace Contracts.Interfaces.IRepository
{
    public interface IDrinkRepository: IRepository<Drink, DrinkDto, CreateDrinkDto, UpdateDrinkDto>
    {

    }
}
