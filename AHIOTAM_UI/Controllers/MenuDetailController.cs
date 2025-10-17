using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace AHIOTAM_UI.Controllers
{
    public class MenuDetailController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MenuDetailController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetMenuData(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var apiUrl = $"https://localhost:44390/api/MenuDetail/GetMenuAndMenuDetailByMenuId?id={id}";
            try
            {
                var response = await client.GetAsync(apiUrl);
                var content = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    // Return API body and status code to the UI for easier debugging
                    return StatusCode((int)response.StatusCode, new { message = content });
                }

                return Content(content, "application/json");
            }
            catch (System.Exception ex)
            {
                // include exception message for debugging (can be removed later)
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
