using DiveDeepWebApp.Api.Models;
using DiveDeepWebApp.Api.DTOs;

namespace DiveDeepWebApp.Api.Services.Interfaces
{
    public interface IWeatherService
    {
        Task<GeocodeResponse> GetGeocodeByNameAsync(string name);
        Task<WaveHeightResponse> GetWaveHeightByGeocodeAsync(GeocodeResult result);
        Task<CurrentWeatherResponse> GetCurrentWeatherByGeocodeAsync(GeocodeResult result);

        Task<WeatherDTO> GetWeatherDTO(string name);
    }
}
