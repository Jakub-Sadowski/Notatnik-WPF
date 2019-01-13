using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notatnik
{
    public interface IFiltr
    {
        string Tytul { get; set; }
        string Autor { get; set; }
        string SlowaKluczowe { get; set; }
        Kategoria Kategoria { get; set; }
        DateTime DataUtworzeniaOd { get; set; }
        DateTime DataUtworzeniaDo { get; set; }
        DateTime DataModyfikacjiOd { get; set; }
        DateTime DataModyfikacjiDo { get; set; }
        bool Wyroznienie { get; set; }

        bool CzyPasuje(INotatka notatka);
        string Blad();
        IFiltr GetDecorated();
    }
}
