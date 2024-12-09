using Contracts.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace RestaurantApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MenuController : ControllerBase
    {
        private readonly IMenuServices _menuServices;
        private readonly ILogger<MenuController> _logger;

        public MenuController(IMenuServices menuRepository, ILogger<MenuController> logger)
        {
            _logger = logger;
            _menuServices = menuRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetMenu()
        {
            _logger.LogInformation("Fetching menu items.");

            try
            {
                var result = await _menuServices.GetMenuAsync();

                if (result is null)
                {
                    _logger.LogWarning("No menu items found.");
                    return NotFound("No menu items found.");
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching the menu.");
                return StatusCode(500, "An internal error occurred.");
            }
        }
    }
}
