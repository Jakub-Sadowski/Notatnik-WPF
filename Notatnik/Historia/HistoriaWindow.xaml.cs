using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Notatnik
{
    public partial class HistoriaWindow : Window
    {
        public HistoriaEdycji AktywnaHistoriaEdycji { get; set; }

        public HistoriaWindow()
        {
            InitializeComponent();
        }

        private void HistoriaWindow_Loaded(object sender, RoutedEventArgs e)
        {
            lbxHistoria.ItemsSource = AktywnaHistoriaEdycji.Wpisy;
        }

        private void MyRestore(object sender, ExecutedRoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void MyRestoreCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if ((lbxHistoria == null) || (lbxHistoria.SelectedItem == null))
                e.CanExecute = false;
            else
                e.CanExecute = true;
        }

        private void MyCancel(object sender, ExecutedRoutedEventArgs e)
        {
            Close();
        }
    }
}
