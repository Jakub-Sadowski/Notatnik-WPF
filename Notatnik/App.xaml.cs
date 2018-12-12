using System.Windows;

namespace Notatnik
{
    public partial class App : Application
    {
        void App_Startup(object sender, StartupEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(Data.Instance, Kategorie.Instance);
            mainWindow.Show();
        }
    }
}
