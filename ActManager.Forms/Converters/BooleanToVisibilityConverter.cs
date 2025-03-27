using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace ActManager.Forms.Converters
{
    [ValueConversion(typeof(bool), typeof(Visibility))]
    public class BooleanToVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// Преобразует bool в Visibility
        /// </summary>
        /// <param name="value">Значение типа bool</param>
        /// <param name="targetType">Целевой тип</param>
        /// <param name="parameter">Опциональный параметр (если "Inverted", инвертирует логику)</param>
        /// <param name="culture">Культура</param>
        /// <returns>Visibility.Visible или Visibility.Collapsed</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool boolValue = value is bool && (bool)value;
            bool isInverted = parameter is string && string.Equals(parameter.ToString(), "Inverted", StringComparison.OrdinalIgnoreCase);

            if (isInverted)
            {
                return boolValue ? Visibility.Collapsed : Visibility.Visible;
            }
            return boolValue ? Visibility.Visible : Visibility.Collapsed;
        }

        /// <summary>
        /// Преобразует Visibility обратно в bool
        /// </summary>
        /// <param name="value">Значение типа Visibility</param>
        /// <param name="targetType">Целевой тип</param>
        /// <param name="parameter">Опциональный параметр (если "Inverted", инвертирует логику)</param>
        /// <param name="culture">Культура</param>
        /// <returns>true или false</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isVisible = value is Visibility visibility && visibility == Visibility.Visible;
            bool isInverted = parameter is string && string.Equals(parameter.ToString(), "Inverted", StringComparison.OrdinalIgnoreCase);

            if (isInverted)
            {
                return !isVisible;
            }
            return isVisible;
        }
    }
}
