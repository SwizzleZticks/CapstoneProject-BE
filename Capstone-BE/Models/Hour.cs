using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Capstone_BE.Models
{
    public class Hour
    {
        // Temperature
        [JsonPropertyName("temp")]
        public double Temperature { get; set; }

        // Feels Like Temperature
        [JsonPropertyName("feelslike")]
        public double FeelsLike { get; set; }

        // Wind Speed
        [JsonPropertyName("windspeed")]
        public double WindSpeed { get; set; }

        // Precipitation Probability
        [JsonPropertyName("precipprob")]
        public double PrecipitationProbability { get; set; }

        // Weather Conditions
        [JsonPropertyName("conditions")]
        public string Conditions { get; set; } = string.Empty;

    }
}
