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
        /// <summary>
        /// Główny dokument powiązany z notatką.
        /// </summary>
        FlowDocument Tekst { get; set; }

        string Tytul { get; set; }
        string Autor { get; set; }
        Kategoria Kategoria { get; set; }
        DateTime DataUtworzenia { get; set; }
        DateTime DataModyfikacji { get; set; }
        bool Wyroznienie { get; set; }

        /// <summary>
        /// Przechowywana historia edycji notatki, zawiera listę pamiątek.
        /// </summary>
        HistoriaEdycji HistoriaEdycji { get; set; }

        /// <summary>
        /// Tworzenie nowego obiektu pamiątki i dodanie go do historii.
        /// </summary>
        void ZapiszStanDoHistorii();

        /// <summary>
        /// Wczytanie obiektu pamiątki i pobranie jego stanu.
        /// </summary>
        /// <param name="wpis">
        /// Obiekt pamiątki.
        /// </param>
        void WczytajStanZHistorii(WpisHistorii wpis);
    }
}
