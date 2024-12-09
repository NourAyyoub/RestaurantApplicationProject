using Contracts.Dtos.Drink;
using Contracts.Interfaces.IRepository;
using Contracts.Interfaces.IServices;

namespace Application.Services
{
    public class DrinkServices :IDrinkServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public DrinkServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<DrinkDto?> GetAsync(Guid id)
        {
            return await _unitOfWork.DrinkRepository.GetAsync(id);
        }

        public async Task<IEnumerable<DrinkDto>?> GetAllAsync()
        {
            return await _unitOfWork.DrinkRepository.GetAllAsync();
        }

        public async Task<DrinkDto> CreateAsync(CreateDrinkDto newDrink)
        {
            var result = await _unitOfWork.DrinkRepository.CreateAsync(newDrink);
            await _unitOfWork.CompleteAsync();
            return result;
        }

        public async Task<DrinkDto> UpdateAsync(UpdateDrinkDto updatedDrink)
        {
            var result = await _unitOfWork.DrinkRepository.UpdateAsync(updatedDrink);
            await _unitOfWork.CompleteAsync();
            return result;
        }

        public async Task DeleteAsync(Guid id)
        {
            await _unitOfWork.DrinkRepository.DeleteAsync(id);
            await _unitOfWork.CompleteAsync();
        }
    }
}
