using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Resources;
using System.Windows;

namespace Notatnik
{
    public class XamlToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string path = parameter.ToString();
            StreamResourceInfo sri = Application.GetResourceStream(new Uri(path, UriKind.Relative));
            if (sri != null)
            {
                Stream stream = sri.Stream;
                var image = XamlReader.Load(stream) as DrawingImage;
                if (image != null)
                    return image;
            }
            throw new Exception("Nie ma takiego pliku.");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
