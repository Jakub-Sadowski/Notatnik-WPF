using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Notatnik
{
    /// <summary>
    /// Abstrakcyjna klasa bazowa dla kategorii. Flyweight.
    /// </summary>
    public abstract class Kategoria
    {
        public Brush Kolor { get; set; } // Flyweight - stan wewnętrzny
        public string Nazwa { get; set; } // Flyweight - stan wewnętrzny

        public int PozycjaNotatki(INotatka notatka, NotatkiData data) // Flyweight - stan zewnętrzny
        {
            if (notatka.Kategoria.Nazwa != this.Nazwa)
                return -1;

            int licznik = 0;

            for (int i = 0; i < data.Notatki.Count; i++)
            {
                if (data.Notatki[i].Kategoria.Nazwa == this.Nazwa)
                {
                    licznik++;
                    if (data.Notatki[i] == notatka)
                        return licznik;
                }
            }
            return -1;
        }

        public override string ToString()
        {
            return Nazwa;
        }

        public abstract Kategoria Clone();
    }
}
