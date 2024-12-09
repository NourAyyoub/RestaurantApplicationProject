using Contracts.Dtos.MenuDtos;
using Contracts.Interfaces.IServices;
using Contracts.Interfaces.IRepository;

namespace Application.Services
{
    public class MenuServices : IMenuServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public MenuServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<MenuDto> GetMenuAsync()
        {
            var foods = await _unitOfWork.FoodRepository.GetAllAsync();

            var drinks = await _unitOfWork.DrinkRepository.GetAllAsync();

            var toSend = new MenuDto
            {
                Foods = foods,
                Drinks = drinks
            };

            return toSend;
        }
    }
}
