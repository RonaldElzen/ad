using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ad
{
    class Node<T>
    {
        public T value;
        public Node<T> next;

        public Node()
        {
            value = default(T);
            next = null;
        }

        public Node(T thisValue)
        {
            value = thisValue;
            next = null;
        }
    }
}
