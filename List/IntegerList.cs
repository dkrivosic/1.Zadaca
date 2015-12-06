using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    public class IntegerList : IIntegerList
    {
        private int[] _internalStorage;
        private int _count;

        public IntegerList()
        {
            _internalStorage = new int[4];
            _count = 0;
        }

        public IntegerList(int initialSize)
        {
            _internalStorage = new int[initialSize];
            _count = 0;
        }

        public int Count
        {
            get
            {
                return _count;
            }
        }

        public void Add(int item)
        {
            if (_count >= _internalStorage.Length)
            {
                int[] tmpStorage = _internalStorage;
                int newLength = _internalStorage.Length * 2;
                _internalStorage = new int[newLength];
                Array.Copy(tmpStorage, _internalStorage, tmpStorage.Length);
            }
            _internalStorage[Count] = item;
            _count++;
        }

        public void Clear()
        {
            _count = 0;
        }

        public bool Contains(int item)
        {
            foreach (int elem in _internalStorage)
            {
                if (elem == item)
                {
                    return true;
                }
            }
            return false;
        }

        public int GetElement(int index)
        {
            if (index >= Count || index < 0)
            {
                throw new IndexOutOfRangeException();
            }

            return _internalStorage[index];

        }

        public int IndexOf(int item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (item == _internalStorage[i])
                {
                    return i;
                }
            }
            return -1;
        }

        public bool Remove(int item)
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
    }
}
