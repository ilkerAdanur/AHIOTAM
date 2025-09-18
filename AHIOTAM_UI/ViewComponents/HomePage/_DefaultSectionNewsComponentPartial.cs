using Microsoft.AspNetCore.Mvc;

namespace AHIOTAM_UI.ViewComponents.HomePage
{
    public class _DefaultSectionNewsComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
