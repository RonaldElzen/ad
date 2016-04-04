using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ad
{
    class LinkedList<T> where T : IComparable
    {
        private LNode<T> header;

        public LinkedList()
        {
            header = new LNode<T>();
        }

        public LNode<T> getHeader()
        {
            return header;
        }

        private LNode<T> find(T item)
        {
            LNode<T> current = new LNode<T>();
            current = header;
            while (!object.Equals(current.value, item) && current.next != null)
            {
                current = current.next;
            }
            return current;
        }

        public void add(T item)
        {
            LNode<T> current = new LNode<T>();
            LNode<T> newNode = new LNode<T>(item);
            current = header;
            newNode.next = current.next;
            current.next = newNode;
        }

        public void insert(T item, T after)
        {
            LNode<T> current = new LNode<T>();
            LNode<T> newNode = new LNode<T>(item);
            current = find(after);
            newNode.next = current.next;
            current.next = newNode;
        }

        private LNode<T> findPrevious(T findItem)
        {
            LNode<T> current = header;
            while (!(current.next == null) && !current.next.value.Equals(findItem))
            {
                current = current.next;
            }
            return current;
        }

        public void remove(T removeItem)
        {
            LNode<T> temp = findPrevious(removeItem);
            if (!(temp.next == null))
            {
                temp.next = temp.next.next;
            }
        }

        public void printList()
        {
            LNode<T> current = new LNode<T>();
            current = header;
            Console.WriteLine("List:");
            while (!(current.next == null))
            {
                Console.WriteLine(current.next.value);
                current = current.next;
            }
            Console.WriteLine("--------------------------------");
        }
    }
}
