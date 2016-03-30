using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ad
{
    class CircularyLinkedList<T>
    {
        protected Node<T> current;
        protected Node<T> header;
        private int count;

        public CircularyLinkedList()
        {
            count = 0;
            header = new Node<T>();
            header.next = header;
        }

        public bool isEmpty()
        {
            return (header.next == null);
        }

        public void makeEmpty()
        {
            header.next = null;
        }

        public void printList()
        {
            Node<T> current = new Node<T>();
            current = header;
            while (!(current.next.value.Equals(header.value)))
            {
                Console.WriteLine(current.next.value);
                current = current.next;
            }
        }

        private Node<T> findPrevious(T n)
        {
            Node<T> current = header;
            while (!(current.next == null) && !(current.next.value.Equals(n)))
            {
                current = current.next;
            }
            return current;
        }

        private Node<T> find(Object n)
        {
            Node<T> current = new Node<T>();
            current = header.next;
            while (!(current.value.Equals(n)))
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
            count--;
        }

        public void insert(T n1, T n2)
        {
            Node<T> current = new Node<T>();
            Node<T> newNode = new Node<T>(n1);
            current = find(n2);
            newNode.next = current.next;
            current.next = newNode;
            count++;
        }

        public void add(T n)
        {
            Node<T> current = new Node<T>(n);
            current.next = header;
            header.next = current;
        }

        public Node<T> Move(int n)
        {
            Node<T> current = header.next;
            Node<T> temp;
            for (int i = 0; i <= n; i++)
            {
                current = current.next;
            }
            if (!(current.value.Equals(header.value)))
            {
                current = current.next;
            }
            temp = current;
            return temp;
        }
    }
}
