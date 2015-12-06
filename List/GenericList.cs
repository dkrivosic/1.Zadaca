using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    public class GenericList<X> : IGenericList<X>
    {
        private X[] _internalStorage;
        private int _count;

        public GenericList()
        {
            _internalStorage = new X[4];
            _count = 0;
        }

        public GenericList(int initialSize)
        {
            _internalStorage = new X[initialSize];
            _count = 0;
        }

        public int Count
        {
            get
            {
                return _count;
            }
        }

        public void Add(X item)
        {
            if (_count >= _internalStorage.Length)
            {
                X[] tmpStorage = _internalStorage;
                int newLength = _internalStorage.Length * 2;
                _internalStorage = new X[newLength];
                Array.Copy(tmpStorage, _internalStorage, tmpStorage.Length);
            }
            _internalStorage[Count] = item;
            _count++;
        }

        public void Clear()
        {
            _count = 0;
        }

        public bool Contains(X item)
        {
            foreach (X elem in _internalStorage)
            {
                if (elem.Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        public X GetElement(int index)
        {
            if (index >= Count || index < 0)
            {
                throw new IndexOutOfRangeException();
            }

            return _internalStorage[index];
        }

        public int IndexOf(X item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (_internalStorage[i].Equals(item))
                {
                    return i;
                }
            }
            return -1;
        }

        public bool Remove(X item)
        {
            int index = IndexOf(item);
            return RemoveAt(index);
        }

        public bool RemoveAt(int index)
        {
            if (index >= Count || index < 0)
            {
                return false;
            }

            for (int i = index; i < Count - 1; i++)
            {
                _internalStorage[i] = _internalStorage[i + 1];
            }
            _count--;
            return true;
        }

        public IEnumerator<X> GetEnumerator()
        {
            return new GenericListEnumerator<X>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
