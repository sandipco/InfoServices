using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueImplementation
{
    public interface IQueue<T>
    {
        //Length of the queue is readonly and so is its Empty property
        int Length { get; }
        bool IsEmpty { get; }
        //The Queue function of the .NET returns void after Enqueing but here it returns a boolean to inform the user if
        //the insertion has been successful
        bool EnQueue(T element);
        bool Clear();
        T Dequeue();
        T Peek();
        void Reverse();
        IEnumerable<T> ReverseCopy();
        bool Contains(T element);
    }
}
