using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ad
{
    class Iterator<T> where T : IComparable
    {
        LinkedList<T> list;
        private LNode<T> current;
        private LNode<T> prev;

        public Iterator(LinkedList<T> list)
        {
            this.list = list;
            current = list.getHeader();
            prev = null;
        }

        public void next()
        {
            prev = current;
            current = current.next;
        }

        public LNode<T> getCurrent()
        {
            return current;
        }

        public void insertBefore(T newItem)
        {
            LNode<T> item = new LNode<T>(newItem);
            item.next = prev.next;
            prev.next = item;
            current = item;
        }

        public void insterAfer(T newItem)
        {
            LNode<T> item = new LNode<T>(newItem);
            item.next = current.next;
            current.next = item;
        }

        public void remove()
        {
            prev.next = current.next;
        }

        public void clear()
        {
            current = list.getHeader();
            prev = null;
        }

        public bool end()
        {
            return (current.next == null);
        }
    }
}
