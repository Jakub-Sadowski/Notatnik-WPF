using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Documents;

namespace Notatnik
{
    public class Filtr : IDataErrorInfo, IFiltr
    {
        public bool TytulWarunek { get; set; }
        public bool TytulDokladny { get; set; }
        public bool TytulZawiera { get; set; }
        public string Tytul { get; set; }

        public bool AutorWarunek { get; set; }
        public string Autor { get; set; }

        public bool SlowaKluczoweWarunek { get; set; }
        public bool SlowaKluczoweWszystkie { get; set; }
        public bool SlowaKluczoweJakiekolwiek { get; set; }
        public string SlowaKluczowe { get; set; }

        public bool KategoriaWarunek { get; set; }
        public Kategoria Kategoria { get; set; }

        public bool DataUtworzeniaWarunek { get; set; }
        public bool DataUtworzeniaOdWarunek { get; set; }
        public bool DataUtworzeniaDoWarunek { get; set; }
        public DateTime DataUtworzeniaOd { get; set; }
        public DateTime DataUtworzeniaDo { get; set; }

        public bool DataModyfikacjiWarunek { get; set; }
        public bool DataModyfikacjiOdWarunek { get; set; }
        public bool DataModyfikacjiDoWarunek { get; set; }
        public DateTime DataModyfikacjiOd { get; set; }
        public DateTime DataModyfikacjiDo { get; set; }

        public bool WyroznienieWarunek { get; set; }
        public bool Wyroznienie { get; set; }

        public string Error { get { return null; } }

        public string this[string columnName]
        {
            get
            {
                if ((columnName == "DataUtworzeniaOd") || (columnName == "DataUtworzeniaDo"))
                {
                    if (!DataUtworzeniaWarunek) return null;
                    if (DataModyfikacjiWarunek)
                    {
                        if ((DataModyfikacjiDoWarunek) && (DataUtworzeniaOdWarunek))
                            if (DataUtworzeniaOd > DataModyfikacjiDo)
                                return "Data modyfikacji nie może się kończyć przed datą utworzenia.";
                    }
                    if ((!DataUtworzeniaOdWarunek) || (!DataUtworzeniaDoWarunek)) return null;
                    if (DataUtworzeniaOd > DataUtworzeniaDo)
                        return "Data Od nie może być późniejsza niż data Do.";
                }

                if ((columnName == "DataModyfikacjiOd") || (columnName == "DataModyfikacjiDo"))
                {
                    if (!DataModyfikacjiWarunek) return null;
                    if (DataUtworzeniaWarunek)
                    {
                        if ((DataModyfikacjiDoWarunek) && (DataUtworzeniaOdWarunek))
                            if (DataUtworzeniaOd > DataModyfikacjiDo)
                                return "Data modyfikacji nie może się kończyć przed datą utworzenia.";
                    }
                    if ((!DataModyfikacjiOdWarunek) || (!DataModyfikacjiDoWarunek)) return null;
                    if (DataModyfikacjiOd > DataModyfikacjiDo)
                        return "Data Od nie może być późniejsza niż data Do.";
                }

                return null;
            }
        }

        public Filtr()
        {
            DataUtworzeniaOd = DataUtworzeniaDo = DataModyfikacjiOd = DataModyfikacjiDo = DateTime.Now;
            TytulDokladny = true;
            SlowaKluczoweWszystkie = true;
            Wyroznienie = true;
        }

        public bool CzyPasuje(INotatka notatka)
        {
            if (TytulWarunek)
            {
                if (string.IsNullOrEmpty(notatka.Tytul)) return false;

                if (TytulDokladny)
                {
                    if (Tytul != notatka.Tytul) return false;
                }
                else if (TytulZawiera)
                {
                    if (!notatka.Tytul.ToLower().Contains(Tytul.ToLower())) return false;
                }
            }

            if (AutorWarunek)
                if (Autor != notatka.Autor)  return false;

            if (SlowaKluczoweWarunek)
            {
                string tresc = new TextRange(notatka.Tekst.ContentStart, notatka.Tekst.ContentEnd).Text;
                if (string.IsNullOrEmpty(tresc)) return false;

                string[] tab = SlowaKluczowe.Split(' ');
                tresc = tresc.ToLower();

                if (SlowaKluczoweWszystkie)
                {
                    foreach (string s in tab)
                        if (!tresc.Contains(s)) return false;
                }
                else if (SlowaKluczoweJakiekolwiek)
                {
                    int i;
                    for (i = 0; i < tab.Count(); i++)
                        if (tresc.Contains(tab[i]))  break;
                    if (i == tab.Count()) return false;
                }
            }

            if (KategoriaWarunek)
                if (Kategoria != notatka.Kategoria) return false;

            if (DataUtworzeniaWarunek)
            {
                if (DataUtworzeniaOdWarunek)
                    if (DataUtworzeniaOd > notatka.DataUtworzenia) return false;

                if (DataUtworzeniaDoWarunek)
                    if (DataUtworzeniaDo < notatka.DataUtworzenia) return false;
            }

            if (DataModyfikacjiWarunek)
            {
                if (DataModyfikacjiOdWarunek)
                    if (DataModyfikacjiOd > notatka.DataModyfikacji) return false;

                if (DataModyfikacjiDoWarunek)
                    if (DataModyfikacjiDo < notatka.DataModyfikacji) return false;
            }

            if (WyroznienieWarunek)
                if (Wyroznienie != notatka.Wyroznienie) return false;

            return true;
        }
    }
}
