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

        /// <summary>
        /// Sprawdza czy podana notatka spełnia warunki.
        /// Bez podanych kryteriów (dekoratorów), domyślnie przepuszcza każdą notatkę.
        /// Jedna z dwóch dekorowanych metod.
        /// </summary>
        /// <param name="notatka">
        /// Notatka, która ma być sprawdzona pod kątem spełniania kryteriów.
        /// </param>
        /// <returns>
        /// True jeśli spełnia, false jeśli nie spełnia.
        /// </returns>
        bool CzyPasuje(INotatka notatka);

        /// <summary>
        /// Sprawdza czy podane wartości dotyczące kryteriów mają prawidłową wartość.
        /// Jedna z dwóch dekorowanych metod.
        /// </summary>
        /// <returns>
        /// Jeśli wartości są prawidłowe - zwraca null, w przeciwnym wypadku zwraca treść błędu.
        /// </returns>
        string Blad();

        /// <summary>
        /// Służy od odpakowania obiektu z dekoratora.
        /// </summary>
        /// <returns>
        /// Obiekt dekorowany. Jeśli żaden dekorator nie został nałożony - null.
        /// </returns>
        IFiltr GetDecorated();
    }
}
