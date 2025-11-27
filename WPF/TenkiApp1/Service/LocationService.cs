using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace TenkiApp.Services {
    public class LocationService {
        private readonly string _apiKey;
        private readonly HttpClient _httpClient = new HttpClient();

        public LocationService() {
            _apiKey = System.Configuration.ConfigurationManager.AppSettings["GoogleMapsApiKey"];
        }

        public async Task<string> GetLocationNameAsync(double lat, double lon, CancellationToken token) {
            string url = $"https://maps.googleapis.com/maps/api/geocode/json?latlng={lat},{lon}&key={_apiKey}";
            try {
                var response = await _httpClient.GetStringAsync(url, token);
                var json = JObject.Parse(response);

                if (json["results"]?.HasValues == true) {
                    return (string)json["results"][0]["formatted_address"];
                }
                return "住所情報が取得できませんでした";
            }
            catch (OperationCanceledException) {
                return "キャンセルされました";
            }
            catch (HttpRequestException ex) {
                return $"通信エラー: {ex.Message}";
            }
        }
    }
}