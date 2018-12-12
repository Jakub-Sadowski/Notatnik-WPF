using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notatnik
{
    public abstract class FiltrDecorator : IFiltr
    {
        protected IFiltr filtr;

        public FiltrDecorator(IFiltr filtr)
        {
            this.filtr = filtr;
        }

        public string Autor
        {
            get { return filtr.Autor; }

            set { filtr.Autor = value; }
        }

        public bool AutorWarunek
        {
            get
            {
                return filtr.AutorWarunek;
            }

            set
            {
                filtr.AutorWarunek = value;
            }
        }

        public DateTime DataModyfikacjiDo
        {
            get
            {
                return filtr.DataModyfikacjiDo;
            }

            set
            {
                filtr.DataModyfikacjiDo = value;
            }
        }

        public bool DataModyfikacjiDoWarunek
        {
            get
            {
                return filtr.DataModyfikacjiDoWarunek;
            }

            set
            {
                filtr.DataModyfikacjiDoWarunek = value;
            }
        }

        /* poprawić resztę */
        public DateTime DataModyfikacjiOd
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public bool DataModyfikacjiOdWarunek
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public bool DataModyfikacjiWarunek
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public DateTime DataUtworzeniaDo
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public bool DataUtworzeniaDoWarunek
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public DateTime DataUtworzeniaOd
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public bool DataUtworzeniaOdWarunek
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public bool DataUtworzeniaWarunek
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public string Error
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Kategoria Kategoria
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public bool KategoriaWarunek
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public string SlowaKluczowe
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public bool SlowaKluczoweJakiekolwiek
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public bool SlowaKluczoweWarunek
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public bool SlowaKluczoweWszystkie
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public string Tytul
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public bool TytulDokladny
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public bool TytulWarunek
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public bool TytulZawiera
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public bool Wyroznienie
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public bool WyroznienieWarunek
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public bool CzyPasuje(INotatka notatka)
        {
            return filtr.CzyPasuje(notatka);
        }
    }
}
