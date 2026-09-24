using System.Text.Json.Serialization;

namespace DiveDeepWebApp.Models
{
    public class GeocodeResponse
    {
        [JsonPropertyName("results")]
        public List<GeocodeResult> Results { get; set; }
    }

    public class GeocodeResult
    {
        [JsonPropertyName("name")] // name of city
        public string Name { get; set; }

        [JsonPropertyName("latitude")]
        public double Latitude { get; set; }

        [JsonPropertyName("longitude")]
        public double Longitude { get; set; }

        [JsonPropertyName("country")] //name of country, English
        public string Country { get; set; }
    }
}
