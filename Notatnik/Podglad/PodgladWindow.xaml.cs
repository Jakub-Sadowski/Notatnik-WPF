using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace Notatnik
{
    public partial class PodgladWindow : Window
    {
        public INotatka AktywnaNotatka { get; set; }

        public PodgladWindow()
        {
            InitializeComponent();
        }

        private void PodgladWindow_Loaded(object sender, RoutedEventArgs e)
        {
            FlowDocument doc = new FlowDocument();
            Notatka.PrzepiszTekst(AktywnaNotatka.Tekst, doc);
            docTekst.FontFamily = SystemFonts.MessageFontFamily;
            docTekst.FontSize = 12;
            docTekst.Foreground = Brushes.Black;
            docTekst.PagePadding = new Thickness(5);
            for (int i = 0; i < doc.Blocks.Count; i++)
                docTekst.Blocks.Add(doc.Blocks.ElementAt(i));
            cbxMarginesy.ItemsSource = new List<double>() { 0, 5, 10, 15, 20, 25, 30, 35, 40, 45, 50};
        }
    }
}
