using Contracts.Dtos.Drink;
using Contracts.Dtos.FoodDtos;

namespace Contracts.Dtos.MenuDtos
{
    public class MenuDto
    {
        public IEnumerable<FoodDto>? Foods { get; set; }
        public IEnumerable<DrinkDto>? Drinks { get; set; }
    }
}
