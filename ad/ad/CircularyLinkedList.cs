using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ad
{
    class CircularyLinkedList<T>
    {
        protected LNode<T> current;
        protected LNode<T> header;
        private int count;

        public CircularyLinkedList()
        {
            count = 0;
            header = new LNode<T>();
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
            LNode<T> current = new LNode<T>();
            current = header;
            while (!(current.next.value.Equals(header.value)))
            {
                Console.WriteLine(current.next.value);
                current = current.next;
            }
        }

        private LNode<T> findPrevious(T n)
        {
            LNode<T> current = header;
            while (!(current.next == null) && !(current.next.value.Equals(n)))
            {
                current = current.next;
            }
            return current;
        }

        private LNode<T> find(Object n)
        {
            LNode<T> current = new LNode<T>();
            current = header.next;
            while (!(current.value.Equals(n)))
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
            count--;
        }

        public void insert(T n1, T n2)
        {
            LNode<T> current = new LNode<T>();
            LNode<T> newLNode = new LNode<T>(n1);
            current = find(n2);
            newNode.next = current.next;
            current.next = newNode;
            count++;
        }

        public void add(T n)
        {
            LNode<T> current = new LNode<T>(n);
            current.next = header;
            header.next = current;
        }

        public LNode<T> Move(int n)
        {
            LNode<T> current = header.next;
            LNode<T> temp;
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
