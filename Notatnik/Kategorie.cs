using System.Collections.ObjectModel;

namespace Notatnik
{
    public class Kategorie
    {
        private Collection<string> data = new ObservableCollection<string>();

        public Kategorie()
        {
            data.Add("Brak");
            data.Add("Osobiste");
            data.Add("Praca");
            data.Add("Finanse");
            data.Add("Plany");
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

        public Collection<string> ListaKategorii
        {
            get { return data; }
        }
    }
}
