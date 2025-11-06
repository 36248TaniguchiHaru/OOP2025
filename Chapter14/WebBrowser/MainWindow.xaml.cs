using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WebBrowser;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window{

    public MainWindow(){
        InitializeComponent();
        InitializeAsync();
    }

    private async void InitializeAsync() {
        await WebView.EnsureCoreWebView2Async();

        WebView.CoreWebView2.NavigationStarting += CoreWebView2_NavigationStarting;
        WebView.CoreWebView2.NavigationCompleted += CoreWebView2_NavigationCompleted;

    }

    private void CoreWebView2_NavigationCompleted(object? sender, CoreWebView2NavigationCompletedEventArgs e) {
        LoadingBar.Visibility = Visibility.Collapsed;
        LoadingBar.IsIndeterminate = false;
    }

    private void CoreWebView2_NavigationStarting(object? sender, CoreWebView2NavigationStartingEventArgs e) {
        LoadingBar.Visibility = Visibility.Visible;
        LoadingBar.IsIndeterminate = true;
    }

    private void BackButton_Click(object sender, RoutedEventArgs e) {
        if (WebView.CanGoBack) {
            WebView.GoBack();
        } else {

        }  
    }

    private void FowardButton_Click(object sender, RoutedEventArgs e) {
        if (WebView.CanGoForward) {
            WebView.GoForward();
        } else {

        }
    }

    private void GoButton_Click(object sender, RoutedEventArgs e) {

        if (AdderssBar.Text.Length!=0){
            if (!AdderssBar.Text.StartsWith("http://") & !AdderssBar.Text.StartsWith("https://"))
                AdderssBar.Text = "https://" + AdderssBar.Text;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(AdderssBar.Text);
            request.Method = "HEAD";

            try {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode != HttpStatusCode.OK) {
                    MessageBox.Show("ご指定のURLでは、ホームページを開く事ができませんでした。", "URLエラー", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;

                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message + "\nご指定のURLでは、ホームページを開く事ができませんでした。", "URLエラー", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            WebView.Source = new Uri(AdderssBar.Text);
        } else {
            MessageBox.Show("URLを入力してください。");
        }
    }

}