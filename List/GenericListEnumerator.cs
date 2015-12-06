using System;
using System.Collections;
using System.Collections.Generic;

namespace List
{
    public class GenericListEnumerator<X> : IEnumerator<X>
    {
        private GenericList<X> _genericList;
        private int _index;

        public GenericListEnumerator(GenericList<X> genericList)
        {
            this._genericList = genericList;
            this._index = -1;
        }

        public X Current
        {
            get
            {
                return _genericList.GetElement(_index);
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            _index++;
            if(_index < _genericList.Count)
            {
                return true;
            }
            return false;
        }

        public void Reset()
        {
        }
    }
}