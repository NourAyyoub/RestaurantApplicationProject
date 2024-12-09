using Contracts.Dtos.FoodDtos;

namespace Contracts.Interfaces.IServices
{
    public interface IFoodServices
    {
        Task<FoodDto?> GetAsync(Guid id);
        Task<IEnumerable<FoodDto>?> GetAllAsync();
        Task<FoodDto> CreateAsync(CreateFoodDto newFood);
        Task<FoodDto> UpdateAsync(UpdateFoodDto updatedFood);
        Task DeleteAsync(Guid id);
    }
}
