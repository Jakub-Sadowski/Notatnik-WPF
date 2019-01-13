using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Notatnik
{
    public class FiltrSlowaKluczoweWszystkie : FiltrDecorator
    {
        public FiltrSlowaKluczoweWszystkie(IFiltr filtr) : base(filtr) { }

        public override bool CzyPasuje(INotatka notatka)
        {
            string tresc = new TextRange(notatka.Tekst.ContentStart, notatka.Tekst.ContentEnd).Text;
            if (string.IsNullOrEmpty(tresc))
                return false;
            string[] tab = SlowaKluczowe.Split(' ');
            tresc = tresc.ToLower();
            
            foreach (string s in tab)
                if (!tresc.Contains(s)) return false;

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
