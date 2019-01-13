using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notatnik
{
    class FiltrDataUtworzeniaOd : FiltrDecorator
    {
        public FiltrDataUtworzeniaOd(IFiltr filtr) : base(filtr) { }

        public override bool CzyPasuje(INotatka notatka)
        {
            if (notatka.DataUtworzenia < DataUtworzeniaOd)
                return false;
            return filtr.CzyPasuje(notatka);
        }
    }
}
