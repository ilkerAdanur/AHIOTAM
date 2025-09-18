using Microsoft.AspNetCore.Mvc;

namespace AHIOTAM_UI.ViewComponents.HomePage
{
    public class _DefaultSectionGalleryComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
