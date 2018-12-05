using System.Windows.Input;

namespace Notatnik
{
    public class SzukajCommands
    {
        private static RoutedUICommand ok, cancel;
        static SzukajCommands()
        {
            ok = new RoutedUICommand("OK", "OK", typeof(SzukajCommands));
            cancel = new RoutedUICommand("Anuluj", "Cancel", typeof(SzukajCommands));
        }

        public static RoutedUICommand Ok
        {
            get { return ok; }
        }

        public static RoutedUICommand Cancel
        {
            get { return cancel; }
        }
    }
}
