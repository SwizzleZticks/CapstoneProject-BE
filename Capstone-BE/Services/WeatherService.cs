namespace Capstone_BE.Services
{
    public class WeatherService
    {
        private HttpClient _client;
        private DateOnly _date;

        public WeatherService(DateOnly date)
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri("https://weather.visualcrossing.com/VisualCrossingWebServices/rest/services/timeline/")
            };
            _date = date;
        }
    }
}
