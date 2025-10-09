using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
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
using static System.Net.Mime.MediaTypeNames;

namespace ColorChecker {
    public partial class MainWindow : Window {

        public MainWindow() {
            InitializeComponent();
            DataContext = GetColorList();
        }

        private MyColor[] GetColorList() {
            return typeof(Colors).GetProperties(BindingFlags.Public | BindingFlags.Static)
                .Select(i => new MyColor() { Color = (Color)i.GetValue(null), Name = i.Name }).ToArray();
        }

        string[] ColorList = { };

        private void stockbutton_Click(object sender, RoutedEventArgs e) {
            byte r = (byte)rSlider.Value;
            byte g = (byte)gSlider.Value;
            byte b = (byte)bSlider.Value;
            var colorList = GetColorList();
            var matchedColor = colorList.FirstOrDefault(c => c.Color.R == r && c.Color.G == g && c.Color.B == b);
            string rgbText = $" R : {r}     G : {g}     B : {b}";
            if (matchedColor != null) {
                for (int i = listBox.Items.Count - 1; i >= 0; i--) {
                    if (listBox.Items[i].ToString() == rgbText) {
                        listBox.Items.RemoveAt(i);
                    }
                }
                bool exists = false;
                foreach (var item in listBox.Items) {
                    if (item is MyColor mc && mc.Name == matchedColor.Name) {
                        exists = true;
                        break;
                    }
                    if (item is string s && s == matchedColor.Name) {
                        exists = true;
                        break;
                    }
                }
                if (!exists) {
                    listBox.Items.Add(matchedColor);
                }
            } else if (!listBox.Items.Contains(rgbText)) {
                listBox.Items.Add(rgbText);
            }
        }


        public void listBox_SelectionChanged(object sender, RoutedEventArgs e) {
            if (listBox != null && listBox.SelectedItem != null) {
                if (listBox.SelectedItem is MyColor mc) {
                    setSliderValue(mc.Color);
                    colorArea.Background = new SolidColorBrush(mc.Color);
                } else {
                    string select = listBox.SelectedItem.ToString();
                    byte[] rgb = { 0, 0, 0 };
                    MatchCollection arr = Regex.Matches(select, @"\b\d{1,3}\b");
                    int count = 0;
                    foreach (Match match in arr) {
                        if (byte.TryParse(match.Value, out byte value)) {
                            if (count < 3) {
                                rgb[count] = value;
                                count++;
                            }
                        }
                    }
                    colorArea.Background = new SolidColorBrush(Color.FromRgb(rgb[0], rgb[1], rgb[2]));
                    rSlider.Value = rgb[0];
                    gSlider.Value = rgb[1];
                    bSlider.Value = rgb[2];
                }
            }
        }

        private void colorSelectComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            var comboBox = (ComboBox)sender;
            var selectedItem = comboBox.SelectedItem;

            if (selectedItem is MyColor comboSelectMyColor) {
                setSliderValue(comboSelectMyColor.Color);
            }
        }

        private void setSliderValue(Color color) {
            rSlider.Value = color.R;
            gSlider.Value = color.G;
            bSlider.Value = color.B;
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            var myColor = new MyColor {
                Color = Color.FromRgb((byte)rSlider.Value, (byte)gSlider.Value, (byte)bSlider.Value),
                Name = string.Empty
            };
            colorArea.Background = new SolidColorBrush(myColor.Color);

            var colorList = (MyColor[])DataContext;
            var matchedColor = colorList.FirstOrDefault(c => c.Color.R == myColor.Color.R &&
                                                             c.Color.G == myColor.Color.G &&
                                                             c.Color.B == myColor.Color.B);
            if (matchedColor != null) {
                colorSelectComboBox.SelectedItem = matchedColor;
            } else {
                colorSelectComboBox.SelectedItem = null; 
            }
        }
    }
}

