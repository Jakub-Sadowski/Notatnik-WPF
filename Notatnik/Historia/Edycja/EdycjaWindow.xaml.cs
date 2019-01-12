using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;

namespace Notatnik
{
    public partial class EdycjaWindow : Window
    {
        public INotatka AktywnaNotatka { get; set; }
        private FlowDocument tekstKopia = new FlowDocument();
        private bool edited, discarded;
        private Kategorie kategorie;

        public EdycjaWindow(Kategorie kategorie)
        {
            InitializeComponent();
            this.kategorie = kategorie;
        }

        private void EdycjaWindow_Loaded(object sender, RoutedEventArgs e)
        {
            cbxKategoria.ItemsSource = kategorie.ListaKategorii;
            List<Brush> kolory = new List<Brush>() { Brushes.Black, Brushes.Red, Brushes.Orange, Brushes.Yellow, Brushes.Green, Brushes.Blue, Brushes.Purple };
            foreach(Brush kolor in kolory)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Background = kolor;
                item.Content = "";
                cbxKolor.Items.Add(item);
            }

            cbxRozmiar.ItemsSource = new List<double>() { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
            Notatka.PrzepiszTekst(AktywnaNotatka.Tekst, tekstKopia);
            rtbTekst.Document = tekstKopia;
            edited = false;
            discarded = false;
        }

        private void EdycjaWindow_Closing(object sender, CancelEventArgs e)
        {
            if (!discarded && edited)
            {
                MessageBoxResult result = MessageBox.Show("Czy chcesz zapisać przed zamknięciem?", "Zamknij", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                    AktualizujZrodlo();

                if (result == MessageBoxResult.Cancel)
                    e.Cancel = true;
            }
        }

        private void ChangeColor(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem item = cbxKolor.SelectedItem as ComboBoxItem;
            cbxKolor.Background = item.Background;
            rtbTekst.Selection.ApplyPropertyValue(Inline.ForegroundProperty, item.Background);
        }

        private void ChangeSize(object sender, SelectionChangedEventArgs e)
        {
            if (cbxRozmiar.SelectedValue != null)
                rtbTekst.Selection.ApplyPropertyValue(Inline.FontSizeProperty, cbxRozmiar.SelectedValue);
        }

        private void UpdateControlState(object sender, RoutedEventArgs e)
        {
            cbxKolor.Background = rtbTekst.Selection.GetPropertyValue(Inline.ForegroundProperty) as Brush;
            cbxRozmiar.Text = rtbTekst.Selection.GetPropertyValue(Inline.FontSizeProperty).ToString();
            btnBold.IsChecked = rtbTekst.Selection.GetPropertyValue(Inline.FontWeightProperty).Equals(FontWeights.Bold);
            btnItalic.IsChecked = rtbTekst.Selection.GetPropertyValue(Inline.FontStyleProperty).Equals(FontStyles.Italic);
            btnUnderline.IsChecked = rtbTekst.Selection.GetPropertyValue(Inline.TextDecorationsProperty).Equals(TextDecorations.Underline);
        }

        private void SetEdit(object sender, RoutedEventArgs e)
        {
            edited = true;
        }

        private void AktualizujZrodlo()
        {
            AktywnaNotatka.DataModyfikacji = DateTime.Now;
            tbxTytul.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            tbxAutor.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            AktywnaNotatka.Kategoria = kategorie.GetKategoria(cbxKategoria.SelectedIndex);
            Notatka.PrzepiszTekst(tekstKopia, AktywnaNotatka.Tekst);
        }

        private void MySave(object sender, ExecutedRoutedEventArgs e)
        {
            AktualizujZrodlo();
            edited = false;
        }

        private void EditedCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = edited;
        }

        private void MyDiscard(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Czy napewno chcesz odrzucić wszystkie zmiany?", "Odrzuć", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                discarded = true;
                Close();
            }
        }

        private void MyImport(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Xaml (*.xaml)|*.xaml|Wszystkie pliki (*.*)|*.*";
            if (dlg.ShowDialog() == true)
            {
                FileStream fileStream = File.Open(dlg.FileName, FileMode.Open);

                INotatka wczytanaNotatka = (INotatka)XamlReader.Load(fileStream);
                tbxAutor.Text = wczytanaNotatka.Autor;
                tbxTytul.Text = wczytanaNotatka.Tytul;
                cbxKategoria.SelectedItem = wczytanaNotatka.Kategoria;
                Notatka.PrzepiszTekst(wczytanaNotatka.Tekst, tekstKopia);

                fileStream.Close();
            }
        }

        private void MyExport(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBoxResult result = new MessageBoxResult();
            if (edited)
                result = MessageBox.Show("Czy chcesz zapisać zmiany?", "Zapisz", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if ((result == MessageBoxResult.Yes) || (!edited))
            {
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.Filter = "Xaml (*.xaml)|*.xaml|Wszystkie pliki (*.*)|*.*";
                if (dlg.ShowDialog() == true)
                {
                    AktualizujZrodlo();
                    edited = false;
                    FileStream fileStream = File.Open(dlg.FileName, FileMode.Create);
                    XamlWriter.Save(AktywnaNotatka, fileStream);
                    fileStream.Close();
                }
            }
        }

        private void MyEditHistory(object sender, ExecutedRoutedEventArgs e)
        {
            HistoriaWindow noweOkno = new HistoriaWindow();
            noweOkno.Owner = this;
            noweOkno.AktywnaHistoriaEdycji = AktywnaNotatka.HistoriaEdycji;
            if (noweOkno.ShowDialog() == true)
            {
                WpisHistorii wpis = noweOkno.lbxHistoria.SelectedItem as WpisHistorii;
                // przywrócenie stanu
            }
        }
    }
}
