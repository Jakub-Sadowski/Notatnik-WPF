using System;
using System.Windows.Data;

namespace Notatnik
{
    public class NoAuthorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string autor = value as string;
            if (string.IsNullOrEmpty(autor))
                return "<brak autora>";
            else
                return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
