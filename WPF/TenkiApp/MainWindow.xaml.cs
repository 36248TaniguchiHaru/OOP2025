using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows;
using System.ComponentModel;
using System.Windows.Threading;
using System.Linq;
using System.Windows.Controls;
using System.Collections.Generic;

namespace TenkiAppWPF {
    // ▼ 1. データモデル
    public class CityWeather : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        private string _icon;
        public string Icon { get => _icon; set { _icon = value; OnPropertyChanged(nameof(Icon)); } }

        private string _tempMax;
        public string TempMax { get => _tempMax; set { _tempMax = value; OnPropertyChanged(nameof(TempMax)); } }

        private string _tempMin;
        public string TempMin { get => _tempMin; set { _tempMin = value; OnPropertyChanged(nameof(TempMin)); } }

        private string _rainChance;
        public string RainChance { get => _rainChance; set { _rainChance = value; OnPropertyChanged(nameof(RainChance)); } }

        private string _iconColor;
        public string IconColor { get => _iconColor; set { _iconColor = value; OnPropertyChanged(nameof(IconColor)); } }

        public string Name { get; set; }
        public string NameJP { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
    }

    // 🔴 追加: 日本語サジェストとAPI検索名のための構造体
    public struct CityLookup {
        public string JpName { get; set; }
        public string EnName { get; set; }
    }

    // 予報表示用の小項目
    public class ForecastItem {
        public string DateLabel { get; set; } // "明日", "明後日" など
        public string Icon { get; set; }
        public string IconColor { get; set; }
        public string Temp { get; set; }
        public DateTime ForecastDate { get; set; } // 予報の日付を保持
    }

    // ▼ 2. APIレスポンス用クラス
    public class WeatherApiResponse {
        [JsonPropertyName("weather")] public WeatherDescription[] Weather { get; set; }
        [JsonPropertyName("main")] public MainData Main { get; set; }
        [JsonPropertyName("name")] public string Name { get; set; }
    }

    // 予報APIレスポンス用
    public class ForecastApiResponse {
        [JsonPropertyName("list")] public List<ForecastData> List { get; set; }
        [JsonPropertyName("city")] public CityData City { get; set; } // 検索された都市名を取得するために追加
    }
    public class ForecastData {
        [JsonPropertyName("dt")] public long Dt { get; set; }
        [JsonPropertyName("main")] public MainData Main { get; set; }
        [JsonPropertyName("weather")] public WeatherDescription[] Weather { get; set; }
        [JsonPropertyName("dt_txt")] public string DtTxt { get; set; }
    }
    public class CityData {
        [JsonPropertyName("name")] public string Name { get; set; }
    }

    public class WeatherDescription {
        [JsonPropertyName("main")] public string Main { get; set; }
    }

    public class MainData {
        [JsonPropertyName("temp_max")] public double TempMax { get; set; }
        [JsonPropertyName("temp_min")] public double TempMin { get; set; }
        [JsonPropertyName("humidity")] public int Humidity { get; set; }
    }

    // ▼ 3. メインロジック
    public partial class MainWindow : Window, INotifyPropertyChanged {
        private const string API_KEY = "2a878a9cb0ae7b2def67d31d1aa72478";

