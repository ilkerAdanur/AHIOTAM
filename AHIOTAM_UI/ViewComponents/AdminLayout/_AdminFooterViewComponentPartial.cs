using Microsoft.AspNetCore.Mvc;

namespace AHIOTAM_UI.ViewComponents.AdminLayout
{
    public class _AdminFooterViewComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
