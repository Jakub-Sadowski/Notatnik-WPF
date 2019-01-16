using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Notatnik
{
    public partial class SzukajWindow : Window
    {
        public IFiltr AktywnyFiltr { get; set; }

        public SzukajWindow()
        {
            InitializeComponent();
        }

        private void SzukajWindow_Loaded(object sender, RoutedEventArgs e)
        {
            cbxKategoria.ItemsSource = Kategorie.Instance.ListaKategorii;
            cbxKategoria.SelectedItem = Kategorie.Instance.ListaKategorii[0];
        }

        /// <summary>
        /// Pokazuje komunikat o błędzie.
        /// </summary>
        /// <param name="tresc">
        /// Treść komunikatu.
        /// </param>
        private void PokazKomunikat(string tresc)
        {
            MessageBox.Show(tresc, "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        /// <summary>
        /// Sprawdza zaznaczone przez użytkownika kryteria i buduje obiekt Filtru.
        /// Wyświetla ewentualny komunikat o nieprawidłowych danych.
        /// Następuje tu udekorowanie Filtru.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyOk(object sender, ExecutedRoutedEventArgs e)
        {
            if (cbxTytulWarunek.IsChecked == true)
            {
                if (rbTytulDokladnyWarunek.IsChecked == true)
                    AktywnyFiltr = new FiltrTytulDokladny(AktywnyFiltr);
                else
                    AktywnyFiltr = new FiltrTytulZawiera(AktywnyFiltr);
            }
            if (cbxAutorWarunek.IsChecked == true)
                AktywnyFiltr = new FiltrAutor(AktywnyFiltr);

            if (cbxSlowaKluczoweWarunek.IsChecked == true)
            {
                if (rbSlowaKluczoweWszystkieWarunek.IsChecked == true)
                    AktywnyFiltr = new FiltrSlowaKluczoweWszystkie(AktywnyFiltr);
                else
                    AktywnyFiltr = new FiltrSlowaKluczoweJakiekolwiek(AktywnyFiltr);
            }

            if (cbxKategoriaWarunek.IsChecked == true)
                AktywnyFiltr = new FiltrKategoria(AktywnyFiltr);

            if (cbxDataUtworzeniaWarunek.IsChecked == true)
            {
                if (cbxDataUtworzeniaOdWarunek.IsChecked == true)
                    AktywnyFiltr = new FiltrDataUtworzeniaOd(AktywnyFiltr);
                if (cbxDataUtworzeniaDoWarunek.IsChecked == true)
                    AktywnyFiltr = new FiltrDataUtworzeniaDo(AktywnyFiltr);
                if (cbxDataUtworzeniaOdWarunek.IsChecked == true && cbxDataUtworzeniaDoWarunek.IsChecked == true)
                    AktywnyFiltr = new FiltrDataUtworzeniaZakres(AktywnyFiltr);
            }

            if (cbxDataModyfikacjiWarunek.IsChecked == true)
            {
                if (cbxDataModyfikacjiOdWarunek.IsChecked == true)
                    AktywnyFiltr = new FiltrDataModyfikacjiOd(AktywnyFiltr);
                if (cbxDataModyfikacjiDoWarunek.IsChecked == true)
                    AktywnyFiltr = new FiltrDataModyfikacjiDo(AktywnyFiltr);
                if (cbxDataModyfikacjiOdWarunek.IsChecked == true && cbxDataModyfikacjiDoWarunek.IsChecked == true)
                    AktywnyFiltr = new FiltrDataModyfikacjiZakres(AktywnyFiltr);
            }

            string blad = AktywnyFiltr.Blad();

            if (!string.IsNullOrEmpty(blad))
            {
                PokazKomunikat(blad);
                while (AktywnyFiltr.GetDecorated() != null)
                    AktywnyFiltr = AktywnyFiltr.GetDecorated();
            }
            else
            {
                DialogResult = true;
                Close();
            }
        }

        private void MyOkCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (AktywnyFiltr == null)
                e.CanExecute = false;
            else
                e.CanExecute = true;
        }

        private void MyCancel(object sender, ExecutedRoutedEventArgs e)
        {
            AktywnyFiltr = null;
            Close();
        }
    }
}
