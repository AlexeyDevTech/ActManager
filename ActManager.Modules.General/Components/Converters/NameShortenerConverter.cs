using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ActManager.Modules.General.Components.Converters
{
    public class NameShortenerConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length < 3) return string.Empty;

            string firstName = values[0] as string;
            string secondName = values[1] as string;
            string thirdName = values[2] as string;

            return $"{firstName} {GetFirstChar(secondName)}. {GetFirstChar(thirdName)}.";
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        private string GetFirstChar(string input) => !string.IsNullOrEmpty(input) ? input[0].ToString() : string.Empty;
    }
}
