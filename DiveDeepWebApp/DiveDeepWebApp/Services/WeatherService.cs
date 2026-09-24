using DiveDeepWebApp.Models;
using DiveDeepWebApp.ViewModels;

namespace DiveDeepWebApp.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly IHttpClientFactory _factory;

        public WeatherService(IHttpClientFactory httpClientFactory)
        {
            _factory = httpClientFactory;
        }
        public async Task<GeocodeResponse> GetGeocodeByNameAsync(string name)
        {
            using HttpClient client = _factory.CreateClient("Geocode");

            HttpResponseMessage response = await client.GetAsync($"name={name}&count=1");

            try
            {
                if (response == null)
                {
                    return null;
                }

                response.EnsureSuccessStatusCode();

                return await response.Content.ReadFromJsonAsync<GeocodeResponse>();
            }
            catch
            {
                return null;
            }

        }

        public async Task<CurrentWeatherResponse> GetCurrentWeatherByGeocodeAsync(GeocodeResult result)
        {
            double latitude = result.Latitude;
            double longitude = result.Longitude;

            using HttpClient client = _factory.CreateClient("Weather");

            HttpResponseMessage response = await client.GetAsync($"latitude={latitude}&longitude={longitude}&current=wind_speed_10m,precipitation,weather_code&timeformat=unixtime");

            try
            {
                if (response == null)
                {
                    return null;
                }

                response.EnsureSuccessStatusCode();

                return await response.Content.ReadFromJsonAsync<CurrentWeatherResponse>();
            }
            catch
            {
                return null;
            }
        }

        public async Task<WaveHeightResponse> GetWaveHeightByGeocodeAsync(GeocodeResult result)
        {
            double latitude = result.Latitude;
            double longitude = result.Longitude;

            using HttpClient client = _factory.CreateClient("Wave");

            HttpResponseMessage response = await client.GetAsync($"latitude={latitude}&longitude={longitude}&current=wave_height,sea_surface_temperature&forecast_days=1&timeformat=unixtime");

            try
            {
                if (response == null)
                {
                    return null;
                }

                response.EnsureSuccessStatusCode();

                return await response.Content.ReadFromJsonAsync<WaveHeightResponse>();
            }
            catch
            {
                return null;
            }
        }

        public WeatherViewModel GetWeatherViewModel(string name)
        {
            try
            {
                Task<GeocodeResponse> geocodeResponse = GetGeocodeByNameAsync(name);

                Task<CurrentWeatherResponse> currentWeatherResponse = GetCurrentWeatherByGeocodeAsync(geocodeResponse.Result.Results.FirstOrDefault());

                Task<WaveHeightResponse> waveHeightResponse = GetWaveHeightByGeocodeAsync(geocodeResponse.Result.Results.FirstOrDefault());

                int weathercode = currentWeatherResponse.Result.CurrentWeather.WeatherCode;
                bool thunder = 
                    weathercode == 17 || 
                    weathercode == 29 || 
                    weathercode == 95 || 
                    weathercode == 96 || 
                    weathercode == 97 || 
                    weathercode == 98 ||
                    weathercode == 99;

                DateTime modified = DateTime.UnixEpoch.AddSeconds(waveHeightResponse.Result.CurrentHeightAndTemp.Time);

                return new WeatherViewModel
                {
                    City = geocodeResponse.Result.Results[0].Name,
                    Country = geocodeResponse.Result.Results[0].Country,
                    WaveHeight = waveHeightResponse.Result.CurrentHeightAndTemp.WaveHeight,
                    SeaTemp = waveHeightResponse.Result.CurrentHeightAndTemp.SeaTemp,
                    WindSpeed10m = currentWeatherResponse.Result.CurrentWeather.WindSpeed10m,
                    Precipitation = currentWeatherResponse.Result.CurrentWeather.Precipitation,
                    Thunder = thunder, //if thunder = true, there is thunder
                    Modified = modified
                };
            }
            catch
            {
                return new WeatherViewModel
                {
                    ErrorMessage = "Kunne ikke finde oplysninger. Prøv igen."
                };
            }
        }
    }
}