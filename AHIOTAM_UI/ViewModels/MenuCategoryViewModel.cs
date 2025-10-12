// ViewModels/MenuCategoryViewModel.cs
using AHIOTAM_UI.Dtos.MenuDto;
using AHIOTAM_UI.Dtos.CategoryDto;

namespace AHIOTAM_UI.ViewModels
{
    public class MenuCategoryViewModel
    {
        public List<ResultMenuDto> Menus { get; set; }
        public List<ResultCategoryDto> Categories { get; set; }
    }
}
