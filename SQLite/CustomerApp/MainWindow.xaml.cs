using CustomerApp.Data;
using Microsoft.Win32;
using SQLite;
using System.Collections.ObjectModel;
using System.Linq;
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
using System.IO;
using System.Drawing;
using System.Net;

namespace CustomerApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>


public partial class MainWindow : Window {
    private const string ApiEndpoint = "https://zipcloud.ibsnet.co.jp/api/search";
    private byte[] _imageByteArray;
    private List<Customer> _customer = new List<Customer>();
    public MainWindow() {
        InitializeComponent();
        ReadDatabase();

        PersonListView.ItemsSource = _customer;
    }

    void ReadDatabase() {
        using (var connection = new SQLiteConnection(App.databasePath)) {
            connection.CreateTable<Customer>();
            _customer = connection.Table<Customer>().ToList();
        }
    }

    private void AddImageButton_Click(object sender, RoutedEventArgs e) {
        var dialog = new OpenFileDialog();
        dialog.Filter = "jpgファイル|*.jpg";
        if (dialog.ShowDialog() == true) {
            var bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(dialog.FileName);
            bitmap.EndInit();
            Picture.Source = bitmap;
            byte[] _byteArray;
            using (MemoryStream memoryStream = new MemoryStream()) {
                JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(bitmap));
                encoder.Save(memoryStream);
                _byteArray = memoryStream.ToArray();
            }
        }
    }

    private void SaveButton_Click(object sender, RoutedEventArgs e) {

        var customer = new Customer() {
            Name = NameBox.Text,
            Phone = PhoneNumberBox.Text,
            Address = AddressBox.Text,
            Picture = _imageByteArray
        };
        using (var connection = new SQLiteConnection(App.databasePath)) {
            connection.CreateTable<Customer>();
            connection.Insert(customer);
        }
    }

    private void DeleteButton_Click(object sender, RoutedEventArgs e) {
        var item = PersonListView.SelectedItem as Customer;
        using (var connection = new SQLiteConnection(App.databasePath)) {
            if (item != null) {
                connection.CreateTable<Customer>();
                connection.Delete(item);
                ReadDatabase();
                PersonListView.ItemsSource = _customer;
            } else {
                MessageBox.Show("行を選択してください");
            }
        }
    }

    private void UpdateButton_Click(object sender, RoutedEventArgs e) {
        var item = PersonListView.SelectedItem as Customer;
        if (item is null) return;

        using (var connection = new SQLiteConnection(App.databasePath)) {
            connection.CreateTable<Customer>();

            item.Name = NameBox.Text;
            item.Phone = PhoneNumberBox.Text;
            item.Address = AddressBox.Text;
            item.Picture = _imageByteArray;

            connection.Update(item);
        }

        ReadDatabase();
        PersonListView.ItemsSource = _customer;
    }


    private void SearchBox_TextChanged(object sender, TextChangedEventArgs e) {
        var filterList = _customer.Where(x => x.Name.Contains(SearchBox.Text));
        PersonListView.ItemsSource = filterList;
    }

    private void PersonListView_SelectionChanged(object sender, SelectionChangedEventArgs e) {
        var item = PersonListView.SelectedItem as Customer;
        if (item != null) {
            NameBox.Text = item.Name;
            PhoneNumberBox.Text = item.Phone;
            if (item.Picture != null && item.Picture.Length > 0) {
                using (var ms = new MemoryStream(item.Picture)) {
                    var bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.CacheOption = BitmapCacheOption.OnLoad;
                    bitmap.StreamSource = ms;
                    bitmap.EndInit();
                    bitmap.Freeze();
                    Picture.Source = bitmap;
                }
            } else {
                Picture.Source = null;
            }
            AddressBox.Text = item.Address;
        }
    }

    // 郵便番号から住所を取得するメソッド
    public string GetAddressFromZipCode(string zipCode) {
        string apiUrl = $"{ApiEndpoint}?zipcode={zipCode}";

        try {
            // APIにアクセスしてデータを取得
            string result = CallApiAndGetResult(apiUrl);

            // 結果を返す
            return result;
        }
        catch (Exception ex) {
            // エラー時の処理
            Console.WriteLine($"エラー: {ex.Message}");
            return null;
        }
    }

    // APIにアクセスして結果を取得するメソッド
    private string CallApiAndGetResult(string apiUrl) {
        // Webリクエストを作成
        WebRequest request = WebRequest.Create(apiUrl);

        // レスポンスを取得
        using (WebResponse response = request.GetResponse())
        using (var dataStream = response.GetResponseStream())
        using (var reader = new System.IO.StreamReader(dataStream)) {
            // データを文字列として読み込む
            return reader.ReadToEnd();
        }
    }
}