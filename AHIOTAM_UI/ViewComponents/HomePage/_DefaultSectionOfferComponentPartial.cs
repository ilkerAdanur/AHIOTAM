using AHIOTAM_UI.Dtos.CategoryDto;
using AHIOTAM_UI.Dtos.HomePageOfferDto;
using AHIOTAM_UI.Dtos.MenuDto;
using AHIOTAM_UI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AHIOTAM_UI.ViewComponents.HomePage
{
    public class _DefaultSectionOfferComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultSectionOfferComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:44390/api/Menu");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultMenuDto>>(jsonData);

                return View(value);
            }
            return View(new MenuCategoryViewModel());
        }
    }
}
