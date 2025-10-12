using AHIOTAM_Api.Dtos.MenuDetailDto;
using AHIOTAM_Api.Repositories.MenuDetailRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AHIOTAM_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuDetailController : ControllerBase
    {
        private readonly IMenuDetailRepository _menuDetailRepository;
        public MenuDetailController(IMenuDetailRepository menuDetailRepository)
        {
            _menuDetailRepository = menuDetailRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllMenuDetail()
        {
            var result = await _menuDetailRepository.GetAllMenuDetail();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMenuDetailById(int id)
        {
            var result = await _menuDetailRepository.GetMenuDetailById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateMenuDetail(CreateMenuDetailDto createMenuDetailDto)
        {
            await _menuDetailRepository.CreateMenuDetail(createMenuDetailDto);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateMenuDetail(UpdateMenuDetailDto updateMenuDetailDto)
        {
            var existingMenuDetail = await _menuDetailRepository.GetMenuDetailById(updateMenuDetailDto.MenuDetailId);
            if (existingMenuDetail == null)
            {
                return NotFound();
            }
            await _menuDetailRepository.UpdateMenuDetail(updateMenuDetailDto);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenuDetail(int id)
        {
            await _menuDetailRepository.DeleteMenuDetail(id);
            return Ok(id);
        }
    }
}
