using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ad
{
   public class LNode<T> where T : IComparable
    {
        // Value of the node
        public T value;
        // The next node in the list
        public LNode<T> next;

        public LNode()
        {
            value = default(T);
            next = null;
        }

        public LNode(T thisValue)
        {
            value = thisValue;
            next = null;
        }
        public T getValue()
        {
            return value;
        }
    }
}
