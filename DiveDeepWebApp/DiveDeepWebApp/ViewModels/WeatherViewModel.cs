using System.Text.Json.Serialization;

namespace DiveDeepWebApp.ViewModels
{
    public class WeatherViewModel
    {
        public string City { get; set; }

        public string Country { get; set; }

        public double WaveHeight { get; set; } // always m - < 1,5 m all good, if > don't swim

        public double SeaTemp { get; set; } // see docs for details

        public double WindSpeed10m { get; set; } //always km/h - if < 8 m/s → all good, if > don't swim

        public double Precipitation { get; set; } // always mm - if < 2mm/t → all good, if > don't swim

        public bool Thunder { get; set; } //if 95-99 or 17 or 29 = thunder, don't swim

        public DateTime Modified { get; set; }
        public string ErrorMessage { get; set; }
    }
}
