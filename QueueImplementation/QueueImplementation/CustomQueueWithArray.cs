using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QueueImplementation
{
    public class CustomQueueWithArray<T> : IQueue<T>
    {
        int _length;
        T[] _elements;
        int _capacity;
        public CustomQueueWithArray(int capacity)
        {
            _capacity = capacity;
            _elements = new T[capacity];
        }
        public int Length
        {
            get
            {
                return _length;
            }
        }

        public bool IsEmpty
        {
            get
            {
                if (_length == 0)
                    return true;
                return false;
            }
        }

        public bool EnQueue(T element)
        {
            try
            {
                _elements[_length] = element;
                _length++;
                return true;
            }
            catch(System.Exception ex)
            {
                return false;
            }
        }

        public bool Clear()
        {
            _elements = new T[_capacity];
            return true;
        }

        public T Dequeue()
        {
            if (_length > 0)
            {
                
                T element = _elements[0];
                T[] tempElements = new T[_capacity];
                for (int i = 1; i < _elements.Length; i++)
                {
                    tempElements[i - 1] = _elements[i];
                }
                _elements = tempElements;
                _length--;
                return element;
            }
            else
                throw new InvalidOperationException("Dequeing from empty queue");
        }

        public T Peek()
        {
            if(_length>0)
            {
                T element = _elements[0];
                return element;
            }
            else
                throw new InvalidOperationException("Dequeing from empty queue");
        }

        public void Reverse()
        {
            if(_length>0)
            {
                T[] tempElements = new T[_capacity];
                int length = _length-1;
                for(int i=0;i<_length;i++)
                {
                    tempElements[i] = _elements[length];
                    length--;
                }
                _elements = tempElements;
            }
        }

        public IEnumerable<T> ReverseCopy()
        {
            if (_length > 0)
            {
                T[] tempElements = new T[_capacity];
                int length = _length - 1;
                for (int i = 0; i < _length; i++)
                {
                    tempElements[i] = _elements[length];
                    length--;
                }
                return tempElements;
            }
            else
                return null;
        }

        public bool Contains(T element)
        {
            
            if (_length > 0)
            {
                for(int i=0;i<_length;i++)
                {
                   bool isEqual= EqualityComparer<T>.Default.Equals(element, _elements[i]);
                    if(isEqual)
                    {
                        return true;
                    }
                }
               
            }
            return false ;
        }
    }
}
