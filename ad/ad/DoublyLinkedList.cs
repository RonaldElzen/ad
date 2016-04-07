using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ad
{
   public class DoublyLinkedList<T> where T : IComparable
    {
        private DoublyNode<T> header;
        private int count;

        public DoublyLinkedList()
        {
            header = new DoublyNode<T>(default(T));
            count = 0;
        }

        /// <summary>
        /// Method to find the node which the program is looking for.
        /// After this making this node the current node.
        /// </summary>
        /// <param name="item"></param>
        /// <returns>current</returns>
        public DoublyNode<T> find(T item)
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
            count++;
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

            // increment count
            count++;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="findItem"></param>
        /// <returns></returns>
        public DoublyNode<T> findPrevious(Object findItem)
        {
            DoublyNode<T> current = header;
            while (!(current.next == null) && !(current.next.value.Equals(findItem)))
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
            DoublyNode<T> temp = find(removeItem);
            // check if the item that should be removed isnt the last item
            if (temp.next != null)
            {
                // redirect links of nodes
                temp.previous.next = temp.next;
                temp.next.previous = temp.previous;
                temp.next = null;
                temp.previous = null;
                count--;
            }
            // The last one should be removed
            else if (temp.previous != null)
            {
                temp.previous.next = null;
                temp.next = null;
                temp.previous = null;
                count--;
            }
        }

        /// <summary>
        /// returns the total nodes in the list, excluded the header node
        /// </summary>
        /// <returns>count</returns>
        public int getCount()
        {
            return count;
        }

        /// <summary>
        /// Putting the values of the nodes in an array
        /// </summary>
        /// <returns>Array containing the node value's</returns>
        public T[] getList()
        {
            DoublyNode<T> current = new DoublyNode<T>();
            T[] returnArray = new T[count];
            int i = 0;
            current = header;
            while (!(current.next == null))
            {
                returnArray[i] = current.next.value;
                current = current.next;
                i++;
            }
            return returnArray;
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
        /// Putting the values of the nodes in reversed order in an array
        /// </summary>
        /// <returns>Array containing the node value's in reverse</returns>
        public T[] getReverseList()
        {
            DoublyNode<T> current = new DoublyNode<T>();
            current = findLast();

            T[] returnArray = new T[count];
            int i = 0;

            while (!(current.previous == null))
            {
                returnArray[i] = current.value;
                current = current.previous;
                i++;
            }
            return returnArray;
        }
    }
}
