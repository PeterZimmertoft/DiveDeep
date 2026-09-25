using System.Text.Json.Serialization;

namespace DiveDeepWebApp.Models
{
    public class WaveHeightResponse
    {
        [JsonPropertyName("current")]
        public Current CurrentHeightAndTemp { get; set; }
    }

    public class Current
    {
        [JsonPropertyName("time")]
        public int Time { get; set; }

        [JsonPropertyName("wave_height")]
        public double WaveHeight { get; set; }

        [JsonPropertyName("sea_surface_temperature")]
        public double SeaTemp { get; set; }

    }
}