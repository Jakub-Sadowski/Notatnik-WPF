using System;
using System.Globalization;
using System.Windows.Data;

namespace Notatnik
{
    public class NoTitleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (string.IsNullOrEmpty(value as string))
                return "[Brak tytułu]";
            else
                return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
