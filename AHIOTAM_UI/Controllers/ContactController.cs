using AHIOTAM_UI.Dtos.ContactDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace AHIOTAM_UI.Controllers
{
    [Authorize]
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        // Contact listesini göster (Admin paneli için)
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44390/api/Contact");

            if (!responseMessage.IsSuccessStatusCode)
                return View(new List<ResultContactDto>());

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var contacts = JsonConvert.DeserializeObject<List<ResultContactDto>>(jsonData);

            return View(contacts);
        }

        // Yeni Contact Ekleme [GET]
        [HttpGet]
        public IActionResult CreateContact()
        {
            return View();
        }

        // Yeni Contact Ekleme [POST]
        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://localhost:44390/api/Contact", stringContent);

            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            return View(dto);
        }

        // Contact Silme
        public async Task<IActionResult> DeleteContact(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:44390/api/Contact/{id}");

            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            return View("Error");
        }

        // Contact Güncelleme [GET]
        [HttpGet]
        public async Task<IActionResult> UpdateContact(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:44390/api/Contact/{id}");

            if (!response.IsSuccessStatusCode)
                return View("Error");

            var jsonData = await response.Content.ReadAsStringAsync();
            var contact = JsonConvert.DeserializeObject<UpdateContactDto>(jsonData);

            return View(contact);
        }

        // Contact Güncelleme [POST]
        [HttpPost]
        public async Task<IActionResult> UpdateContact(UpdateContactDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await client.PutAsync("https://localhost:44390/api/Contact", content);

            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            return View(dto);
        }

        // Contact Aktiflik Değiştir (Sadece bir tanesi aktif olacak)
        [HttpPost]
        public async Task<IActionResult> SetActiveContact(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.PostAsync($"https://localhost:44390/api/Contact/SetActiveContact/{id}", null);

            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            return View("Error");
        }
    }
}
