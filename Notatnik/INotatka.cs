using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Notatnik
{
    public interface INotatka
    {
        FlowDocument Tekst { get; set; }
        string Tytul { get; set; }
        string Autor { get; set; }
        Kategoria Kategoria { get; set; }
        DateTime DataUtworzenia { get; set; }
        DateTime DataModyfikacji { get; set; }
        bool Wyroznienie { get; set; }

        HistoriaEdycji HistoriaEdycji { get; set; }
        void ZapiszStanDoHistorii();
        void WczytajStanZHistorii(int pozycja);
    }
}
