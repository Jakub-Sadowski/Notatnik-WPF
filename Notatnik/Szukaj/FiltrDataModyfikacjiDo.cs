using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notatnik
{
    public class FiltrDataModyfikacjiDo : FiltrDecorator
    {
        public FiltrDataModyfikacjiDo(IFiltr filtr) : base(filtr) { }

        public override bool CzyPasuje(INotatka notatka)
        {
            if (notatka.DataModyfikacji > DataModyfikacjiDo)
                return false;
            return filtr.CzyPasuje(notatka);
        }
    }
}
