using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ad
{
    class DoublyNode<T>
    {
        public T value;
        public DoublyNode<T> next;
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
    }
}
