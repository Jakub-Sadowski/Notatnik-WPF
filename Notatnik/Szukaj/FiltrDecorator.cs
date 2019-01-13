using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notatnik
{
    public abstract class FiltrDecorator : IFiltr
    {
        protected IFiltr filtr;

        public FiltrDecorator(IFiltr filtr) { this.filtr = filtr; }

        public IFiltr GetDecorated() { return filtr; }

        public string Tytul
        {
            get { return filtr.Tytul; }
            set { filtr.Tytul = value; }
        }

        public string Autor
        {
            get { return filtr.Autor; }
            set { filtr.Autor = value; }
        }

        public string SlowaKluczowe
        {
            get { return filtr.SlowaKluczowe; }
            set { filtr.SlowaKluczowe = value; }
        }

        public Kategoria Kategoria
        {
            get { return filtr.Kategoria; }
            set { filtr.Kategoria = value; }
        }

        public DateTime DataModyfikacjiDo
        {
            get { return filtr.DataModyfikacjiDo; }
            set { filtr.DataModyfikacjiDo = value; }
        }
        
        public DateTime DataModyfikacjiOd
        {
            get { return filtr.DataModyfikacjiOd; }
            set { filtr.DataModyfikacjiOd = value; }
        }

        public DateTime DataUtworzeniaDo
        {
            get { return filtr.DataUtworzeniaDo; }
            set { filtr.DataUtworzeniaDo = value; }
        }

        public DateTime DataUtworzeniaOd
        {
            get { return filtr.DataUtworzeniaOd; }
            set { filtr.DataUtworzeniaOd = value; }
        }

        public bool Wyroznienie
        {
            get { return filtr.Wyroznienie; }
            set { filtr.Wyroznienie = value; }
        }

        public virtual bool CzyPasuje(INotatka notatka) { return filtr.CzyPasuje(notatka); }

        public virtual string Blad() { return filtr.Blad(); }
    }
}
