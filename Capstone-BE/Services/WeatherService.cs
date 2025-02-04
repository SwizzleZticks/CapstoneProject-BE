using Capstone_BE.Models;
using System.Text.Json;

namespace Capstone_BE.Services
{
    public class WeatherService
    {
        private readonly HttpClient _client = new()
        {
            BaseAddress = new Uri("https://weather.visualcrossing.com/VisualCrossingWebServices/rest/services/timeline/")
        };

        private readonly string _currentDate = DateTime.Now.ToString("yyyy-MM-dd");
        private readonly string _key = Environment.GetEnvironmentVariable("API_KEY");

        public WeatherService()
        {
            if (string.IsNullOrEmpty(_key))
            {
                throw new Exception("API key is missing. Ensure it is set in the environment variables.");
            }
        }

        public async Task<List<Day>> GetSevenDayForecastAsync(string location) //Gets all 7 days with every hour of the day
        {
            string endDate = AddDaysToCurrentDate();
            string requestUrl = $"{location}/{_currentDate}/{endDate}?key={_key}";
            try
            {
                HttpResponseMessage response = await _client.GetAsync(requestUrl);

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    var timeLineResponse = JsonSerializer.Deserialize<TimeLine>(json);
                    return timeLineResponse?.Days ?? new List<Day>();
                }
                else
                {
                    throw new Exception($"Weather service returned unexpected status code {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching timeline data.", ex);
            }
        }

        public async Task<Day> GetDayForecastAsync(string location)
        {
            string requestUrl = $"{location}/{_currentDate}?key={_key}";

            try
            {
                HttpResponseMessage response = await _client.GetAsync(requestUrl);

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    var timeLineResponse = JsonSerializer.Deserialize<TimeLine>(json);
                    var day = timeLineResponse?.Days.FirstOrDefault(d => d.DateTime.StartsWith(_currentDate));

                    return day ?? throw new Exception("No matching day found for the current date.");
                }
                else
                {
                    throw new Exception($"Weather service returned unexpected status code {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching daily forecast info data.", ex);
            }
        }

        public async Task<List<Hour>> GetHourlyForecastAsync(string location)
        {
            string requestUrl = $"{location}/{_currentDate}?key={_key}";
            try
            {
                HttpResponseMessage response = await _client.GetAsync(requestUrl);

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    var timeLineResponse = JsonSerializer.Deserialize<TimeLine>(json);

                    var today = timeLineResponse?.Days.FirstOrDefault(d => d.DateTime.StartsWith(_currentDate));

                    return today?.HourlyWeatherDetails ?? new List<Hour>();
                }
                else
                {
                    throw new Exception($"Weather service returned unexpected status code {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching hourly forecast data.", ex);
            }
        }

        private string AddDaysToCurrentDate()
        {
            DateTime dateTime = DateTime.Parse(_currentDate);
            DateTime endDate = dateTime.AddDays(7);
            return endDate.ToString("yyyy-MM-dd");
        }
    }
}