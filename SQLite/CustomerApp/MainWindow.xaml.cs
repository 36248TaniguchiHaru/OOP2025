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

namespace CustomerApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window{
    private List<Customer> _costomer = new List<Customer>();
    public MainWindow(){
        InitializeComponent();
        ReadDatabase();

        PersonListView.ItemsSource = _costomer;
    }

    private void ReadDatabase() {
        using (var connection = new SQLiteConnection(App.databasePath)) {
            connection.CreateTable<Customer>();
            _costomer = connection.Table<Customer>().ToList();
        }
    }

    private void AddImageButton_Click(object sender, RoutedEventArgs e) {
        var dialog = new OpenFileDialog();
        dialog.Filter = "jpgファイル|*.jpg";
        if (dialog.ShowDialog() == true){
            var bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(dialog.FileName);
            bitmap.EndInit();
            Picture.Source = bitmap;
        }
    }

    private void SaveButton_Click(object sender, RoutedEventArgs e) {
        var costomer = new Customer() {
            Name = NameBox.Text,
            Phone = PhoneNumberBox.Text,
            Address = AddressBox.Text,

        };
    }

    private void DeleteButton_Click(object sender, RoutedEventArgs e) {

    }

    private void UpdateButton_Click(object sender, RoutedEventArgs e) {

    }

    
}