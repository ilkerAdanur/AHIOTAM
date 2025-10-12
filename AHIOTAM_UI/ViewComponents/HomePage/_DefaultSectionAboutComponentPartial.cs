using AHIOTAM_UI.Dtos.HomePageAboutDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AHIOTAM_UI.ViewComponents.HomePage
{
    public class _DefaultSectionAboutComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultSectionAboutComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:44390/api/HomePageAbout");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultHomePageAboutDto>>(jsonData);

                ViewBag.title = values.Select(x => x.Title).FirstOrDefault();
                ViewBag.description = values.Select(x => x.Description).FirstOrDefault();
                ViewBag.aboutImageUrl = values.Select(x => x.AboutImageUrl).FirstOrDefault();


                return View();
            }
            return View();
        }
    }
}