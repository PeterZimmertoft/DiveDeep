using DiveDeepWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DiveDeepWebApp.Controllers
{
    public class WeatherController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public WeatherController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> WeatherPartial(string name)
        {
            using HttpClient client = httpClientFactory.CreateClient("DiveDeepApi");

            try
            {
                WeatherViewModel weather = await client.GetFromJsonAsync<WeatherViewModel>($"api/weather/{name}");
                return PartialView("_weather", weather);
            }
            catch
            {
                WeatherViewModel weather = new WeatherViewModel
                {
                    City = name,
                };

                return PartialView("_weather", weather);
            }
        }
    }
}
