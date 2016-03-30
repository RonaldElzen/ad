using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ad
{
    class LinkedList<T>
    {
        protected Node<T> header;

        public LinkedList()
        {
            header = new Node<T>();
        }

        private Node<T> find(Object item)
        {
            Node<T> current = new Node<T>();
            current = header;
            while (!(current.Equals(item)))
            {
                current = current.next;
            }
            return current;
        }

        public void add(T newItem)
        {
            Node<T> current = new Node<T>();
            Node<T> newNode = new Node<T>(newItem);
            current = header;
            newNode.next = current.next;
            current.next = newNode;
        }

        public void insert(T newItem, T after)
        {
            Node<T> current = new Node<T>();
            Node<T> newNode = new Node<T>(newItem);
            current = find(after);
            newNode.next = current.next;
            current.next = newNode;
        }

        private Node<T> findPrevious(T n)
        {
            Node<T> current = header;
            while (!(current.next == null) && (n.Equals(current.next.value)))
            {
                current = current.next;
            }
            return current;
        }

        public void remove(T n)
        {
            Node<T> p = findPrevious(n);
            if (!(p.next == null))
            {
                p.next = p.next.next;
            }
        }

        public void printList()
        {
            Node<T> current = new Node<T>();
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
