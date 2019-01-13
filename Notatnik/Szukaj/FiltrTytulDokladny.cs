using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notatnik
{
    public class FiltrTytulDokladny : FiltrDecorator
    {
        public FiltrTytulDokladny(IFiltr filtr) : base(filtr) { }

        public override bool CzyPasuje(INotatka notatka)
        {
            if (!notatka.Tytul.Equals(Tytul))
                return false;
            return filtr.CzyPasuje(notatka);
        }
    }
}
