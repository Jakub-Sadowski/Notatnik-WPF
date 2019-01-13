using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Notatnik
{
    public class FiltrSlowaKluczoweJakiekolwiek : FiltrDecorator
    {
        public FiltrSlowaKluczoweJakiekolwiek(IFiltr filtr) : base(filtr) { }

        public override bool CzyPasuje(INotatka notatka)
        {
            string tresc = new TextRange(notatka.Tekst.ContentStart, notatka.Tekst.ContentEnd).Text;
            if (string.IsNullOrEmpty(tresc))
                return false;
            string[] tab = SlowaKluczowe.Split(' ');
            tresc = tresc.ToLower();

            int i;
            for (i = 0; i < tab.Length; i++)
                if (tresc.Contains(tab[i])) break;
            if (i == tab.Length) return false;

            return filtr.CzyPasuje(notatka);
        }

        public override string Blad()
        {
            if (string.IsNullOrEmpty(SlowaKluczowe))
                return "Pole ze słowami kluczowymi nie może być puste.\n" + filtr.Blad();
            return filtr.Blad();
        }
    }
}
