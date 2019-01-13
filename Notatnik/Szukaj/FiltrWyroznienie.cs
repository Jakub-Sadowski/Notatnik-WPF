using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notatnik
{
    public class FiltrWyroznienie : FiltrDecorator
    {
        public FiltrWyroznienie(IFiltr filtr) : base(filtr) { }

        public override bool CzyPasuje(INotatka notatka)
        {
            if (notatka.Wyroznienie != Wyroznienie)
                return false;
            return filtr.CzyPasuje(notatka);
        }
    }
}
