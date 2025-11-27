using System.Windows;
using TenkiApp.ViewModels;

namespace TenkiApp {
    public partial class MainWindow : Window {
        private MainViewModel _viewModel;

        public MainWindow() {
            InitializeComponent();
            _viewModel = new MainViewModel();
            this.DataContext = _viewModel;
        }

        private async void OnUpdateClick(object sender, RoutedEventArgs e) {
            // 仮の緯度・経度（群馬県太田市付近）
            double lat = 36.391;
            double lon = 139.070;

            //await _viewModel.LoadWeatherAsync(lat, lon);
        }
    }
}