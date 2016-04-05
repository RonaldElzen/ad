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

        public Iterator(LinkedList<T> newList)
        {
            list = newList;
            current = list.getHeader();
            prev = null;
        }

        /// <summary>
        /// go to the next node in the list
        /// </summary>
        public void next()
        {
            prev = current;
            current = current.next;
        }

        /// <summary>
        /// returns which node is the current node
        /// </summary>
        /// <returns>current node</returns>
        public LNode<T> getCurrent()
        {
            return current;
        }

        /// <summary>
        /// inserts the new item before the current node
        /// </summary>
        /// <param name="newItem"></param>
        public void insertBefore(T newItem)
        {
            LNode<T> item = new LNode<T>(newItem);
            item.next = prev.next;
            prev.next = item;
            current = item;
        }

        /// <summary>
        /// inserts the new item after the current node
        /// </summary>
        /// <param name="newItem"></param>
        public void insterAfter(T newItem)
        {
            LNode<T> item = new LNode<T>(newItem);
            item.next = current.next;
            current.next = item;
        }

        /// <summary>
        /// removes the current node
        /// </summary>
        public void remove()
        {
            prev.next = current.next;
        }

        /// <summary>
        /// clears the list
        /// </summary>
        public void clear()
        {
            current = list.getHeader();
            prev = null;
        }

        /// <summary>
        /// check if the iterator has reached the end
        /// </summary>
        /// <returns></returns>
        public bool end()
        {
            return (current == null);
        }
    }
}
