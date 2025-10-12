using Microsoft.AspNetCore.Mvc;

namespace AHIOTAM_UI.ViewComponents.AdminLayout
{
    public class _AdminFixedButtonViewComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
