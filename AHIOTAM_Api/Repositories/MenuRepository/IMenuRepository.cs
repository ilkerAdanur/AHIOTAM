using AHIOTAM_Api.Dtos.MenuDto;

namespace AHIOTAM_Api.Repositories.MenuRepository
{
    public interface IMenuRepository
    {
        Task<List<ResultMenuDto>> GetAllMenu();
        Task<GetByIdMenuDto> GetMenuById(int id);
        Task CreateMenu(CreateMenuDto createMenuDto);
        Task UpdateMenu(UpdateMenuDto updateMenurDto);
        Task DeleteMenu(int id);
        Task<List<ResultMenuWithCategoryDto>> GetAllMenuWithCategory();
        Task<List<ResultMenuWithCategoryDto>> GetTop6MenusPerCategoryAsync();
        Task<List<ResultLast3MenuWithCategoryDto>> GetLast3MenuWithCategory();
        Task MenuStatusChangeToFalse(int id);
        Task MenuStatusChangeToTrue(int id);
        Task ToggleSpicealMenu(int id);
    }
}
