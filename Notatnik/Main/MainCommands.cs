using System.Windows.Input;

namespace Notatnik
{
    public class MainCommands
    {
        private static RoutedUICommand add, delete, edit, preview, favorite, showFavorites, search;
        static MainCommands()
        {
            add = new RoutedUICommand("Dodaj", "Add", typeof(MainCommands));
            delete = new RoutedUICommand("Usuń", "Delete", typeof(MainCommands));
            edit = new RoutedUICommand("Edytuj", "Edit", typeof(MainCommands));
            preview = new RoutedUICommand("Podgląd", "Preview", typeof(MainCommands));
            favorite = new RoutedUICommand("Wyróżnij", "Favorite", typeof(MainCommands));
            showFavorites = new RoutedUICommand("Pokaż wyróżnione", "ShowFavorites", typeof(MainCommands));
            search = new RoutedUICommand("Wyszukaj", "Search", typeof(MainCommands));
        }

        public static RoutedUICommand Add
        {
            get { return add; }
        }

        public static RoutedUICommand Delete
        {
            get { return delete; }
        }

        public static RoutedUICommand Edit
        {
            get { return edit; }
        }

        public static RoutedUICommand Preview
        {
            get { return preview; }
        }

        public static RoutedUICommand Favorite
        {
            get { return favorite; }
        }

        public static RoutedUICommand ShowFavorites
        {
            get { return showFavorites; }
        }

        public static RoutedUICommand Search
        {
            get { return search; }
        }
    }
}
