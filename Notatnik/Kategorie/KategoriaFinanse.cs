using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Notatnik
{
    public class KategoriaFinanse : Kategoria
    {
        public KategoriaFinanse()
        {
            Nazwa = "Finanse";
            Kolor = new SolidColorBrush(Colors.Purple);
        }
    }
}
