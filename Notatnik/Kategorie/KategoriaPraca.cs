﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Notatnik
{
    public class KategoriaPraca : Kategoria
    {
        public KategoriaPraca()
        {
            Nazwa = "Praca";
            Kolor = new SolidColorBrush(Colors.Red);
        }
        public override Kategoria Clone()
        {
            return this.MemberwiseClone() as Kategoria;
        }
    }
}
