using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueImplementation
{
    public class CustomQueue<T>: IQueue<T>
    {
        private List<T> _elements;
        private int _length;
        public CustomQueue()
        {
            _elements = new List<T>();
            _length = 0;
        }
        public int Length
        {
            get
            {
                return _elements.Count();
            }
        }
        public bool IsEmpty
        {
            get
            {
                if (this.Length == 0)
                    return true;
                else
                    return false;
            }
        }
        public bool EnQueue(T element)
        {
            try
            {
                _elements.Add(element);
                _length++;
                return true;
            }
            catch
            {
                return false;
            }
        }
        public T Dequeue()
        {
            //Error handling is not done here as in the Queue class of .NET Framework
            //I could have done return default(T); in the catch block however it would have returned
            //0 for int, double etc. but 0 could be an item in the queue itself
            //Error handling is left at the implementation level. I could have restricted T to be of reference type
            //but that would have limited my scope
            //string  i = new string();
            if (_elements.Count > 0)
            {
                T element;
                element = _elements[0];
                _elements.RemoveAt(0);
                _length--;
                return element;
            }
            else
            {
                throw new InvalidOperationException("Dequeing from empty queue");
            }
            
                
                
            
        }
        public T Peek()
        {
            if (_elements.Count > 0)
            {
                T element;
                element = _elements[0];
                return element;
            }
            else
            {
                throw new InvalidOperationException("Peek from empty queue not possible");
            }
            
           
        }
        public void Reverse()
        {
            _elements.Reverse();
            
        }
        public bool Clear()
        {
            try
            {
                this._elements.Clear();
                _length = 0;
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Contains(T element)
        {
            return _elements.Contains(element);
        }
        public IEnumerable<T> ReverseCopy()
        {
            List<T> reverse = new List<T>();
            reverse = _elements;
            reverse.Reverse();
            return reverse;
        }
    }
}
