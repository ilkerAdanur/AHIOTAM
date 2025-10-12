using AHIOTAM_Api.Dtos.MenuDto;
using AHIOTAM_Api.Repositories.MenuRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AHIOTAM_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuRepository _menuRepository;
        public MenuController(IMenuRepository MenuRepository)
        {
            _menuRepository = MenuRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllMenu()
        {
            var values = await _menuRepository.GetAllMenu();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMenuById(int id)
        {
            var values = await _menuRepository.GetMenuById(id);
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateMenu(CreateMenuDto createMenuDto)
        {
            await _menuRepository.CreateMenu(createMenuDto);
            return Ok("Hakkımız kısmı başarılı şekilde yüklendi : " + createMenuDto.ToString());
        }
        [HttpPut]
        public async Task<IActionResult> UpdateMenu(UpdateMenuDto updateMenuDto)
        {
            await _menuRepository.UpdateMenu(updateMenuDto);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenu(int id)
        {
            await _menuRepository.DeleteMenu(id);
            return Ok();
        }
        [HttpGet("GetAllMenuWithCategory")]
        public async Task<IActionResult> GetAllMenuWithCategory()
        {
            var values = await _menuRepository.GetAllMenuWithCategory();
            return Ok(values);
        }
        [HttpGet("GetLast3MenuWithCategory")]
        public async Task<IActionResult> GetLast3MenuWithCategory()
        {
            var values = await _menuRepository.GetLast3MenuWithCategory();
            return Ok(values);
        }
        [HttpGet("MenuStatusChangeToFalse/{id}")]
        public async Task<IActionResult> MenuStatusChangeToFalse(int id)
        {
            _menuRepository.MenuStatusChangeToFalse(id);
            return Ok("Menü Pasif oldu.");
        }
        [HttpGet("MenuStatusChangeToTrue/{id}")]
        public async Task<IActionResult> MenuStatusChangeToTrue(int id)
        {
            _menuRepository.MenuStatusChangeToTrue(id);
            return Ok("Menü Aktif oldu.");
        }
        [HttpPost("ToggleSpicealMenu/{id}")]
        public async Task<IActionResult> ToggleSpicealMenu(int id)
        {
            await _menuRepository.ToggleSpicealMenu(id);
            return Ok();
        }
        [HttpGet("GetTop6MenusPerCategoryAsync")]
        public async Task<IActionResult> GetTop6MenusPerCategoryAsync()
        {
            var values = await _menuRepository.GetTop6MenusPerCategoryAsync();
            return Ok(values);
        }

    }
}
