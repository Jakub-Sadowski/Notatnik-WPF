using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notatnik
{
    public class WpisyCollection : Collection<WpisHistorii> { }

    public class HistoriaEdycji
    {
        public WpisyCollection Wpisy { get; set; }
        
        public HistoriaEdycji()
        {
            Wpisy = new WpisyCollection();
        }

        public void DodajWpis(WpisHistorii wpis)
        {
            Wpisy.Add(wpis);
        }
    }
}
