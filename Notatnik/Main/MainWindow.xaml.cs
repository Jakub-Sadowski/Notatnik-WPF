using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace Notatnik
{
    public partial class MainWindow : Window
    {
        private ListCollectionView View
        {
            get
            {
                if (lbxData == null) return null;
                else return (ListCollectionView)CollectionViewSource.GetDefaultView(lbxData.ItemsSource);
            }
        }

        PodgladWindow oknoPodgladu;
        EdycjaWindow oknoEdycji;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            lbxData.ItemsSource = Data.Instance.Notatki;
        }

        private void Sort(object sender, RoutedEventArgs e)
        {
            if (View != null)
            {
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
        }

        private void Group(object sender, RoutedEventArgs e)
        {
            if (View != null)
            {
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
                        View.GroupDescriptions.Add(new PropertyGroupDescription("Kategoria"));
                }
            }
        }

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

        private void SelectedCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if ((lbxData == null) || (lbxData.SelectedItem == null))
                e.CanExecute = false;
            else
                e.CanExecute = true;
        }

        private void MyAdd(object sender, ExecutedRoutedEventArgs e)
        {
            EdycjaWindow noweOkno = new EdycjaWindow();
            Notatka nowaNotatka = new Notatka();
            Data.Instance.Notatki.Add(nowaNotatka);

            lbxData.SelectedIndex = lbxData.Items.Count - 1;
            noweOkno.AktywnaNotatka = nowaNotatka;
            noweOkno.ShowDialog();
        }

        private void MyDelete(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Czy napewno chcesz usunąć zaznaczony element?", "Usuń", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                Data.Instance.Notatki.RemoveAt(lbxData.SelectedIndex);
                lbxData.SelectedIndex = lbxData.Items.Count - 1;
            }
        }

        private void MyEdit(object sender, ExecutedRoutedEventArgs e)
        {
            oknoEdycji = new EdycjaWindow();
            oknoEdycji.Owner = this;
            oknoEdycji.AktywnaNotatka = lbxData.SelectedItem as Notatka;
            oknoEdycji.Show();
        }

        private void MyPreview(object sender, ExecutedRoutedEventArgs e)
        {
            oknoPodgladu = new PodgladWindow();
            oknoPodgladu.Owner = this;
            oknoPodgladu.AktywnaNotatka = lbxData.SelectedItem as Notatka;
            oknoPodgladu.Show();
        }

        private void MyShowFavorites(object sender, ExecutedRoutedEventArgs e)
        {
            if (btnWyroznione.IsChecked == true)
            {
                View.Filter = delegate (object item)
                {
                    Notatka notatka = item as Notatka;
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

        private void MySearch(object sender, ExecutedRoutedEventArgs e)
        {
            if (btnWyszukaj.IsChecked == true)
            {
                SzukajWindow noweOkno = new SzukajWindow();
                Filtr nowyFiltr = new Filtr();
                noweOkno.AktywnyFiltr = nowyFiltr;
                if (noweOkno.ShowDialog() == true)
                {
                    View.Filter = delegate (object item)
                    {
                        Notatka notatka = item as Notatka;
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
            if ((Data.Instance == null) || (Data.Instance.Notatki.Count < 2) || (btnWyroznione == null) || (btnWyroznione.IsChecked == true))
                e.CanExecute = false;
            else
                e.CanExecute = true;
        }
    }
}
