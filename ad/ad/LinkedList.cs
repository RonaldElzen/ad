using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ad
{
    class LinkedList<T>
    {
        protected LNode<T> header;

        public LinkedList()
        {
            header = new LNode<T>();
        }

        private LNode<T> find(Object item)
        {
            LNode<T> current = new LNode<T>();
            current = header;
            while (!(current.Equals(item)))
            {
                current = current.next;
            }
            return current;
        }

        public void add(T newItem)
        {
            LNode<T> current = new LNode<T>();
            LNode<T> newNode = new LNode<T>(newItem);
            current = header;
            newNode.next = current.next;
            current.next = newNode;
        }

        public void insert(T newItem, T after)
        {
            LNode<T> current = new LNode<T>();
            LNode<T> newNode = new LNode<T>(newItem);
            current = find(after);
            newNode.next = current.next;
            current.next = newNode;
        }

        private LNode<T> findPrevious(T n)
        {
            LNode<T> current = header;
            while (!(current.next == null) && (n.Equals(current.next.value)))
            {
                current = current.next;
            }
            return current;
        }

        public void remove(T n)
        {
            LNode<T> p = findPrevious(n);
            if (!(p.next == null))
            {
                p.next = p.next.next;
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
