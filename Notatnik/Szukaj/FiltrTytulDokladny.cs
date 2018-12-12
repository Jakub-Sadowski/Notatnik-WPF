using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notatnik.Szukaj
{
    public class FiltrTytulDokladny : FiltrDecorator
    {
        public FiltrTytulDokladny(IFiltr filtr) : base(filtr) { }

        public new bool CzyPasuje(INotatka notatka)
        {
            return filtr.CzyPasuje(notatka); // na później
        }
    }
}
