using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using System.Windows.Media;

namespace ActManager.Modules.MainMenu.Components.Converters
{
    public class StatusToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var parameters = parameter.ToString().Split(';');
            var dict = parameters.ToDictionary(
                p => p.Split(':')[0],
                p => p.Split(':')[1]);

            string status = value?.ToString() ?? "";
            switch (status)
            {
                case "Оплачен":
                    return new SolidColorBrush((Color)ColorConverter.ConvertFromString(dict["Оплачен"]));
                case "Обработка":
                    return new SolidColorBrush((Color)ColorConverter.ConvertFromString(dict["Обработка"]));
                case "Просрочен":
                    return new SolidColorBrush((Color)ColorConverter.ConvertFromString(dict["Просрочен"]));
                default:
                    return new SolidColorBrush(Colors.White);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
