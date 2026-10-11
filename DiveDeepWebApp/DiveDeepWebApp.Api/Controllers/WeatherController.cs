using DiveDeepWebApp.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DiveDeepWebApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherController : Controller
    {
        private readonly IWeatherService _weatherService;

        public WeatherController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [HttpGet("{city}")]
        public async Task<IActionResult> WeatherPartial(string city)
        {

            var weatherDTO = await _weatherService.GetWeatherDTO(city);
            return Ok(weatherDTO);
        }
    }
}
