using Contracts.Dtos.Drink;
using Contracts.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace RestaurantApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DrinkController : ControllerBase
    {
        private readonly IDrinkServices _drinkServices;
        private readonly ILogger<MenuController> _logger;

        public DrinkController(IDrinkServices drinkServices, ILogger<MenuController> logger)
        {
            _logger = logger;
            _drinkServices = drinkServices;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDrink(Guid id)
        {
           _logger.LogInformation("Fetching drink with ID: {Id}", id);

            try
            {
                var result = await _drinkServices.GetAsync(id);

                if (result is null)
                {
                   _logger.LogWarning("Drink with ID: {Id} not found", id);
                    return NotFound($"Drink with ID: {id} not found.");
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
               _logger.LogError(ex, "An error occurred while fetching the drink.");
                return StatusCode(500, "An internal error occurred.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateDrink(CreateDrinkDto newDrink)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

           _logger.LogInformation("Creating a new drink.");

            try
            {
                var result = await _drinkServices.CreateAsync(newDrink);

                return Ok(result);
            }
            catch (Exception ex)
            {
               _logger.LogError(ex, "An error occurred while creating the drink.");
                return StatusCode(500, "An internal error occurred.");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDrink(UpdateDrinkDto updatedDrink)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

           _logger.LogInformation("Updating drink with ID: {Id}", updatedDrink.Id);

            try
            {
                var result = await _drinkServices.UpdateAsync(updatedDrink);
                return Ok(result);
            }
            catch (Exception ex)
            {
               _logger.LogError(ex, "An error occurred while updating the drink.");
                return StatusCode(500, "An internal error occurred.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDrink(Guid id)
        {
           _logger.LogInformation("Deleting drink with ID: {Id}", id);

            try
            {
                await _drinkServices.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
               _logger.LogError(ex, "An error occurred while deleting the drink.");
                return StatusCode(500, "An internal error occurred.");
            }
        }
    }
}
