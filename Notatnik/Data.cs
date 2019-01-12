using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Markup;

namespace Notatnik
{
    public class NotatkiCollection : ObservableCollection<INotatka> { }

    public class Data
    {
        private const string FILENAME = "data.xaml";
        private NotatkiCollection data;

        private Data()
        {
            LoadAll();
        }

        private static Data singleton = null;
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

        public void SaveAll()
        {
            FileStream fileStream = File.Open(FILENAME, FileMode.Create);
            XamlWriter.Save(data, fileStream);
            fileStream.Close();
        }

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
