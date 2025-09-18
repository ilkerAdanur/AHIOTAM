using Microsoft.AspNetCore.Mvc;

namespace AHIOTAM_UI.ViewComponents.Layout
{
    public class _ScriptViewComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
