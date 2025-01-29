using System.Text.Json.Serialization;

namespace Capstone_BE.Models
{
    public class DayModel
    {
        // List of Hourly weather
        [JsonPropertyName("hours")]
        public List<HourlyModel> HourlyWeatherDetails { get; set; } = new List<HourlyModel>();

        // Date and Time
        [JsonPropertyName("datetime")]
        public string DateTime                  {  get; set; } = null!;


        // High Temperature for the day
        [JsonPropertyName("tempmax")]
        public double HighTemp                  { get; set; }

        // Low Temperature for the day
        [JsonPropertyName("tempmin")]
        public double LowTemp                   { get; set; }



        // Feels Like
        [JsonPropertyName("feelslike")]
        public double FeelsLike                 {  get; set; }

        // Wind Speed
        [JsonPropertyName("windspeed")]
        public double WindSpeed                 {  get; set; }

        // Sunrise
        [JsonPropertyName("sunrise")]
        public string SunriseTime               { get; set; } = null!;

        // Sunset Times
        [JsonPropertyName("sunset")]
        public string SunsetTime                { get; set;  } = null!;

        // Humidity
        [JsonPropertyName("humidity")]
        public double Humidity                     { get; set; }


        // Conditions
        [JsonPropertyName("description")]        // can also do [JsonPropertyName("conditions")] for a shorter description
        public string DailyWeatherConditions    {  get; set; } = null!;


        // Precipitation %
        [JsonPropertyName("precipprob")]
        public double PrecipitationChance       {  get; set; }

    }

}
