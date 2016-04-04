using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ad
{
    class LNode<T> where T : IComparable
    {
        public T value;
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
    }
}
