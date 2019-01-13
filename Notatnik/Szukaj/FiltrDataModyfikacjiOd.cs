using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notatnik
{
    public class FiltrDataModyfikacjiOd : FiltrDecorator
    {
        public FiltrDataModyfikacjiOd(IFiltr filtr) : base(filtr) { }

        public override bool CzyPasuje(INotatka notatka)
        {
            if (notatka.DataModyfikacji < DataModyfikacjiOd)
                return false;
            return filtr.CzyPasuje(notatka);
        }
    }
}
