using AHIOTAM_UI.Dtos.MenuDetailDto;
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

            //var client2 = _httpClientFactory.CreateClient();
            //var response2 = await client2.GetAsync("https://localhost:44390/api/MenuDetail/GetMenuDetailById?id=1");

            


            if (response.IsSuccessStatusCode/* && response2.IsSuccessStatusCode*/)
            {

                var jsonData = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultMenuWithCategoryDto>>(jsonData);

                //var jsonData2 = await response2.Content.ReadAsStringAsync();
                //var value2 = JsonConvert.DeserializeObject<ResultMenuDetailDto>(jsonData2);

                //ViewBag.menuDetailId = value2.MenuDetailId;
                //ViewBag.preparationTime = value2.PreparationTime;
                //ViewBag.calories = value2.Calories;
                //ViewBag.allergenInfo = value2.AllergenInfo;
                //ViewBag.isSpicy = value2.IsSpicy;
                //ViewBag.additionalNotes = value2.AdditionalNotes;
                

                return View(value);
            }
            return View();
        }
    }
}
