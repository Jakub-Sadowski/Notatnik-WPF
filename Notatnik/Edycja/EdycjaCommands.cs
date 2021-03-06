﻿using System.Windows.Input;

namespace Notatnik
{
    public class EdycjaCommands
    {
        private static RoutedUICommand save, discard, import, export, editHistory;
        static EdycjaCommands()
        {
            save = new RoutedUICommand("Zapisz", "Save", typeof(EdycjaCommands));
            discard = new RoutedUICommand("Odrzuć", "Discard", typeof(EdycjaCommands));
            import = new RoutedUICommand("Wczytaj", "Import", typeof(EdycjaCommands));
            export = new RoutedUICommand("Eksportuj", "Export", typeof(EdycjaCommands));
            editHistory = new RoutedUICommand("Historia Edycji", "Edit History", typeof(EdycjaCommands));
        }

        public static RoutedUICommand Save
        {
            get { return save; }
        }

        public static RoutedUICommand Discard
        {
            get { return discard; }
        }

        public static RoutedUICommand Import
        {
            get { return import; }
        }

        public static RoutedUICommand Export
        {
            get { return export; }
        }

        public static RoutedUICommand EditHistory
        {
            get { return editHistory; }
        }
    }
}
