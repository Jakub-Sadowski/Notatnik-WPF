using System.Windows;

namespace Notatnik
{
    public partial class App : Application
    {
        void App_Startup(object sender, StartupEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(Kategorie.Instance, Data.Instance);
            mainWindow.Show();
        }
    }
}
