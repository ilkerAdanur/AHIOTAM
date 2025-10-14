using AHIOTAM_UI.Dtos.CategoryDto;
using AHIOTAM_UI.Dtos.MenuDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace AHIOTAM_UI.Controllers
{
    [Authorize]
    public class MenuController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public MenuController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44390/api/Menu/GetAllMenuWithCategory");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultMenuWithCategoryDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        //[HttpGet]
        //public async Task<IActionResult> CreateMenu()
        //{
        //    var client = _httpClientFactory.CreateClient();
        //    var responseMessage = await client.GetAsync("https://localhost:44390/api/Category");

        //    var jsonData = await responseMessage.Content.ReadAsStringAsync();
        //    var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);

        //    List<SelectListItem> categoryValues = (from x in values.ToList()
        //                                           select new SelectListItem
        //                                           {
        //                                               Text = x.CategoryName,
        //                                               Value = x.CategoryId.ToString()
        //                                           }).ToList();
        //    ViewBag.Category = categoryValues;

        //    return View();
        //}
        [HttpGet]
        public async Task<IActionResult> CreateMenu()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44390/api/Category");

            if (!responseMessage.IsSuccessStatusCode)
            {
                // hata varsa boş View döner
                ViewBag.Category = new List<SelectListItem>();
                return View();
            }

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);

            ViewBag.Category = values
                .OrderBy(x => x.CategoryName)
                .Select(x => new SelectListItem
                {
                    Text = x.CategoryName,
                    Value = x.CategoryId.ToString()
                }).ToList();

            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> CreateMenu(CreateCategoryDto createMenuDto)
        //{
        //    var client = _httpClientFactory.CreateClient();
        //    var jsonData = JsonConvert.SerializeObject(createMenuDto);
        //    StringContent stringContent = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
        //    var responseMessage = await client.PostAsync("https://localhost:44390/api/Menu", stringContent);
        //    if (responseMessage.IsSuccessStatusCode)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}
        [HttpPost]
        public async Task<IActionResult> CreateMenu(CreateMenuDto createMenuDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createMenuDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync("https://localhost:44390/api/Menu", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            // Başarısız olursa kategorileri yeniden doldur
            var categoryResponse = await client.GetAsync("https://localhost:44390/api/Category");
            var categoryJson = await categoryResponse.Content.ReadAsStringAsync();
            var categories = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(categoryJson);

            ViewBag.Category = categories
                .OrderBy(x => x.CategoryName)
                .Select(x => new SelectListItem
                {
                    Text = x.CategoryName,
                    Value = x.CategoryId.ToString()
                }).ToList();

            return View(createMenuDto);
        }


        public async Task<IActionResult> DeleteMenu(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:44390/api/Menu/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateMenu(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44390/api/Menu/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateMenuDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateMenu(UpdateMenuDto updateMenuDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateMenuDto);
            StringContent stringContent = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:44390/api/Menu", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ToggleSpicealMenu(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.PostAsync($"https://localhost:44390/api/Menu/ToggleSpicealMenu/{id}", null);

            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            return View("Error");
        }
        public async Task<IActionResult> MenuStatusChangeToFalse(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44390/api/Menu/MenuStatusChangeToFalse/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> MenuStatusChangeToTrue(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44390/api/Menu/MenuStatusChangeToTrue/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
