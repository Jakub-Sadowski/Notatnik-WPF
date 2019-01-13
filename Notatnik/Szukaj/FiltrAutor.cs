using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notatnik
{
    public class FiltrAutor : FiltrDecorator
    {
        public FiltrAutor(IFiltr filtr) : base(filtr) { }

        public override bool CzyPasuje(INotatka notatka)
        {
            if (!notatka.Autor.Equals(filtr.Autor))
                return false;
            return filtr.CzyPasuje(notatka);
        }
    }
}
