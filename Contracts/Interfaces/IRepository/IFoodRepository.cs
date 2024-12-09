using Contracts.Dtos.FoodDtos;
using Domain.Entities;

namespace Contracts.Interfaces.IRepository
{
    public interface IFoodRepository : IRepository<Food, FoodDto, CreateFoodDto, UpdateFoodDto>
    {
    }
}
