using AHIOTAM_Api.Dtos.HomePageAboutDto;
using AHIOTAM_Api.Repositories.HomePageAboutRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AHIOTAM_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomePageAboutController : ControllerBase
    {
        private readonly IHomePageAboutRepository _homePageAboutRepository;
        public HomePageAboutController(IHomePageAboutRepository homePageAboutRepository)
        {
            _homePageAboutRepository = homePageAboutRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAboutAsync()
        {
            var values = await _homePageAboutRepository.GetAllAboutAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var values = await _homePageAboutRepository.GetByIdAsync(id);
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAboutAsync(CreateHomePageAboutDto createAboutDto)
        {
            await _homePageAboutRepository.CreateAboutAsync(createAboutDto);
            return Ok("Hakkımız kısmı başarılı şekilde yüklendi : " + createAboutDto.ToString());
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAboutAsync(UpdateHomePageAboutDto updateAboutDto)
        {
            await _homePageAboutRepository.UpdateAboutAsync(updateAboutDto);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAboutAsync(int id)
        {
            await _homePageAboutRepository.DeleteAboutAsync(id);
            return Ok();
        }
    }
}
