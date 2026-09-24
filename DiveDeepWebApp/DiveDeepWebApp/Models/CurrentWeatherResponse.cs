using System.Text.Json.Serialization;

namespace DiveDeepWebApp.Models
{
    public class CurrentWeatherResponse
    {
        [JsonPropertyName("current")]
        public CurrentWeather CurrentWeather { get; set; }
    }

    public class CurrentWeather
    {
        [JsonPropertyName("wind_speed_10m")] //always km/h
        public double WindSpeed10m { get; set; }

        [JsonPropertyName("precipitation")] // always mm
        public double Precipitation { get; set; }

        [JsonPropertyName("weather_code")] //if 95-99 or 17 or 29 = thunder!
        public int WeatherCode { get; set; }
    }
}