        // 🔴 修正: 日本語名と英語名を含む都市リスト
        private List<CityLookup> AllCities = new List<CityLookup> {
            new CityLookup { JpName = "東京", EnName = "Tokyo" },
            new CityLookup { JpName = "大阪", EnName = "Osaka" },
            new CityLookup { JpName = "名古屋", EnName = "Nagoya" },
            new CityLookup { JpName = "札幌", EnName = "Sapporo" },
            new CityLookup { JpName = "福岡", EnName = "Fukuoka" },
            new CityLookup { JpName = "仙台", EnName = "Sendai" },
            new CityLookup { JpName = "横浜", EnName = "Yokohama" },
            new CityLookup { JpName = "京都", EnName = "Kyoto" },
            new CityLookup { JpName = "神戸", EnName = "Kobe" },
            new CityLookup { JpName = "川崎", EnName = "Kawasaki" },
            new CityLookup { JpName = "さいたま", EnName = "Saitama" },
            new CityLookup { JpName = "広島", EnName = "Hiroshima" },
            new CityLookup { JpName = "千葉", EnName = "Chiba" },
            new CityLookup { JpName = "北九州", EnName = "Kitakyushu" },
            new CityLookup { JpName = "那覇", EnName = "Naha" },
            new CityLookup { JpName = "新潟", EnName = "Niigata" },
            new CityLookup { JpName = "金沢", EnName = "Kanazawa" },
            new CityLookup { JpName = "高知", EnName = "Kochi" },
            new CityLookup { JpName = "熊本", EnName = "Kumamoto" },
            new CityLookup { JpName = "鹿児島", EnName = "Kagoshima" },
            new CityLookup { JpName = "岡山", EnName = "Okayama" },
            new CityLookup { JpName = "静岡", EnName = "Shizuoka" }
        };

        private string lastSearchedCity = "Tokyo"; // 最後に検索した都市名(API用英語名)を保持

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        public CurrentLocationWeather CurrentLocation { get; set; }
        public ObservableCollection<CityWeather> CityList { get; set; }

        // ComboBoxに表示されるのは日本語の都市名のみ
        public ObservableCollection<string> SuggestedCities { get; set; } = new ObservableCollection<string>();

        // タイトルの日付プロパティ
        private string _titleDate;
        public string TitleDate {
            get => _titleDate;
            set { _titleDate = value; OnPropertyChanged(nameof(TitleDate)); }
        }

        // 🔴 選択された日付プロパティ
        private DateTime _selectedDate = DateTime.Today;
        public DateTime SelectedDate {
            get => _selectedDate;
            set {
                _selectedDate = value;
                TitleDate = value.ToString("M月d日の天気"); // 日付変更時にタイトルを更新
                OnPropertyChanged(nameof(SelectedDate));

                // 選択された日付の天気を表示を試みる
                if (CurrentLocation.LocationName != "地域名を検索してください") {
                    ShowWeatherForSelectedDate(value);
                }
            }
        }

        public MainWindow() {
            InitializeComponent();

            CurrentLocation = new CurrentLocationWeather();

            // 起動時に今日の日付を設定
            TitleDate = DateTime.Now.ToString("M月d日の天気");

            CityList = new ObservableCollection<CityWeather>
            {
                // 地図表示用（OpenWeatherMapの都市名）
                new CityWeather { Name = "Sapporo",  NameJP = "札幌",   X = 450, Y = 70 },
                new CityWeather { Name = "Sendai",   NameJP = "仙台",   X = 470, Y = 220 },
                new CityWeather { Name = "Niigata",  NameJP = "新潟",   X = 330, Y = 290 },
                new CityWeather { Name = "Tokyo",    NameJP = "東京",   X = 390, Y = 470 },
                new CityWeather { Name = "Nagoya",   NameJP = "名古屋", X = 300, Y = 490 },
                new CityWeather { Name = "Kanazawa", NameJP = "金沢",   X = 240, Y = 330 },
                new CityWeather { Name = "Osaka",    NameJP = "大阪",   X = 210, Y = 440 },
                new CityWeather { Name = "Hiroshima",NameJP = "広島",   X = 130, Y = 450 },
                new CityWeather { Name = "Kochi",    NameJP = "高知",   X = 160, Y = 540 },
                new CityWeather { Name = "Fukuoka",  NameJP = "福岡",   X = 10, Y = 435 },
                new CityWeather { Name = "Naha",     NameJP = "那覇",   X = 550,  Y = 550 },
            };

            // 起動時に検索予測リストを日本語名で初期化
            foreach (var city in AllCities.OrderBy(c => c.JpName)) {
                SuggestedCities.Add(city.JpName);
            }

            this.DataContext = this;
            this.Loaded += MainWindow_Loaded;
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e) {
            // 初期表示は東京の天気に設定（lastSearchedCityの初期値）
            await GetWeatherByCityNameAsync(lastSearchedCity);
            await GetForecastByCityNameAsync(lastSearchedCity);

            using (HttpClient client = new HttpClient()) {
                foreach (var city in CityList) {
                    await UpdateCityWeatherAsync(client, city);
                    await Task.Delay(200);
                }
            }
        }

