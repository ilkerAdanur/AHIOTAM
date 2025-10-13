using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AHIOTAM_UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DashboardController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public DashboardController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            // HttpClientFactory'den bir client örneği oluşturuyoruz.
            var client = _httpClientFactory.CreateClient();

            // API adreslerinize olan istekleri aynı anda başlatıyoruz.
            // Bu, tek tek beklemekten çok daha performanslıdır.
            var task1 = client.GetAsync("https://localhost:44390/api/Statistics/CategoryCount");
            var task2 = client.GetAsync("https://localhost:44390/api/Statistics/MenuCount");
            var task3 = client.GetAsync("https://localhost:44390/api/Statistics/ActiveCategoryCount");
            var task4 = client.GetAsync("https://localhost:44390/api/Statistics/CategoryNameByMaxMenuCount");

            // Tüm isteklerin tamamlanmasını bekliyoruz.
            await Task.WhenAll(task1, task2, task3, task4);

            // --- Gelen verileri okuyup ViewBag'lere atıyoruz ---

            if (task1.Result.IsSuccessStatusCode)
            {
                ViewBag.categoryCount = await task1.Result.Content.ReadAsStringAsync();
            }

            if (task2.Result.IsSuccessStatusCode)
            {
                ViewBag.menuCount = await task2.Result.Content.ReadAsStringAsync();
            }

            if (task3.Result.IsSuccessStatusCode)
            {
                ViewBag.activeCategoryCount = await task3.Result.Content.ReadAsStringAsync();
            }

            if (task4.Result.IsSuccessStatusCode)
            {
                ViewBag.categoryNameByMaxMenuCount = await task4.Result.Content.ReadAsStringAsync();
            }

            return View();
        }
    }
}
