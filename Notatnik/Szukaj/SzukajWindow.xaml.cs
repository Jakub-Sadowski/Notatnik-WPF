using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Notatnik
{
    public partial class SzukajWindow : Window
    {
        public Filtr AktywnyFiltr { get; set; }

        public SzukajWindow()
        {
            InitializeComponent();
        }

        private void SzukajWindow_Loaded(object sender, RoutedEventArgs e)
        {
            cbxKategoria.ItemsSource = Kategorie.Instance.ListaKategorii;
            cbxKategoria.SelectedItem = Kategorie.Instance.ListaKategorii[0];
        }

        private void ValidationError(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                MessageBox.Show(e.Error.ErrorContent.ToString(), "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void MyOk(object sender, ExecutedRoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void MyOkCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (AktywnyFiltr == null)
            {
                e.CanExecute = false;
                return;
            }

            if (Validation.GetHasError(dpDataUtworzeniaOd) || Validation.GetHasError(dpDataUtworzeniaDo) || Validation.GetHasError(dpDataModyfikacjiOd) || Validation.GetHasError(dpDataModyfikacjiDo))
            {
                e.CanExecute = false;
                return;
            }

            if ((AktywnyFiltr.TytulWarunek) || (AktywnyFiltr.AutorWarunek) || (AktywnyFiltr.SlowaKluczoweWarunek) || (AktywnyFiltr.KategoriaWarunek) || (AktywnyFiltr.DataUtworzeniaWarunek) || (AktywnyFiltr.DataModyfikacjiWarunek) || (AktywnyFiltr.WyroznienieWarunek))
            {
                e.CanExecute = true;
                if (AktywnyFiltr.DataUtworzeniaWarunek)
                {
                    if ((AktywnyFiltr.DataUtworzeniaOdWarunek) || (AktywnyFiltr.DataUtworzeniaDoWarunek))
                        e.CanExecute = true;
                    else
                    {
                        e.CanExecute = false;
                        return;
                    }
                }
                if (AktywnyFiltr.DataModyfikacjiWarunek)
                {
                    if ((AktywnyFiltr.DataModyfikacjiOdWarunek) || (AktywnyFiltr.DataModyfikacjiDoWarunek))
                        e.CanExecute = true;
                    else
                    {
                        e.CanExecute = false;
                        return;
                    }
                }
            }
            else
                e.CanExecute = false;
        }

        private void MyCancel(object sender, ExecutedRoutedEventArgs e)
        {
            AktywnyFiltr = null;
            Close();
        }
    }
}
