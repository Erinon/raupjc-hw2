using System;
using System.Collections;
using System.Collections.Generic;

namespace Razredi.Zad2
{
    public class GenericList<X> :  IGenericList<X>
    {
        private X[] _internalStorage;
        private int _count;

        public IEnumerator<X> GetEnumerator()
        {
            return new GenericListEnumerator<X>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public GenericList()
        {
            _internalStorage = new X[4];
            _count = 0;
        }

        public GenericList(int initialSize)
        {
            if (initialSize >= 0)
            {
                _internalStorage = new X[initialSize];
                _count = 0;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public void Add(X X)
        {
            if (_count == _internalStorage.Length - 1)
            {
                X[] temp = new X[_internalStorage.Length * 2];

                for (int i = 0; i < _count; i++)
                {
                    temp[i] = _internalStorage[i];
                }

                _internalStorage = temp;
            }

            _internalStorage[_count++] = X;
        }

        public bool RemoveAt(int index)
        {
            if (index < 0 || index >= _count)
            {
                throw new IndexOutOfRangeException();
            }

            for (int i = index; i < _count - 1; i++)
            {
                _internalStorage[i] = _internalStorage[i + 1];
            }

            _count--;

            return true;
        }

        public bool Remove(X item)
        {
            for (int i = 0; i < _count; i++)
            {
                if (item.Equals(_internalStorage[i]))
                {
                    return RemoveAt(i);
                }
            }

            return false;
        }

        public X GetElement(int index)
        {
            if (index < 0 || index >= _count)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                return _internalStorage[index];
            }
        }

        public int IndexOf(X item)
        {
            for (int i = 0; i < _count; i++)
            {
                if (_internalStorage[i].Equals(item))
                {
                    return i;
                }
            }

            return -1;
        }

        public int Count
        {
            get
            {
                return _count;
            }
        }

        public void Clear()
        {
            _internalStorage = new X[_internalStorage.Length];
            _count = 0;
        }

        public bool Contains(X item)
        {
            for (int i = 0; i < _count; i++)
            {
                if (_internalStorage[i].Equals(item))
                {
                    return true;
                }
            }

            return false;
        }

    }
}