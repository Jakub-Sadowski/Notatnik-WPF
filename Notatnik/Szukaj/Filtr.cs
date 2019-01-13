using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Documents;

namespace Notatnik
{
    public class Filtr : IFiltr
    {
        public string Tytul { get; set; }
        public string Autor { get; set; }
        public string SlowaKluczowe { get; set; }
        public Kategoria Kategoria { get; set; }
        public DateTime DataUtworzeniaOd { get; set; }
        public DateTime DataUtworzeniaDo { get; set; }
        public DateTime DataModyfikacjiOd { get; set; }
        public DateTime DataModyfikacjiDo { get; set; }
        public bool Wyroznienie { get; set; }

        public Filtr()
        {
            DataUtworzeniaOd = DataUtworzeniaDo = DataModyfikacjiOd = DataModyfikacjiDo = DateTime.Now;
            Wyroznienie = true;
        }

        public virtual bool CzyPasuje(INotatka notatka)
        {
            return true; 
        }

        public virtual string Blad()
        {
            return null;
        }

        public IFiltr GetDecorated()
        {
            return null;
        }
    }
}
