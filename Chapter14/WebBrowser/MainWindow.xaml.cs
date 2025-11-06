using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
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
    }

    private void BackButton_Click(object sender, RoutedEventArgs e) {
        WebView.GoBack();
    }

    private void FowardButton_Click(object sender, RoutedEventArgs e) {
        WebView.GoForward();
    }

    private void GoButton_Click(object sender, RoutedEventArgs e) {
        //WebView.Source = new Uri(AdderssBar.Text);
        if (AdderssBar.Text != ""){
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
        } else {
            MessageBox.Show("URLを入力してください。");
        }
    }

}