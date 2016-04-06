using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ad
{
   public class DoublyNode<T> where T : IComparable
    {
        // Value of the node
        public T value;
        // Next node in the list
        public DoublyNode<T> next;
        // Previous node
        public DoublyNode<T> previous;

        public DoublyNode()
        {
            value = default(T);
            next = null;
            previous = null;
        }

        public DoublyNode(T thisValue)
        {
            value = thisValue;
            next = null;
            previous = null;
        }

        public T getValue()
        {
            return value;
        }
    }
}
