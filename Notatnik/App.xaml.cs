using System.Windows;

namespace Notatnik
{
    public partial class App : Application
    {
        /// <summary>
        /// Wywołuje się przy uruchomieniu aplikacji.
        /// Przekazuje do głównego okna singletony: Kategorie i Data.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void App_Startup(object sender, StartupEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(Kategorie.Instance, NotatkiData.Instance);
            mainWindow.Show();
        }
    }
}
