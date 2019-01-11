using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Notatnik
{
    public class HistoriaCommands
    {
        private static RoutedUICommand restore, cancel;
        static HistoriaCommands()
        {
            restore = new RoutedUICommand("Przywróć", "Restore", typeof(HistoriaCommands));
            cancel = new RoutedUICommand("Anuluj", "Cancel", typeof(HistoriaCommands));
        }

        public static RoutedUICommand Restore
        {
            get { return restore; }
        }

        public static RoutedUICommand Cancel
        {
            get { return cancel; }
        }
    }
}
