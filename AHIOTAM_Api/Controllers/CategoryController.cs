using AHIOTAM_Api.Dtos.CategoryDto;
using AHIOTAM_Api.Models.Context;
using AHIOTAM_Api.Repositories.CategoryRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AHIOTAM_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCategory()
        {
            var values = await _categoryRepository.GetAllCategory();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var values = await _categoryRepository.GetCategoryById(id);
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            await _categoryRepository.CreateCategory(createCategoryDto);
            return Ok("Kategori başarılı şekilde eklendi : " + createCategoryDto.ToString());
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _categoryRepository.DeleteCategory(id);
            return Ok(id);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            await _categoryRepository.UpdateCategory(updateCategoryDto);
            return Ok();
        }
        [HttpPost("ToggleCategoryStatus/{id}")]
        public async Task<IActionResult> ToggleCategoryStatus(int id)
        {
            await _categoryRepository.ToggleCategoryStatus(id);
            return Ok();
        }

    }
}
