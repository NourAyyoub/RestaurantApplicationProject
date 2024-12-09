using Contracts.Dtos.FoodDtos;
using Contracts.Interfaces.IRepository;
using Contracts.Interfaces.IServices;

namespace Application.Services
{
    public class FoodServices : IFoodServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public FoodServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<FoodDto?> GetAsync(Guid id)
        {
            return await _unitOfWork.FoodRepository.GetAsync(id);
        }

        public async Task<IEnumerable<FoodDto>?> GetAllAsync()
        {
            return await _unitOfWork.FoodRepository.GetAllAsync();
        }

        public async Task<FoodDto> CreateAsync(CreateFoodDto newFood)
        {
            var result = await _unitOfWork.FoodRepository.CreateAsync(newFood);
            await _unitOfWork.CompleteAsync();
            return result;
        }

        public async Task<FoodDto> UpdateAsync(UpdateFoodDto updatedFood)
        {
            var result = await _unitOfWork.FoodRepository.UpdateAsync(updatedFood);
            await _unitOfWork.CompleteAsync();
            return result;
        }

        public async Task DeleteAsync(Guid id)
        {
            await _unitOfWork.FoodRepository.DeleteAsync(id);
            await _unitOfWork.CompleteAsync();
        }
    }
}
