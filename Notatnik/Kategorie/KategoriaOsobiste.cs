using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Notatnik
{
    public class KategoriaOsobiste : Kategoria
    {
        public KategoriaOsobiste()
        {
            Nazwa = "Osobiste";
            Kolor = new SolidColorBrush(Colors.Blue);
        }
    }
}
