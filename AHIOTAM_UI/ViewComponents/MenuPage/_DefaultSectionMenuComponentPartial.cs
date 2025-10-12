using AHIOTAM_UI.Dtos.MenuDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AHIOTAM_UI.ViewComponents.MenuPage
{
    public class _DefaultSectionMenuComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _DefaultSectionMenuComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:44390/api/Menu/GetAllMenuWithCategory");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultMenuWithCategoryDto>>(jsonData);
                return View(value);
            }
            return View();
        }
    }
}
