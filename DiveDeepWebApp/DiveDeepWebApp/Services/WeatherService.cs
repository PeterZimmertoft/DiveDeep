using DiveDeepWebApp.Models;
using DiveDeepWebApp.ViewModels;
using System.Globalization;

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

            HttpResponseMessage response = await client.GetAsync($"search?name={name}&count=1");

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
            string latitude = result.Latitude.ToString(CultureInfo.InvariantCulture);
            string longitude = result.Longitude.ToString(CultureInfo.InvariantCulture);

            using HttpClient client = _factory.CreateClient("Weather");

            HttpResponseMessage response = await client.GetAsync($"forecast?latitude={latitude}&longitude={longitude}&current=wind_speed_10m,precipitation,weather_code&timeformat=unixtime");

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
            string latitude = result.Latitude.ToString(CultureInfo.InvariantCulture);
            string longitude = result.Longitude.ToString(CultureInfo.InvariantCulture);

            using HttpClient client = _factory.CreateClient("Wave");

            HttpResponseMessage response = await client.GetAsync($"marine?latitude={latitude}&longitude={longitude}&current=wave_height,sea_surface_temperature&forecast_days=1&timeformat=unixtime");

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

        public async Task<WeatherViewModel> GetWeatherViewModel(string name)
        {
            try
            {
                GeocodeResponse geocode = await GetGeocodeByNameAsync(name);

                CurrentWeatherResponse currentWeather = await GetCurrentWeatherByGeocodeAsync(geocode.Results.FirstOrDefault());

                WaveHeightResponse waveHeight = await GetWaveHeightByGeocodeAsync(geocode.Results.FirstOrDefault());

                int weathercode = currentWeather.CurrentWeather.WeatherCode;
                bool thunder = 
                    weathercode == 17 || 
                    weathercode == 29 || 
                    weathercode == 95 || 
                    weathercode == 96 || 
                    weathercode == 97 || 
                    weathercode == 98 ||
                    weathercode == 99;

                if (waveHeight == null)
                {
                    return new WeatherViewModel
                    {
                        ErrorMessage = "Vi kan kun tjekke havforhold for kystbyer."
                    };
                }
                DateTime modified = DateTime.UnixEpoch.AddSeconds(waveHeight.CurrentHeightAndTemp.Time).ToLocalTime();

                var tempRecomendedThickness = "Anbefaling: ";
                if (waveHeight.CurrentHeightAndTemp.SeaTemp >= 24)
                {
                    tempRecomendedThickness += "våddragt på 3mm";
                }
                else if(waveHeight.CurrentHeightAndTemp.SeaTemp >= 18 && waveHeight.CurrentHeightAndTemp.SeaTemp < 24)
                {
                    tempRecomendedThickness += "våddragt på 5mm";
                }
                else if (waveHeight.CurrentHeightAndTemp.SeaTemp >= 10 && waveHeight.CurrentHeightAndTemp.SeaTemp < 18)
                {
                    tempRecomendedThickness += "våddragt på 7mm";
                }
                else if (waveHeight.CurrentHeightAndTemp.SeaTemp < 10)
                {
                    tempRecomendedThickness += "tørdragt";
                }

                return new WeatherViewModel
                {
                    City = geocode.Results[0].Name,
                    Country = geocode.Results[0].Country,
                    WaveHeight = waveHeight.CurrentHeightAndTemp.WaveHeight,
                    SeaTemp = waveHeight.CurrentHeightAndTemp.SeaTemp,
                    WindSpeed10m = currentWeather.CurrentWeather.WindSpeed10m,
                    Precipitation = currentWeather.CurrentWeather.Precipitation,
                    Thunder = thunder, //if thunder = true, there is thunder
                    SuitRecommendedThickness = tempRecomendedThickness,
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