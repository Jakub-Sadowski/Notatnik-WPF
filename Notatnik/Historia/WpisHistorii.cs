using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Notatnik
{
    public class WpisHistorii
    {
        public FlowDocument Tekst { get; set; }
        public string Tytul { get; set; }
        public string Autor { get; set; }
        public Kategoria Kategoria { get; set; }
        public DateTime DataModyfikacji { get; set; }

        public WpisHistorii() { }

        public WpisHistorii(INotatka notatka)
        {
            Tekst = new FlowDocument();
            Notatka.PrzepiszTekst(notatka.Tekst, Tekst);
            Tytul = notatka.Tytul;
            Autor = notatka.Autor;
            Kategoria = notatka.Kategoria;
            DataModyfikacji = notatka.DataModyfikacji;
        }
        

        public override string ToString()
        {
            return DataModyfikacji.ToString();
        }
    }
}
