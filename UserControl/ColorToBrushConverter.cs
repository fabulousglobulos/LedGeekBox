using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace LedGeekBox.Converters
{
    public class ColorToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var col = (Color)value;
            Color c = Color.FromArgb(col.A, col.R, col.G, col.B);
            return new System.Windows.Media.SolidColorBrush(c);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            SolidColorBrush c = (SolidColorBrush)value;
            Color col = Color.FromArgb(c.Color.A, c.Color.R, c.Color.G, c.Color.B);
            return col;
        }
    }
}