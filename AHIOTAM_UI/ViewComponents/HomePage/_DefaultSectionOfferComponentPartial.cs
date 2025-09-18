using Microsoft.AspNetCore.Mvc;

namespace AHIOTAM_UI.ViewComponents.HomePage
{
    public class _DefaultSectionOfferComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
