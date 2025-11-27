using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using TenkiApp.Models;
using TenkiApp.Services;

namespace TenkiApp.ViewModels {
    public class MainViewModel : INotifyPropertyChanged {
        private readonly WeatherService _weatherService;
        private readonly LocationService _locationService;
        private CancellationTokenSource _cts;

        private WeatherInfo _currentWeather;
        private DateTime? _selectedDate;
        private string _selectedDetail;
        private string _mapUrl;
        private string _errorMessage;
        public Task LoadWeatherAsync() => UpdateWeatherAsync();

        public WeatherInfo CurrentWeather {
            get => _currentWeather;
            set { _currentWeather = value; OnPropertyChanged(); OnPropertyChanged(nameof(IconUrl)); }
        }

        public ObservableCollection<WeatherInfo> ForecastList { get; } = new ObservableCollection<WeatherInfo>();
        public ICollectionView FilteredForecastView { get; }

        public DateTime? SelectedDate {
            get => _selectedDate;
            set { _selectedDate = value; OnPropertyChanged(); FilteredForecastView.Refresh(); }
        }

        public string SelectedDetail {
            get => _selectedDetail;
            set { _selectedDetail = value; OnPropertyChanged(); FilteredForecastView.Refresh(); }
        }

        public string MapUrl {
            get => _mapUrl;
            set { _mapUrl = value; OnPropertyChanged(); }
        }

        public string IconUrl => CurrentWeather != null ? $"https://openweathermap.org/img/wn/{CurrentWeather.Icon}@2x.png" : null;

        public string ErrorMessage {
            get => _errorMessage;
            set { _errorMessage = value; OnPropertyChanged(); }
        }

        public ICommand UpdateCommand { get; }

        public MainViewModel() {
            _weatherService = new WeatherService();
            _locationService = new LocationService();
            UpdateCommand = new AsyncRelayCommand(UpdateWeatherAsync, () => true);

            FilteredForecastView = CollectionViewSource.GetDefaultView(ForecastList);
            FilteredForecastView.Filter = FilterForecast;
            FilteredForecastView.SortDescriptions.Add(new SortDescription("DateTime", ListSortDirection.Ascending));
        }

        private bool FilterForecast(object obj) {
            if (obj is WeatherInfo info) {
                if (SelectedDate.HasValue && info.DateTime.Date != SelectedDate.Value.Date)
                    return false;
                return true;
            }
            return false;
        }

        private async Task UpdateWeatherAsync() {
            _cts?.Cancel();
            _cts = new CancellationTokenSource();
            var token = _cts.Token;

            try {
                ErrorMessage = null;
                double lat = 36.4;
                double lon = 139.4;

                CurrentWeather = await _weatherService.GetCurrentWeatherAsync(lat, lon, token);
                var forecast = await _weatherService.GetForecastAsync(lat, lon, token);

                ForecastList.Clear();
                foreach (var item in forecast)
                    ForecastList.Add(item);

                var locationName = await _locationService.GetLocationNameAsync(lat, lon, token);
                CurrentWeather.LocationName = locationName;

                MapUrl = $"https://www.google.com/maps?q={lat},{lon}";
                FilteredForecastView.Refresh();
            }
            catch (OperationCanceledException) {
                ErrorMessage = "更新がキャンセルされました。";
            }
            catch (Exception ex) {
                ErrorMessage = $"エラー: {ex.Message}";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

    // 非同期対応RelayCommand
    public class AsyncRelayCommand : ICommand {
        private readonly Func<Task> _execute;
        private readonly Func<bool> _canExecute;

        public AsyncRelayCommand(Func<Task> execute, Func<bool> canExecute = null) {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter) => _canExecute == null || _canExecute();
        public async void Execute(object parameter) => await _execute();
        public event EventHandler CanExecuteChanged;
        public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}