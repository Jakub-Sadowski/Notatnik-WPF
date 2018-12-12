using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notatnik
{
    public class NotatkiLateInit : ICollection<Notatka>
    {
        private ObservableCollection<Notatka> notatki;

        public NotatkiLateInit(ICollection<Notatka> notatki)
        {
            this.notatki = (ObservableCollection<Notatka>)notatki;
        }

        public int Count
        {
            get
            {
                return notatki.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public void Add(Notatka item)
        {
            notatki.Add(item); // do zmiany - późna inicjalizacja
        }

        public void Clear()
        {
            notatki.Clear();
        }

        public bool Contains(Notatka item)
        {
            return notatki.Contains(item);
        }

        public void CopyTo(Notatka[] array, int arrayIndex)
        {
            notatki.CopyTo(array, arrayIndex);
        }

        public IEnumerator<Notatka> GetEnumerator()
        {
            return notatki.GetEnumerator();
        }

        public bool Remove(Notatka item)
        {
            return notatki.Remove(item);
        }

        public void RemoveAt(int index)
        {
            notatki.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return notatki.GetEnumerator();
        }
    }
}
