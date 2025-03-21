using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using System.Windows.Media;

namespace ActManager.Modules.MainMenu.Components.Converters
{
    public class BooleanToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var parameters = parameter.ToString().Split(';');
            var dict = parameters.ToDictionary(
                p => p.Split(':')[0],
                p => p.Split(':')[1]);

            if ((bool)value)
                return new SolidColorBrush((Color)ColorConverter.ConvertFromString(dict["Read"]));
            return new SolidColorBrush((Color)ColorConverter.ConvertFromString(dict["Unread"]));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
