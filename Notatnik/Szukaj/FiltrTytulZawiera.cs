using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notatnik
{
    public class FiltrTytulZawiera : FiltrDecorator
    {
        public FiltrTytulZawiera(IFiltr filtr) : base(filtr) { }

        public override bool CzyPasuje(INotatka notatka)
        {
            if (!notatka.Tytul.ToLower().Contains(Tytul.ToLower()))
                return false;
            return filtr.CzyPasuje(notatka);
        }
    }
}
