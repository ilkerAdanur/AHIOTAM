using AHIOTAM_UI.Dtos.HomePageGalleryDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace AHIOTAM_UI.Controllers
{
    public class GalleryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public GalleryController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44390/api/Galleries");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultHomePageGalleryDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> CreateGallery()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44390/api/Galleries");

            if (!responseMessage.IsSuccessStatusCode)
            {
                // hata varsa boş View döner
                ViewBag.Gallery = new List<SelectListItem>();
                return View();
            }

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultHomePageGalleryDto>>(jsonData);

            ViewBag.Gallery = values
                .OrderBy(x => x.FoodImageUrl)
                .Select(x => new SelectListItem
                {
                    Text = x.FoodImageUrl,
                    Value = x.GalleryId.ToString()
                }).ToList();

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

        public async Task<IActionResult> DeleteGallery(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:44390/api/Galleries/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> ToggleGalleryStatus(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.PostAsync($"https://localhost:44390/api/Galleries/ToggleGalleryStatus/{id}", null);

            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            return View("Error");
        }



    }
}
