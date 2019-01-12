using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Notatnik
{
    class CathegoryToPositionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Kategoria kategoria = value as Kategoria;
            Collection<Kategoria> kategorie = Kategorie.Instance.ListaKategorii;
            for (int i = 0; i < kategorie.Count; i++)
                if (kategorie[i].Nazwa.Equals(kategoria.Nazwa))
                    return i;
            return -1;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int pozycja = (int)value;
            return Kategorie.Instance.GetKategoria(pozycja);
        }
    }
}
