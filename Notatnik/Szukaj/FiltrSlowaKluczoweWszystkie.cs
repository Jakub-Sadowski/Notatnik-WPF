using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notatnik
{
    public class FiltrSlowaKluczoweWszystkie : FiltrDecorator
    {
        public FiltrSlowaKluczoweWszystkie(IFiltr filtr) : base(filtr) { }

        public new bool CzyPasuje(INotatka notatka)
        {
            return filtr.CzyPasuje(notatka);
        }
    }
}
