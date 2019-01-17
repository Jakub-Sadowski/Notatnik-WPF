using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using MS.Internal.Data;
using System.IO;
using System.Windows.Markup;

namespace Notatnik
{
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Aktualny widok listy notatek w głównej kontrolce.
        /// </summary>
        private ListCollectionView View
        {
            get
            {
                if (lbxData == null) return null;
                else
                    return (ListCollectionView)CollectionViewSource.GetDefaultView(lbxData.ItemsSource);
            }
        }

        private PodgladWindow oknoPodgladu;
        private EdycjaWindow oknoEdycji;
        private NotatkiData data;
        private Kategorie kategorie;

        public MainWindow(Kategorie kategorie, NotatkiData data)
        {
            InitializeComponent();
            this.kategorie = kategorie;
            this.data = data;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            lbxData.ItemsSource = data.Notatki;
        }

        /// <summary>
        /// Zapisuje dane przed zamknięciem aplikacji.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            data.SaveAll();
            Application.Current.Shutdown();
        }

        /// <summary>
        /// Sortowanie danych w kontrolce przy pomocy widoku.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Sort(object sender, RoutedEventArgs e)
        {
            if (View == null)
                return;
            View.SortDescriptions.Clear();
            ListSortDirection sortDirection;

            if (cbiClearSort.IsSelected)
            {
                rbRosnaco.IsEnabled = false;
                rbMalejaco.IsEnabled = false;
            }
            else
            {
                rbRosnaco.IsEnabled = true;
                rbMalejaco.IsEnabled = true;

                if (rbRosnaco.IsChecked == true)
                    sortDirection = ListSortDirection.Ascending;
                else
                    sortDirection = ListSortDirection.Descending;

                if (cbiSortByCreationDate.IsSelected)
                    View.SortDescriptions.Add(new SortDescription("DataUtworzenia", sortDirection));
                else if (cbiSortByModifyDate.IsSelected)
                    View.SortDescriptions.Add(new SortDescription("DataModyfikacji", sortDirection));
                else if (cbiSortByTitle.IsSelected)
                    View.SortDescriptions.Add(new SortDescription("Tytul", sortDirection));
            }
        }

        /// <summary>
        /// Grupowanie danych w kontrolce przy pomocy widoku.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Group(object sender, RoutedEventArgs e)
        {
            if (View == null)
                return;
            View.GroupDescriptions.Clear();
            if (!cbiClearGroup.IsSelected)
            {
                if (cbiGroupByTitle.IsSelected)
                {
                    View.SortDescriptions.Clear();
                    View.SortDescriptions.Add(new SortDescription("Tytul", ListSortDirection.Ascending));
                    View.GroupDescriptions.Add(new PropertyGroupDescription("Tytul", new ToFirstLetterConverter()));
                }
                else if (cbiGroupByAuthor.IsSelected)
                    View.GroupDescriptions.Add(new PropertyGroupDescription("Autor", new NoAuthorConverter()));
                else if (cbiGroupByCathegory.IsSelected)
                    View.GroupDescriptions.Add(new PropertyGroupDescription("Kategoria", new CathegoryToStringConverter()));
            }
        }

        /// <summary>
        /// Wyświetla komunikat dotyczący wyszukiwania.
        /// </summary>
        private void PokazWynikiWyszukiwania()
        {
            string ilosc = View.Count.ToString();
            char ostatniaCyfra = ilosc[ilosc.Count() - 1];
            string deklinacja;

            if ((ilosc.Count() >= 2) && (ilosc[ilosc.Count() - 2] == '1'))
                deklinacja = " wyników.";
            else
            {
                if (ilosc == "1")
                    deklinacja = " wynik.";
                else if ((ostatniaCyfra == '2') || (ostatniaCyfra == '3') || (ostatniaCyfra == '4'))
                    deklinacja = " wyniki.";
                else
                    deklinacja = " wyników.";
            }

            MessageBox.Show("Znaleziono " + ilosc + deklinacja, "Wyniki", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        /// <summary>
        /// Uaktywnia niektóre przyciski, jeśli jakakolwiek notatka została zaznaczona.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectedCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if ((lbxData == null) || (lbxData.SelectedItem == null))
                e.CanExecute = false;
            else
                e.CanExecute = true;
        }

        /// <summary>
        /// Dodaje nową notatkę do listy.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyAdd(object sender, ExecutedRoutedEventArgs e)
        {
            EdycjaWindow noweOkno = new EdycjaWindow(kategorie);
            INotatka nowaNotatka = new NotatkaLateInitProxy(kategorie);
            data.Notatki.Add(nowaNotatka);

            lbxData.SelectedIndex = lbxData.Items.Count - 1;
        }

        /// <summary>
        /// Usuwa zaznaczoną notatkę z listy.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyDelete(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Czy napewno chcesz usunąć zaznaczony element?", "Usuń", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                data.Notatki.RemoveAt(lbxData.SelectedIndex);
                lbxData.SelectedIndex = lbxData.Items.Count - 1;
            }
        }

        /// <summary>
        /// Otwiera okno edycji powiązane z zaznaczoną notatką.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyEdit(object sender, ExecutedRoutedEventArgs e)
        {
            oknoEdycji = new EdycjaWindow(kategorie);
            oknoEdycji.Owner = this;
            oknoEdycji.AktywnaNotatka = lbxData.SelectedItem as INotatka;
            oknoEdycji.Show();
        }

        /// <summary>
        /// Otwiera okno podglądu związane z zaznaczoną notatką.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyPreview(object sender, ExecutedRoutedEventArgs e)
        {
            INotatka notatka = lbxData.SelectedItem as INotatka;
            oknoPodgladu = new PodgladWindow(data, notatka);
            oknoPodgladu.Owner = this;
            oknoPodgladu.Show();
        }

        /// <summary>
        /// Filtruje notatki, zostawiając tylko te, które zostały wyróżnione.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyShowFavorites(object sender, ExecutedRoutedEventArgs e)
        {
            if (btnWyroznione.IsChecked == true)
            {
                View.Filter = delegate (object item)
                {
                    INotatka notatka = item as INotatka;
                    return notatka.Wyroznienie;
                };
            }
            else
                View.Filter = null;
        }

        private void MyShowFavoritesCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if ((btnWyszukaj == null) || (btnWyszukaj.IsChecked == true))
                e.CanExecute = false;
            else
                e.CanExecute = true;
        }

        /// <summary>
        /// Otwiera okno wyszukiwania do zbudowania obiektu Filtru.
        /// Filtruje notatki, zostawiając tylko te spełniające kryteria.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MySearch(object sender, ExecutedRoutedEventArgs e)
        {
            if (btnWyszukaj.IsChecked == true)
            {
                SzukajWindow noweOkno = new SzukajWindow();
                IFiltr nowyFiltr = new Filtr();
                noweOkno.AktywnyFiltr = nowyFiltr;
                if (noweOkno.ShowDialog() == true)
                {
                    nowyFiltr = noweOkno.AktywnyFiltr;
                    View.Filter = delegate (object item)
                    {
                        INotatka notatka = item as INotatka;
                        return (nowyFiltr.CzyPasuje(notatka));
                    };

                    PokazWynikiWyszukiwania();
                }
                else
                    btnWyszukaj.IsChecked = false;
            }
            else
                View.Filter = null;
        }

        private void MySearchCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if ((data == null) || (data.Notatki.Count < 2) || (btnWyroznione == null) || (btnWyroznione.IsChecked == true))
                e.CanExecute = false;
            else
                e.CanExecute = true;
        }
    }
}
