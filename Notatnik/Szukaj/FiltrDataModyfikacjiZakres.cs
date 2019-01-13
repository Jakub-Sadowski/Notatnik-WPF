using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notatnik
{
    class FiltrDataModyfikacjiZakres : FiltrDecorator
    {
        public FiltrDataModyfikacjiZakres(IFiltr filtr) : base(filtr) { }

        public override string Blad()
        {
            if (DataModyfikacjiOd > DataModyfikacjiDo)
                return "Data modyfikacji Od nie może być większa od daty Do.\n" + filtr.Blad();
            return filtr.Blad();
        }
    }
}