        // DatePickerの値が変更されたときのイベントハンドラー
        private void DateSelector_SelectedDateChanged(object sender, SelectionChangedEventArgs e) {
            if (DateSelector.SelectedDate.HasValue) {
                SelectedDate = DateSelector.SelectedDate.Value;
            }
        }

        // 検索UI関連
        private void SearchComboBox_GotFocus(object sender, RoutedEventArgs e) {
            ComboBox comboBox = (ComboBox)sender;
            if (comboBox.Text == "地域名を入力") {
                comboBox.Text = string.Empty;
                comboBox.Foreground = System.Windows.Media.Brushes.Black;
            }
            comboBox.IsDropDownOpen = true;
        }

        private void SearchComboBox_LostFocus(object sender, RoutedEventArgs e) {
            ComboBox comboBox = (ComboBox)sender;
            if (string.IsNullOrWhiteSpace(comboBox.Text)) {
                comboBox.Text = "地域名を入力";
                comboBox.Foreground = System.Windows.Media.Brushes.Gray;
            }
        }

        // 🔴 修正: ComboBoxのテキストが変更されたときのイベントハンドラー (日本語サジェスト用)
        private void SearchComboBox_TextChanged(object sender, TextChangedEventArgs e) {
            ComboBox comboBox = (ComboBox)sender;
            string filterText = comboBox.Text;

            if (filterText.Length > 0 && filterText != "地域名を入力") {
                // フィルターをかけてサジェストリストを日本語名で更新
                var filteredCities = AllCities
                    // 🔴 日本語名で絞り込み
                    .Where(c => c.JpName.StartsWith(filterText, StringComparison.Ordinal))
                    .OrderBy(c => c.JpName)
                    .Select(c => c.JpName) // 日本語名のみを選択
                    .ToList();

                SuggestedCities.Clear();
                foreach (var city in filteredCities) {
                    SuggestedCities.Add(city);
                }

                // ドロップダウンを開く
                if (!comboBox.IsDropDownOpen) {
                    comboBox.IsDropDownOpen = true;
                }
            } else {
                // 入力がない場合、サジェストリストを空にする
                SuggestedCities.Clear();
            }
        }

