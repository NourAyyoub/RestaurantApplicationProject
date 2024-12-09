using AutoMapper;
using Contracts.Dtos.FoodDtos;
using Contracts.Interfaces.IRepository;
using Domain.Entities;
using EFC;

namespace Application.Repositories
{
    public class FoodRepository : Repository<Food, FoodDto, CreateFoodDto, UpdateFoodDto>, IFoodRepository
    {
        public FoodRepository(AppDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
