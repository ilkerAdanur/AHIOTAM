using Microsoft.AspNetCore.Mvc;

namespace AHIOTAM_UI.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
