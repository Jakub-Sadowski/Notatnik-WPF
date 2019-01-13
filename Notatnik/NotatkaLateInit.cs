using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Notatnik
{
    public class NotatkaLateInit : INotatka
    {
        private Notatka notatka;
        private Kategorie kategorie;

        public NotatkaLateInit(Kategorie kategorie)
        {
            this.kategorie = kategorie;
            DataUtworzenia = DateTime.Now;
        }
        
        public FlowDocument Tekst
        {
            get
            {
                if (notatka == null)
                    return new FlowDocument();
                else
                    return notatka.Tekst;
            }
            set
            {
                if (notatka == null)
                    notatka = new Notatka(kategorie);
                notatka.Tekst = value;
            }
        }

        public string Tytul
        {
            get
            {
                if (notatka == null)
                    return "[Brak tytułu]";
                else
                    return notatka.Tytul;
            }
            set
            {
                if (notatka == null)
                    notatka = new Notatka(kategorie);
                notatka.Tytul = value;
            }
        }

        public string Autor
        {
            get
            {
                if (notatka == null)
                    return "<brak autora>";
                else return notatka.Autor;
            }
            set
            {
                if (notatka == null)
                    notatka = new Notatka(kategorie);
                notatka.Autor = value;
            }
        }

        public Kategoria Kategoria
        {
            get
            {
                if (notatka == null)
                    return kategorie.GetKategoria(0);
                else
                    return notatka.Kategoria;
            }
            set
            {
                if (notatka == null)
                    notatka = new Notatka(kategorie);
                notatka.Kategoria = value;
                Kategoria klon = notatka.Kategoria.Clone() as Kategoria;
                
            }
        }

        public DateTime DataUtworzenia { get; set; }

        public DateTime DataModyfikacji
        {
            get
            {
                if (notatka == null)
                    return DataUtworzenia;
                else
                    return notatka.DataModyfikacji;
            }
            set
            {
                if (notatka == null)
                    notatka = new Notatka(kategorie);
                notatka.DataModyfikacji = value;
            }
        }

        public HistoriaEdycji HistoriaEdycji
        {
            get
            {
                if (notatka == null)
                    return new HistoriaEdycji();
                else
                    return notatka.HistoriaEdycji;
            }
            set
            {
                if (notatka == null)
                    notatka = new Notatka(kategorie);
                notatka.HistoriaEdycji = value;
            }
        }

        public bool Wyroznienie { get; set; }

        public void ZapiszStanDoHistorii()
        {
            if (notatka != null)
                notatka.ZapiszStanDoHistorii();
        }

        public void WczytajStanZHistorii(WpisHistorii wpis)
        {
            if (notatka != null)
                notatka.WczytajStanZHistorii(wpis);
        }

        public NotatkaLateInit() { kategorie = Kategorie.Instance; }
    }
}
