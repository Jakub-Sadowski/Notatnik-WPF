using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notatnik
{
    public class FiltrKategoria : FiltrDecorator
    {
        public FiltrKategoria(IFiltr filtr) : base(filtr) { }

        public override bool CzyPasuje(INotatka notatka)
        {
            if (notatka.Kategoria.Nazwa != Kategoria.Nazwa)
                return false;
            return filtr.CzyPasuje(notatka);
        }
    }
}
