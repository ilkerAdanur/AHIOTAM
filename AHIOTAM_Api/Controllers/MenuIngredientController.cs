using AHIOTAM_Api.Repositories.MenuIngredientRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AHIOTAM_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuIngredientController : ControllerBase
    {
        private readonly IMenuIngredientRepository _menuIngredientRepository;
        public MenuIngredientController(IMenuIngredientRepository menuIngredientRepository)
        {
            _menuIngredientRepository = menuIngredientRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllMenuIngredient()
        {
            var result = await _menuIngredientRepository.GetAllMenuIngredient();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMenuIngredientById(int id)
        {
            var result = await _menuIngredientRepository.GetMenuIngredientById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateMenuIngredient(Dtos.MenuIngredientDto.CreateMenuIngredientDto createMenuIngredientDto)
        {
            await _menuIngredientRepository.CreateMenuIngredient(createMenuIngredientDto);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateMenuIngredient(Dtos.MenuIngredientDto.UpdateMenuIngredientDto updateMenuIngredientDto)
        {
            var existingMenuIngredient = await _menuIngredientRepository.GetMenuIngredientById(updateMenuIngredientDto.MenuIngredientId);
            if (existingMenuIngredient == null)
            {
                return NotFound();
            }
            await _menuIngredientRepository.UpdateMenuIngredient(updateMenuIngredientDto);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenuIngredient(int id)
        {
            await _menuIngredientRepository.DeleteMenuIngredient(id);
            return Ok(id);
        }

    }
}
