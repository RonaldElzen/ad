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
        private LNode<T> current;

        public LinkedList()
        {
            header = new LNode<T>();
        }

        /// <summary>
        /// Returns the header node
        /// </summary>
        /// <returns>header</returns>
        public LNode<T> getHeader()
        {
            return header;
        }

        /// <summary>
        /// Loops over the linked list to find the item which the program is searching for
        /// </summary>
        /// <param name="item"></param>
        /// <returns>Node which the program is looking for</returns>
        private LNode<T> find(T item)
        {
            current = new LNode<T>();
            current = header;
            // Looping over the list
            while (!object.Equals(current.value, item) && current.next != null)
            {
                // if the object isnt equal to item, go to the next item
                current = current.next;
            }
            return current;
        }

        /// <summary>
        /// Adds a new item to the begin of the linked list
        /// </summary>
        /// <param name="item"></param>
        public void add(T item)
        {
            current = new LNode<T>();
            LNode<T> newItem = new LNode<T>(item);

            // redirects the header.next to the new item and the newItem.next to the previous first node
            current = header;
            newItem.next = current.next;
            current.next = newItem;
        }

        /// <summary>
        /// Inserts a new item to the list after the given second parameter
        /// </summary>
        /// <param name="item"></param>
        /// <param name="after"></param>
        public void insert(T item, T after)
        {
            current = new LNode<T>();
            LNode<T> newNode = new LNode<T>(item);

            // finds the item where the new item is going to be inserted after. 
            current = find(after);

            // Redirecting the newnode.next to current.next and current.next to newItem
            newNode.next = current.next;
            current.next = newNode;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="findItem"></param>
        /// <returns></returns>
        private LNode<T> findPrevious(T findItem)
        {
            current = header;
            while (!(current.next == null) && !current.next.value.Equals(findItem))
            {
                current = current.next;
            }
            return current;
        }

        /// <summary>
        /// Removes a item from the list
        /// </summary>
        /// <param name="removeItem"></param>
        public void remove(T removeItem)
        {
            // finding the previous node from the item that should be removed
            LNode<T> temp = findPrevious(removeItem);
            // check if the item that should be removed isnt the last item
            if (!(temp.next == null))
            {
                // linking the previous node to the next node for the removeItem
                temp.next = temp.next.next;
            }
        }

        /// <summary>
        /// Printing the list to the console
        /// </summary>
        public void printList()
        {
            current = new LNode<T>();
            current = header;
            Console.WriteLine("List:");
            // looping and printing the list.
            while (!(current.next == null))
            {
                Console.WriteLine(current.next.value);
                current = current.next;
            }
            Console.WriteLine("--------------------------------");
        }
    }
}
