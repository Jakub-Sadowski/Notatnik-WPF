using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Notatnik
{
    public class NoteToCathegoryPositionConverter : IValueConverter
    {
        public NotatkiData Data { get; set; }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            INotatka notatka = value as INotatka;
            if (notatka == null)
                return -1;
            return notatka.Kategoria.PozycjaNotatki(notatka, Data);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
