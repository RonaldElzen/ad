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

        /// <summary>
        /// Method to find the node which the program is looking for.
        /// After this making this node the current node.
        /// </summary>
        /// <param name="item"></param>
        /// <returns>current</returns>
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

        /// <summary>
        /// Adds a new item to the begin of the doubly linked list
        /// </summary>
        /// <param name="item"></param>
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

        /// <summary>
        /// Inserts a new item to the doubly linked list after the given second parameter
        /// </summary>
        /// <param name="item"></param>
        /// <param name="after"></param>
        public void insert(T item, T after)
        {
            DoublyNode<T> current = new DoublyNode<T>();
            DoublyNode<T> newItem = new DoublyNode<T>(item);

            // finding the object where the newItem should be inserted after
            current = find(after);

            // redirecting the links of the nodes so the newItem is inserted in the list
            newItem.next = current.next;
            newItem.previous = current;
            current.next = newItem;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="findItem"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Removes a item from the list
        /// </summary>
        /// <param name="removeItem"></param>
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
            // nodes laten linken als het de laatste node is
            else
            {

            }
        }

        /// <summary>
        /// Printing the list to the console
        /// </summary>
        public void printList()
        {
            DoublyNode<T> current = new DoublyNode<T>();
            current = header;
            Console.WriteLine("Normal List:");

            // looping over the list and writing it to the console
            while (!(current.next == null))
            {
                Console.WriteLine(current.next.value);
                current = current.next;
            }
            Console.WriteLine("--------------------------------");
        }

        /// <summary>
        /// Finding the last node in the list and making it the current node
        /// </summary>
        /// <returns>current</returns>
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

        /// <summary>
        /// writing the doubly linked list in reverse to the console
        /// </summary>
        public void printReverse()
        {
            DoublyNode<T> current = new DoublyNode<T>();

            // Finding the last node and making it the current node to start with
            current = findLast();
            Console.WriteLine("Reverse List:");

            // looping over the doubly linked list and writing it to the console.
            while (!(current.previous == null))
            {
                Console.WriteLine(current.value);
                // go to the previous node to print it in reverse
                current = current.previous;
            }
            Console.WriteLine("--------------------------------");

        }
    }
}
