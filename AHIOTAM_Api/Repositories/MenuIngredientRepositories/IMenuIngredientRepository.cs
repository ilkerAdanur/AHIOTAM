using AHIOTAM_Api.Dtos.MenuIngredientDto;

namespace AHIOTAM_Api.Repositories.MenuIngredientRepositories
{
    public interface IMenuIngredientRepository
    {
        Task<List<ResultMenuIngredientDto>> GetAllMenuIngredient();
        Task<GetByIdMenuIngredientDto> GetMenuIngredientById(int id);
        Task CreateMenuIngredient(CreateMenuIngredientDto createMenuIngredientDto);
        Task UpdateMenuIngredient(UpdateMenuIngredientDto updateMenuIngredientrDto);
        Task DeleteMenuIngredient(int id);
    }
}
