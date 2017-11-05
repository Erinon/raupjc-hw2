using System.Collections;
using System.Collections.Generic;


namespace Razredi.Zad2
{
    public class GenericListEnumerator<X> : IEnumerator<X>
    {
        private GenericList<X> genericList;
        private int _counter;

        public GenericListEnumerator(GenericList<X> genericList)
        {
            this.genericList = genericList;
            _counter = 0;
        }

        public X Current
        {
            get
            {
                return genericList.GetElement(++_counter - 1);
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
            if (_counter < genericList.Count)
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