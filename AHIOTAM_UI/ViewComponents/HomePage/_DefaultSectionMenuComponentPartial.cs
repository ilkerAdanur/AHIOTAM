using Microsoft.AspNetCore.Mvc;

namespace AHIOTAM_UI.ViewComponents.HomePage
{
    public class _DefaultSectionMenuComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
