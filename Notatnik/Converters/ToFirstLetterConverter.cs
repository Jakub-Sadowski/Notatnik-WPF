using System;
using System.Windows.Data;

namespace Notatnik
{
    public class ToFirstLetterConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string s = value as string;

            if (!string.IsNullOrEmpty(s))
                return char.ToUpper(s[0]);
            else
                return '-';
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
