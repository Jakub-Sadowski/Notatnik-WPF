﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Notatnik
{
    public class KategoriaDomyslna : Kategoria
    {
        public KategoriaDomyslna()
        {
            Nazwa = "Brak";
            Kolor = new SolidColorBrush(Colors.Gray);
        }
        public override Kategoria Clone()
        {
           return this.MemberwiseClone() as Kategoria;
        }
    }
}
