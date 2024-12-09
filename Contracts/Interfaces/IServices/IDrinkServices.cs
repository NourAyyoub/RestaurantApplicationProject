using Contracts.Dtos.Drink;

namespace Contracts.Interfaces.IServices
{
    public interface IDrinkServices
    {
        Task<DrinkDto?> GetAsync(Guid id);
        Task<IEnumerable<DrinkDto>?> GetAllAsync();
        Task<DrinkDto> CreateAsync(CreateDrinkDto newDrink);
        Task<DrinkDto> UpdateAsync(UpdateDrinkDto updatedDrink);
        Task DeleteAsync(Guid id);
    }
}
