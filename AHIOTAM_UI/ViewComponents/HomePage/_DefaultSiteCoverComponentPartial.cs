using Microsoft.AspNetCore.Mvc;

namespace AHIOTAM_UI.ViewComponents.HomePage
{
    public class _DefaultSiteCoverComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
