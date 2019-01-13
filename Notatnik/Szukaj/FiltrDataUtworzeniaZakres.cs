using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notatnik
{
    public class FiltrDataUtworzeniaZakres : FiltrDecorator
    {
        public FiltrDataUtworzeniaZakres(IFiltr filtr) : base(filtr) { }

        public override string Blad()
        {
            if (DataUtworzeniaOd > DataUtworzeniaDo)
                return "Data utworzenia Od nie może być większa od daty Do.\n" + filtr.Blad();
            return filtr.Blad();
        }
    }
}
