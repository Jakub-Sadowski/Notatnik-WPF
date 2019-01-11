using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Notatnik
{
    public class KategoriaPlany : Kategoria
    {
        public KategoriaPlany()
        {
            Nazwa = "Plany";
            Kolor = new SolidColorBrush(Colors.Green);
        }
    }
}
