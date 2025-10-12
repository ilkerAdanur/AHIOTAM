using AHIOTAM_Api.Dtos.CategoryDto;

namespace AHIOTAM_Api.Repositories.CategoryRepositories
{
    public interface ICategoryRepository
    {
        Task<List<ResultCategoryDto>> GetAllCategory();
        Task<GetByIdCategoryDto> GetCategoryById(int id);
        Task CreateCategory(CreateCategoryDto createCategoryDto);
        Task UpdateCategory(UpdateCategoryDto updateCategoryDto);
        Task DeleteCategory(int id);
        Task ToggleCategoryStatus(int id);
    }
}
