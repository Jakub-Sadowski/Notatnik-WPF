using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notatnik
{
    public interface IFiltr
    {
        bool TytulWarunek { get; set; }
        bool TytulDokladny { get; set; }
        bool TytulZawiera { get; set; }
        string Tytul { get; set; }

        bool AutorWarunek { get; set; }
        string Autor { get; set; }

        bool SlowaKluczoweWarunek { get; set; }
        bool SlowaKluczoweWszystkie { get; set; }
        bool SlowaKluczoweJakiekolwiek { get; set; }
        string SlowaKluczowe { get; set; }

        bool KategoriaWarunek { get; set; }
        Kategoria Kategoria { get; set; }

        bool DataUtworzeniaWarunek { get; set; }
        bool DataUtworzeniaOdWarunek { get; set; }
        bool DataUtworzeniaDoWarunek { get; set; }
        DateTime DataUtworzeniaOd { get; set; }
        DateTime DataUtworzeniaDo { get; set; }

        bool DataModyfikacjiWarunek { get; set; }
        bool DataModyfikacjiOdWarunek { get; set; }
        bool DataModyfikacjiDoWarunek { get; set; }
        DateTime DataModyfikacjiOd { get; set; }
        DateTime DataModyfikacjiDo { get; set; }

        bool WyroznienieWarunek { get; set; }
        bool Wyroznienie { get; set; }

        string Error { get; }

        bool CzyPasuje(INotatka notatka);
    }
}
