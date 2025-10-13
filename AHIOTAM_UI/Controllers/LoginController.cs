using AHIOTAM_UI.Dtos.LoginDtos;
using AHIOTAM_UI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Json;

namespace AHIOTAM_UI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public LoginController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(CreateLoginDto createLoginDto)
        {
            var client = _httpClientFactory.CreateClient();
            var content = new StringContent(JsonSerializer.Serialize(createLoginDto), System.Text.Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:44390/api/Login", content);
            if (response.IsSuccessStatusCode)
            {
                var jsponData = await response.Content.ReadAsStringAsync();
                var tokenModel = JsonSerializer.Deserialize<JwtResponseModel>(jsponData, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
                if(tokenModel != null)
                {
                    JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                    var token = handler.ReadJwtToken(tokenModel.Token);
                    var claims = token.Claims.ToList();
                    if(tokenModel.Token != null)
                    {
                        claims.Add(new Claim("ahiotamtoken", tokenModel.Token));
                        var claimsIdentity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);
                        var authProps = new AuthenticationProperties
                        {
                            
                            ExpiresUtc = tokenModel.ExpireDate, //DateTimeOffset.UtcNow.AddMinutes(60),
                            IsPersistent = true
                        };

                        await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProps);
                        return RedirectToAction("Index", "Dashboard");
                    }
                }
            }
            return View();
        }
    }
}
