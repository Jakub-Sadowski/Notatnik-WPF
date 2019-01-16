using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notatnik
{
    /// <summary>
    /// Klasa dziedzicząca z kolekcji wpisów. Konieczna do serializacji.
    /// </summary>
    public class WpisyCollection : ObservableCollection<WpisHistorii> { }

    /// <summary>
    /// Przechowuje do 10 obiektów pamiątek (wpisów). 
    /// Po przekroczeniu tej wartości usuwa stare wpisy.
    /// Powiązana jest z konkretnym obiektem Notatki.
    /// </summary>
    public class HistoriaEdycji
    {
        private const int MAX_SIZE = 10;
        public WpisyCollection Wpisy { get; set; }
        
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
