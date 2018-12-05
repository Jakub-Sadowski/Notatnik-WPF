using System;
using System.IO;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace Notatnik
{
    public class Notatka
    {
        public FlowDocument Tekst { get; set; }
        public string Tytul { get; set; }
        public string Autor { get; set; }
        public string Kategoria { get; set; }
        public DateTime DataUtworzenia { get; set; }
        public DateTime DataModyfikacji { get; set; }
        public bool Wyroznienie { get; set; }

        public Notatka()
        {
            Wyroznienie = false;
            DataUtworzenia = DateTime.Now;
            DataModyfikacji = DateTime.Now;
            Kategoria = Kategorie.Instance.ListaKategorii[0];
            Tekst = new FlowDocument();
            Tekst.FontFamily = SystemFonts.MessageFontFamily;
            Tekst.FontSize = 12;
            Tekst.Foreground = Brushes.Black;
        }

        public static void PrzepiszTekst(FlowDocument from, FlowDocument to)
        {
            TextRange range1, range2;
            MemoryStream stream = new MemoryStream();
            range1 = new TextRange(from.ContentStart, from.ContentEnd);
            range2 = new TextRange(to.ContentStart, to.ContentEnd);
            range1.Save(stream, DataFormats.XamlPackage);
            range2.Load(stream, DataFormats.XamlPackage);
        }

        public override string ToString()
        {
            if (Tytul == null) return "";
            else return Tytul;
        }
    }
}
