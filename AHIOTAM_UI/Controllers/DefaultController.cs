using Microsoft.AspNetCore.Mvc;

namespace AHIOTAM_UI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
