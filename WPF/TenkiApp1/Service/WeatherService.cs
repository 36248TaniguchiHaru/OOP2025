using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using TenkiApp.Models;
using System.Configuration;

namespace TenkiApp.Services {
    public class WeatherService {
        private readonly string _apiKey;
        private readonly HttpClient _httpClient = new HttpClient();

        public WeatherService() {
            _apiKey = ConfigurationManager.AppSettings["OpenWeatherMapApiKey"];
        }


        public async Task<WeatherInfo> GetCurrentWeatherAsync(double lat, double lon, CancellationToken token) {
            string url = $"https://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&units=metric&lang=ja&appid={_apiKey}";
            var response = await _httpClient.GetStringAsync(url, token);
            var json = JObject.Parse(response);
            return new WeatherInfo {
                Temperature = (double)json["main"]["temp"],
                Humidity = (int)json["main"]["humidity"],
                WindSpeed = (double)json["wind"]["speed"],
                WindDirection = (int)json["wind"]["deg"],
                RainVolume = json["rain"]?["1h"]?.Value<double>(),
                Description = (string)json["weather"][0]["description"],
                Icon = (string)json["weather"][0]["icon"]
            };
        }

        public async Task<List<WeatherInfo>> GetForecastAsync(double lat, double lon, CancellationToken token) {
            string url = $"https://api.openweathermap.org/data/2.5/forecast?lat={lat}&lon={lon}&units=metric&lang=ja&appid={_apiKey}";
            var response = await _httpClient.GetStringAsync(url, token);
            var json = JObject.Parse(response);
            var forecastList = new List<WeatherInfo>();
            foreach (var item in json["list"]) {
                forecastList.Add(new WeatherInfo {
                    Temperature = (double)item["main"]["temp"],
                    Humidity = (int)item["main"]["humidity"],
                    WindSpeed = (double)item["wind"]["speed"],
                    WindDirection = (int)item["wind"]["deg"],
                    RainVolume = item["rain"]?["3h"]?.Value<double>(),
                    Description = (string)item["weather"][0]["description"],
                    Icon = (string)item["weather"][0]["icon"],
                    DateTime = DateTime.Parse((string)item["dt_txt"])
                });
            }
            return forecastList;
        }

    }
}