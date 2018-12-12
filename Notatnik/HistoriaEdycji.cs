using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notatnik
{
    public class HistoriaEdycji
    {
        public Collection<WpisHistorii> Wpisy { get; set; }
        
        public HistoriaEdycji()
        {
            Wpisy = new ObservableCollection<WpisHistorii>();
        }

        public void DodajWpis(WpisHistorii wpis)
        {
            Wpisy.Add(wpis);
        }
    }
}
