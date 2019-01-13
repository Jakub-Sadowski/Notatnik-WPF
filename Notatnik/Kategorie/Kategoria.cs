using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Notatnik
{
    public abstract class Kategoria
    {
        public Brush Kolor { get; set; } // Flyweight - stan wewnętrzny
        public string Nazwa { get; set; } // Flyweight - stan wewnętrzny

        public int PozycjaNotatki(Notatka notatka, Data data) // Flyweight - stan zewnętrzny
        {
            return 0; // na później
        }

        public override string ToString()
        {
            return Nazwa;
        }

        public abstract Kategoria Clone();
        
    }
}
