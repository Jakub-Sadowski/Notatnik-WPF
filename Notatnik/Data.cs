using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Markup;

namespace Notatnik
{
    /// <summary>
    /// Klasa dziedzicząca z kolekcji notatek. Konieczna do serializacji.
    /// </summary>
    public class NotatkiCollection : ObservableCollection<INotatka> { }

    /// <summary>
    /// Przechowuje wszystkie dane w programie - listę notatek.
    /// Jest singletonem.
    /// </summary>
    public class Data
    {
        /// <summary>
        /// Nazwa pliku, w którym są przechowywane dane.
        /// </summary>
        private const string FILENAME = "data.xaml";

        /// <summary>
        /// Kolekcja notatek.
        /// </summary>
        private NotatkiCollection data;

        private Data()
        {
            LoadAll();
        }

        private static Data singleton = null;

        /// <summary>
        /// Jedyna instancja tej klasy.
        /// </summary>
        public static Data Instance
        {
            get
            {
                if (singleton == null)
                    singleton = new Data();
                return singleton;
            }
        }

        public Collection<INotatka> Notatki
        {
            get { return data; }
        }

        /// <summary>
        /// Serializowanie danych.
        /// </summary>
        public void SaveAll()
        {
            FileStream fileStream = File.Open(FILENAME, FileMode.Create);
            XamlWriter.Save(data, fileStream);
            fileStream.Close();
        }

        /// <summary>
        /// Deserializowanie danych.
        /// </summary>
        public void LoadAll()
        {
            if (File.Exists(FILENAME))
            {
                FileStream fileStream = File.Open(FILENAME, FileMode.Open);
                data = (NotatkiCollection)XamlReader.Load(fileStream);
                fileStream.Close();
            }
            else
                data = new NotatkiCollection();
        }
    }
}
