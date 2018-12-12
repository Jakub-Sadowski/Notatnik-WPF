using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Notatnik
{
    public class CathegoryToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Kategoria kategoria = (Kategoria)value;
            return kategoria.Kolor;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
