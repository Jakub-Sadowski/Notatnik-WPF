using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Notatnik
{
    public class CathegoryToBrushConverter : IValueConverter
    {
        private Brush brush0 = new SolidColorBrush(Colors.Gray);
        private Brush brush1 = new SolidColorBrush(Colors.Blue);
        private Brush brush2 = new SolidColorBrush(Colors.Red);
        private Brush brush3 = new SolidColorBrush(Colors.Purple);
        private Brush brush4 = new SolidColorBrush(Colors.Green);

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string s = value as string;
            switch(s)
            {
                case "Osobiste":
                    return brush1;
                case "Praca":
                    return brush2;
                case "Finanse":
                    return brush3;
                case "Plany":
                    return brush4;
                default:
                    return brush0;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
