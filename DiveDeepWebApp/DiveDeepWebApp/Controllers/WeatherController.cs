using DiveDeepWebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace DiveDeepWebApp.Controllers
{
    public class WeatherController : Controller
    {
        private readonly IWeatherService _weatherService;
        public WeatherController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }
        public async Task<IActionResult> WeatherPartial(string name)
        {
            var weatherVM =  await _weatherService.GetWeatherViewModel(name);
            return PartialView("_weather", weatherVM);
        }
    }
}