        private async void SearchButton_Click(object sender, RoutedEventArgs e) {
            var searchComboBox = this.FindName("SearchComboBox") as ComboBox;
            if (searchComboBox == null) return;

            string searchCityJp = searchComboBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(searchCityJp) || searchCityJp == "地域名を入力") {
                MessageBox.Show("検索する地域名を入力してください。", "入力エラー", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // 🔴 修正: 日本語名からAPI用の英語名に変換
            string searchCityEn = AllCities.FirstOrDefault(c => c.JpName == searchCityJp).EnName;

            // 変換できなかった場合、ユーザーの入力値をそのまま使用する (OpenWeatherMapは日本語入力も許容する場合があるため)
            if (string.IsNullOrEmpty(searchCityEn)) {
                searchCityEn = searchCityJp;
            }

            lastSearchedCity = searchCityEn; // 最後に検索した都市を更新 (API用)
            SelectedDate = DateTime.Today; // 検索実行時は日付を今日に戻す

            // 選択された都市の天気と予報を取得
            await GetWeatherByCityNameAsync(searchCityEn);
            await GetForecastByCityNameAsync(searchCityEn);
        }

        // 選択された日付の天気を表示するメソッド
        private void ShowWeatherForSelectedDate(DateTime selectedDate) {
            var forecastItem = CurrentLocation.AllForecastData
                .FirstOrDefault(f => f.ForecastDate.Date == selectedDate.Date);

            if (forecastItem != null) {
                // 予報データが存在する場合、その日のデータを表示
                // OpenWeatherMapの予報は3時間ごとのため、最高気温のデータを採用する
                var dailyMaxTemp = CurrentLocation.AllForecastData
                    .Where(f => f.ForecastDate.Date == selectedDate.Date)
                    .Max(f => double.Parse(f.Temp.Replace("℃", "")));

                // 12時(昼頃)の天候アイコンと、その日の最高気温を表示
                CurrentLocation.LocationName = AllCities.FirstOrDefault(c => c.EnName == lastSearchedCity).JpName; // 検索した都市名(日本語)を維持
                CurrentLocation.CurrentIcon = forecastItem.Icon;
                CurrentLocation.CurrentIconColor = forecastItem.IconColor;
                CurrentLocation.CurrentTemp = ((int)dailyMaxTemp).ToString();
            } else {
                // 予報データがない場合（APIの5日間制限、または過去の日付）
                if (selectedDate.Date == DateTime.Today) {
                    // 今日を選択した場合、最新の現在地天気APIの結果を再表示
                    // (lastSearchedCityを再検索することで実現)
                    GetWeatherByCityNameAsync(lastSearchedCity);
                } else if (selectedDate.Date < DateTime.Today || selectedDate.Date > DateTime.Today.AddDays(5)) {
                    CurrentLocation.LocationName = $"{AllCities.FirstOrDefault(c => c.EnName == lastSearchedCity).JpName} (予報取得範囲外)";
                    CurrentLocation.CurrentIcon = "❓";
                    CurrentLocation.CurrentTemp = "--";
                    CurrentLocation.CurrentIconColor = "Orange";
                }
            }
        }


        private async Task GetWeatherByCityNameAsync(string cityName) {
            try {
                using (HttpClient client = new HttpClient()) {
                    // 現在の天気 (Today) のデータを取得
                    string url = $"https://api.openweathermap.org/data/2.5/weather?q={cityName}&appid={API_KEY}&units=metric&lang=ja";
                    string jsonString = await client.GetStringAsync(url);
                    var weatherData = JsonSerializer.Deserialize<WeatherApiResponse>(jsonString);

                    this.Dispatcher.Invoke(() => {
                        // 検索結果の都市名を表示
                        CurrentLocation.LocationName = weatherData.Name;
                        // 現在の天気では最高気温を表示 (簡易的な措置)
                        CurrentLocation.CurrentTemp = ((int)weatherData.Main.TempMax).ToString();

                        string weatherMain = weatherData.Weather[0].Main;

                        var tempCity = new CityWeather();
                        SetWeatherIcon(tempCity, weatherMain);

                        CurrentLocation.CurrentIcon = tempCity.Icon;
                        CurrentLocation.CurrentIconColor = tempCity.IconColor;
                    });
                }
            }
            catch (Exception) {
                this.Dispatcher.Invoke(() => {
                    CurrentLocation.LocationName = "見つかりません";
                    CurrentLocation.CurrentIcon = "❌";
                    CurrentLocation.CurrentTemp = "--";
                    CurrentLocation.CurrentIconColor = "Black";
                    CurrentLocation.ForecastList.Clear();
                });
            }
        }

        // 予報APIを取得するメソッド
        private async Task GetForecastByCityNameAsync(string cityName) {
            try {
                using (HttpClient client = new HttpClient()) {
                    string url = $"https://api.openweathermap.org/data/2.5/forecast?q={cityName}&appid={API_KEY}&units=metric&lang=ja";
                    string jsonString = await client.GetStringAsync(url);
                    var forecastData = JsonSerializer.Deserialize<ForecastApiResponse>(jsonString);

                    this.Dispatcher.Invoke(() => {
                        CurrentLocation.ForecastList.Clear();
                        CurrentLocation.AllForecastData.Clear(); // 全データをクリア

                        var today = DateTime.Today;

                        foreach (var item in forecastData.List) {
                            if (DateTime.TryParse(item.DtTxt, out DateTime date)) {
                                var forecastItem = new ForecastItem {
                                    ForecastDate = date,
                                    // 予報リストの表示は「日(曜)」形式
                                    DateLabel = date.ToString("d日(ddd)"),
                                    Temp = ((int)item.Main.TempMax).ToString() + "℃"
                                };

                                var tempCity = new CityWeather();
                                SetWeatherIcon(tempCity, item.Weather[0].Main);
                                forecastItem.Icon = tempCity.Icon;
                                forecastItem.IconColor = tempCity.IconColor;

                                // 全予報データを格納
                                CurrentLocation.AllForecastData.Add(forecastItem);

                                // UIの週間予報エリア (3日分) のためのフィルター
                                // 今日ではない、かつ12:00のデータ（または最も12:00に近いデータ）を代表として表示
                                if (date.Date > today && date.Hour == 12 && CurrentLocation.ForecastList.Count < 3) {
                                    CurrentLocation.ForecastList.Add(forecastItem);
                                }
                            }
                        }

                        // 検索された都市名を更新
                        CurrentLocation.LocationName = AllCities.FirstOrDefault(c => c.EnName == cityName).JpName ?? forecastData.City.Name;

                        // 検索直後は今日の日付の天気を表示
                        ShowWeatherForSelectedDate(DateTime.Today);
                    });
                }
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.WriteLine("Forecast Error: " + ex.Message);
            }
        }

        private async Task UpdateCityWeatherAsync(HttpClient client, CityWeather city) {
            try {
                string url = $"https://api.openweathermap.org/data/2.5/weather?q={city.Name}&appid={API_KEY}&units=metric&lang=ja";
                string jsonString = await client.GetStringAsync(url);
                var weatherData = JsonSerializer.Deserialize<WeatherApiResponse>(jsonString);

                this.Dispatcher.Invoke(() => {
                    city.TempMax = ((int)weatherData.Main.TempMax).ToString();
                    city.TempMin = ((int)weatherData.Main.TempMin).ToString();
                    city.RainChance = weatherData.Main.Humidity + "%";

                    string weatherMain = weatherData.Weather[0].Main;
                    SetWeatherIcon(city, weatherMain);
                });
            }
            catch (Exception) {
                this.Dispatcher.Invoke(() => {
                    city.Icon = "❌";
                    city.IconColor = "Black";
                });
            }
        }

        private void SetWeatherIcon(CityWeather city, string weather) {
            switch (weather) {
                case "Clear": city.Icon = "☀"; city.IconColor = "Yellow"; break;
                case "Clouds": city.Icon = "☁"; city.IconColor = "White"; break;
                case "Rain": case "Drizzle": city.Icon = "☂"; city.IconColor = "Blue"; break;
                case "Snow": case "Mist": case "Fog": city.Icon = "⛄"; city.IconColor = "Cyan"; break;
                case "Thunderstorm": city.Icon = "⚡"; city.IconColor = "Orange"; break;
                default: city.Icon = "？"; city.IconColor = "Black"; break;
            }
        }

        public class CurrentLocationWeather : INotifyPropertyChanged {
            public event PropertyChangedEventHandler PropertyChanged;
            protected void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

            // 内部で全予報データを保持するためのリスト
            public List<ForecastItem> AllForecastData { get; set; } = new List<ForecastItem>();

            private string _locationName = "地域名を検索してください";
            public string LocationName { get => _locationName; set { _locationName = value; OnPropertyChanged(nameof(LocationName)); } }

            private string _currentIcon = "🔍";
            public string CurrentIcon { get => _currentIcon; set { _currentIcon = value; OnPropertyChanged(nameof(CurrentIcon)); } }

            private string _currentTemp = "--";
            public string CurrentTemp { get => _currentTemp; set { _currentTemp = value; OnPropertyChanged(nameof(CurrentTemp)); } }

            private string _currentIconColor = "White";
            public string CurrentIconColor { get => _currentIconColor; set { _currentIconColor = value; OnPropertyChanged(nameof(CurrentIconColor)); } }

            // UIに表示される3日分の予報リスト
            public ObservableCollection<ForecastItem> ForecastList { get; set; } = new ObservableCollection<ForecastItem>();
        }
    }
}