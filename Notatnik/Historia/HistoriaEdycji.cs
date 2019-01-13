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
        private const int MAX_SIZE = 10;
        public WpisyCollection Wpisy { get; }
        
        public HistoriaEdycji()
        {
            Wpisy = new WpisyCollection();
        }

        public void DodajWpis(WpisHistorii wpis)
        {
            Wpisy.Add(wpis);
            if (Wpisy.Count > MAX_SIZE)
                Wpisy.RemoveAt(0);
        }
    }
}
