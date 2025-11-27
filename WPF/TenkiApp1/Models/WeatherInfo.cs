namespace TenkiApp.Models {
    public class WeatherInfo {
        public string LocationName { get; set; }
        public double Temperature { get; set; }
        public int Humidity { get; set; }
        public double WindSpeed { get; set; }
        public int WindDirection { get; set; }
        public double? RainVolume { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        // 追加：予報日時
        public DateTime DateTime { get; set; }
    }
}