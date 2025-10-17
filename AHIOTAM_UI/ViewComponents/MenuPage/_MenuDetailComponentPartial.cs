using AHIOTAM_UI.Dtos.MenuDetailDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AHIOTAM_UI.ViewComponents.MenuPage
{
    public class _MenuDetailComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _MenuDetailComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:44390/api/MenuDetail");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultMenuDetailDto>>(jsonData);
                return View(value);
            }
            return View();
        }
    }
}
