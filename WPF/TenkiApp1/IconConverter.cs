using System;
using System.Globalization;
using System.Windows.Data;

public class IconConverter : IValueConverter {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
        if (value is string iconCode) {
            return $"https://openweathermap.org/img/wn/{iconCode}@2x.png";
        }
        return null;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
        throw new NotImplementedException();
    }
}