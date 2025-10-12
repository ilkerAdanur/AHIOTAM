using AHIOTAM_UI.Dtos.HomePageGalleryDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AHIOTAM_UI.ViewComponents.HomePage
{
    public class _DefaultSectionGalleryComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultSectionGalleryComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:44390/api/Galleries/GetGalleriesWithActiveStatus");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultHomePageGalleryDto>>(jsonData);
                return View(value);
            }
            return View();
        }
    }
}
