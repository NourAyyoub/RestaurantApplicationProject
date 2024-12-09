using AutoMapper;
using Contracts.Dtos.Drink;
using Contracts.Interfaces.IRepository;
using Domain.Entities;
using EFC;

namespace Application.Repositories
{
    public class DrinkRepository : Repository<Drink, DrinkDto, CreateDrinkDto, UpdateDrinkDto>, IDrinkRepository
    {
        public DrinkRepository(AppDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
