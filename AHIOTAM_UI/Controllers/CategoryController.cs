using AHIOTAM_UI.Dtos.CategoryDto;
using AHIOTAM_UI.Dtos.GalleryDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AHIOTAM_UI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public CategoryController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44390/api/Category");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateGallery(CreateGalleryDto createGalleryDto)
        {
            if (createGalleryDto.ImageFile == null || createGalleryDto.ImageFile.Length == 0)
            {
                ModelState.AddModelError("ImageFile", "Lütfen bir görsel seçiniz.");
                return View(createGalleryDto);
            }

            // 1. Dosya adını oluştur
            var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(createGalleryDto.ImageFile.FileName);
            var relativePath = "/eatwell/images/" + uniqueFileName;

            // 2. 📁 UI Projesine kaydet
            var uiPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "eatwell", "images", uniqueFileName);
            using (var stream = new FileStream(uiPath, FileMode.Create))
            {
                await createGalleryDto.ImageFile.CopyToAsync(stream);
            }

            // 3. 📡 API’ye gönder
            var client = _httpClientFactory.CreateClient();
            using var content = new MultipartFormDataContent();

            var fileContent = new StreamContent(createGalleryDto.ImageFile.OpenReadStream());
            fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(createGalleryDto.ImageFile.ContentType);
            content.Add(fileContent, "ImageFile", createGalleryDto.ImageFile.FileName);

            content.Add(new StringContent(createGalleryDto.Description ?? ""), "Description");
            content.Add(new StringContent(createGalleryDto.GalleryStatus.ToString()), "GalleryStatus");
            content.Add(new StringContent(relativePath), "FoodImageUrl"); // API'ye yol gönder

            var response = await client.PostAsync("https://localhost:44390/api/Galleries", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(createGalleryDto);
        }

        public async Task<IActionResult> DeleteCategory(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:44390/api/Category/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateCategory(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44390/api/Category/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateCategoryDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateCategoryDto);
            StringContent stringContent = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:44390/api/Category", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ToggleCategoryStatus(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.PostAsync($"https://localhost:44390/api/Category/ToggleCategoryStatus/{id}", null);
            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");
            return View("Error");
        }

    }
}
