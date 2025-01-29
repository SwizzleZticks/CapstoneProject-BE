using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Capstone_BE.Models
{
    public class Hour
    {
        //High Temps
        [JsonPropertyName("tempmax")]
        public double HighTemp { get; set; }

        // Low Temp
        [JsonPropertyName("tempmin")]
        public double LowTemp { get; set; }

        [JsonPropertyName("windspeed")]
        public double WindSpeed { get; set; }

        // Precipitation 
        [JsonPropertyName("precipprob")]
        public int Precipitation { get; set; }

        //Feels Like
        [JsonPropertyName("feelslike")]
        public int FeelsLike { get; set; }
       
    }
}
