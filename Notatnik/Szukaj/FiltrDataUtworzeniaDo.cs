using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notatnik
{
    public class FiltrDataUtworzeniaDo : FiltrDecorator
    {
        public FiltrDataUtworzeniaDo(IFiltr filtr) : base(filtr) { }

        public override bool CzyPasuje(INotatka notatka)
        {
            if (notatka.DataUtworzenia > DataUtworzeniaDo)
                return false;
            return filtr.CzyPasuje(notatka);
        }
    }
}
