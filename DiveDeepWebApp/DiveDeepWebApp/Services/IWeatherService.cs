using DiveDeepWebApp.Models;
using DiveDeepWebApp.ViewModels;

namespace DiveDeepWebApp.Services
{
    public interface IWeatherService
    {
        // en metode, der kan hente fra Geocode og putte det ind i GeocodeReponse
        // en mdetode, der kan hente WaveHeight og putte ind i modelklassen
        // en metde, der kan hente CurrentWeather-objektet
        // samle alle tre og putte ind i wn viewmodel, der returnerer de tre sammen


        Task<GeocodeResponse> GetGeocodeByNameAsync(string name);

        Task<WaveHeightResponse> GetWaveHeightByGeocodeAsync(GeocodeResult result);

        Task<CurrentWeatherResponse> GetCurrentWeatherByGeocodeAsync(GeocodeResult result);

        WeatherViewModel GetWeatherViewModel(string name);
    }
}
