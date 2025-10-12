using AHIOTAM_UI.Dtos.ContactDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AHIOTAM_UI.ViewComponents.HomePage
{
    public class _DefaultSectionContactComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultSectionContactComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:44390/api/Contact");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultContactDto>>(jsonData);

                var activeContact = values.FirstOrDefault(x => x.IsActive);

                if (activeContact != null)
                {
                    ViewBag.title = activeContact.Title;
                    ViewBag.description = activeContact.Description;
                    ViewBag.Address1 = activeContact.Address1;
                    ViewBag.Address2 = activeContact.Address2;
                    ViewBag.PhoneNumber = activeContact.PhoneNumber;
                    ViewBag.Email = activeContact.Email;
                    ViewBag.ImageUrl = activeContact.ImageUrl;
                }


                return View();
            }
            return View();
        }
    }
}
