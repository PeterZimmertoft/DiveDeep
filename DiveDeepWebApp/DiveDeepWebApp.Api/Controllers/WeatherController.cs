using DiveDeepWebApp.Api.DTOs;
using DiveDeepWebApp.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DiveDeepWebApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherService weatherService;

        public WeatherController(IWeatherService weatherService)
        {
            this.weatherService = weatherService;
        }

        [HttpGet("{city}")]
        public async Task<IActionResult> GetAsync(string city)
        {
            WeatherDTO weatherDTO = await weatherService.GetWeatherDTO(city);
            return Ok(weatherDTO);
        }
    }
}
