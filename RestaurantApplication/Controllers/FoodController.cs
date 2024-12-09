using Contracts.Dtos.FoodDtos;
using Contracts.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace RestaurantApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FoodController : ControllerBase
    {
        private readonly IFoodServices _foodServices;
        private readonly ILogger<MenuController> _logger;
        public FoodController(IFoodServices foodServices, ILogger<MenuController> logger)
        {
            _logger = logger;
            _foodServices = foodServices;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFood(Guid id)
        {
            _logger.LogInformation("Fetching food with ID: {Id}", id);

            try
            {
                var result = await _foodServices.GetAsync(id);

                if (result is null)
                {
                    _logger.LogWarning("Food with ID: {Id} not found", id);
                    return NotFound($"Food with ID: {id} not found.");
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching the food.");
                return StatusCode(500, "An internal error occurred.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateFood(CreateFoodDto newFood)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _logger.LogInformation("Creating a new food item.");

            try
            {
                var result = await _foodServices.CreateAsync(newFood);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating the food item.");
                return StatusCode(500, "An internal error occurred.");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFood(UpdateFoodDto updatedFood)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _logger.LogInformation("Updating food with ID: {Id}", updatedFood.Id);

            try
            {
                var result = await _foodServices.UpdateAsync(updatedFood);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating the food item.");
                return StatusCode(500, "An internal error occurred.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFood(Guid id)
        {
            _logger.LogInformation("Deleting food with ID: {Id}", id);

            try
            {
                await _foodServices.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting the food item.");
                return StatusCode(500, "An internal error occurred.");
            }
        }
    }
}
