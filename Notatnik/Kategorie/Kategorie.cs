using System.Collections.ObjectModel;

namespace Notatnik
{
    public class Kategorie
    {
        private Collection<Kategoria> data = new Collection<Kategoria>(); //paleta prototypów

        private Kategorie()
        {
            data.Add(new KategoriaDomyslna());
            data.Add(new KategoriaOsobiste());
            data.Add(new KategoriaPraca());
            data.Add(new KategoriaFinanse());
            data.Add(new KategoriaPlany());
        }

        private static Kategorie singleton = null;
        public static Kategorie Instance
        {
            get
            {
                if (singleton == null)
                    singleton = new Kategorie();
                return singleton;
            }
        }
        
        public Kategoria GetKategoria(int id)
        {
            return data[id].Clone();
        }

        public Collection<Kategoria> ListaKategorii
        {
            get { return data; }
        }
    }
}
