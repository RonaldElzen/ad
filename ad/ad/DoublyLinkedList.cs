using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ad
{
    class DoublyLinkedList<T>
    {
        protected DoublyNode<T> header;

        public DoublyLinkedList()
        {
            header = new DoublyNode<T>();
        }

        private DoublyNode<T> find(Object item)
        {
            DoublyNode<T> current = new DoublyNode<T>();
            current = header;
            while (current.value.Equals(item))
            {
                current = current.next;
            }
            return current;
        }

        public void insert(T newItem, T after)
        {
            DoublyNode<T> current = new DoublyNode<T>();
            DoublyNode<T> newNode = new DoublyNode<T>(newItem);
            current = find(after);
            newNode.next = current.next;
            newNode.previous = current;
            current.next = newNode;
        }

        private DoublyNode<T> findPrevious(Object n)
        {
            DoublyNode<T> current = header;
            while (!(current.next == null) && !(current.next.value.Equals(n)))
            {
                current = current.next;
            }
            return current;
        }

        public void remove(T n)
        {
            DoublyNode<T> p = find(n);
            if (!(p.next == null))
            {
                p.previous.next = p.next;
                p.next.previous = p.previous;
                p.next = null;
                p.previous = null;
            }
        }

        public void printList()
        {
            DoublyNode<T> current = new DoublyNode<T>();
            current = header;
            Console.WriteLine("Normal List:");
            while (!(current.next == null))
            {
                Console.WriteLine(current.next.value);
                current = current.next;
            }
            Console.WriteLine("--------------------------------");
        }

        public DoublyNode<T> findLast()
        {
            DoublyNode<T> current = new DoublyNode<T>();
            current = header;
            while (!(current.next == null))
            {
                current = current.next;
            }
            return current;
        }

        public void printReverse()
        {
            DoublyNode<T> current = new DoublyNode<T>();
            current = findLast();
            Console.WriteLine("Reverse List:");
            while (!(current.previous == null))
            {
                Console.WriteLine(current.value);
                current = current.previous;
            }
            Console.WriteLine("--------------------------------");

        }
    }
}
