using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ad
{
    class DoublyLinkedList<T> where T : IComparable
    {
        private DoublyNode<T> header;

        public DoublyLinkedList()
        {
            header = new DoublyNode<T>(default(T));
        }

        private DoublyNode<T> find(T item)
        {
            DoublyNode<T> current = new DoublyNode<T>();
            current = header;
            while (!object.Equals(current.value, item) && current.next != null)
            {
                current = current.next;
            }
            return current;
        }

        public void add(T item)
        {
            DoublyNode<T> newItem = new DoublyNode<T>(item);

            // deze moet nog gecontrolleerd worden
            if (header.next != null)
            {
                newItem.next = header.next;
                newItem.previous = header;
                newItem.next.previous = newItem;
                header.next = newItem;
            }
            else
            {
                header.next = newItem;
                newItem.previous = header;
            }

        }

        public void insert(T item, T after)
        {
            DoublyNode<T> current = new DoublyNode<T>();
            DoublyNode<T> newItem = new DoublyNode<T>(item);
            current = find(after);
            newItem.next = current.next;
            newItem.previous = current;
            current.next = newItem;
        }

        private DoublyNode<T> findPrevious(Object findItem)
        {
            DoublyNode<T> current = header;
            while (!(current.next == null) && !(current.next.value.Equals(findItem)))
            {
                current = current.next;
            }
            return current;
        }

        // Werkt nog niet compleet. kan laatste item in list niet verwijderen
        public void remove(T removeItem)
        {
            DoublyNode<T> temp = find(removeItem);
            if (!(temp.next == null))
            {
                temp.previous.next = temp.next;
                temp.next.previous = temp.previous;
                temp.next = null;
                temp.previous = null;
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
