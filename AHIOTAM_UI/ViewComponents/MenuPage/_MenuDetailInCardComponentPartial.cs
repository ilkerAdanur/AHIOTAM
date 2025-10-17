using AHIOTAM_UI.Dtos.MenuDetailDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AHIOTAM_UI.ViewComponents.MenuPage
{
    public class _MenuDetailInCardComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _MenuDetailInCardComponentPartial (IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:44390/api/MenuDetail/GetMenuAndMenuDetailByMenuId?id="+id);

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<ResultMenuWithDetailDto>(jsonData);

                ViewBag.menuDetailId = value.MenuId;
                ViewBag.preparationTime = value.PreparationTime;
                ViewBag.calories = value.Calories;
                ViewBag.allergenInfo = value.AllergenInfo;
                ViewBag.isSpicy = value.IsSpicy;
                ViewBag.additionalNotes = value.AdditionalNotes;
                ViewBag.foodDescription = value.FoodDescription;
                ViewBag.foodImageUrl = value.FoodImageUrl;
                ViewBag.foodPrice = value.FoodPrice;
                ViewBag.foodTitle = value.FoodTitle;
                ViewBag.spicealMenu = value.SpicealMenu;

                return View(value);
            }
            return View();
        }
    }
}
