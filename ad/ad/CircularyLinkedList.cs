using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ad
{
    class CircularyLinkedList<T> where T : IComparable
    {
        private LNode<T> current;
        private LNode<T> header;
        private int count;

        public CircularyLinkedList()
        {
            count = 0;
            header = new LNode<T>();
            header.next = header;
        }

        /// <summary>
        /// if the header.next == null, there is nothing in the list.
        /// </summary>
        /// <returns>boolean</returns>
        public bool isEmpty()
        {
            return (header.next == null);
        }

        /// <summary>
        /// Clear the list by making header.next null
        /// </summary>
        public void makeEmpty()
        {
            header.next = null;
        }

        /// <summary>
        /// printing the circulary linked list
        /// </summary>
        public void printList()
        {
            LNode<T> current = new LNode<T>();
            // starting with at the begin of the list
            current = header;
            Console.WriteLine("Circulary List:");

            // looping over the circulary linked list and writing it to the console
            // also checks if it hasn't reached the end of the circulary list so it goes on and makes this an infinite loop
            while (current.next.value != null && !(current.next.value.ToString() == "header"))
            {
                Console.WriteLine(current.next.value);
                current = current.next;
            }
            Console.WriteLine("--------------------------------");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="findItem"></param>
        /// <returns></returns>
        private LNode<T> findPrevious(T findItem)
        {
            current = header;
            while (!(current.next == null) && current.next.value != null && !current.next.value.Equals(findItem))
            {
                current = current.next;
            }
            return current;
        }

        /// <summary>
        /// finds the given object in the circulary list and makes it the current node
        /// </summary>
        /// <param name="findObject"></param>
        /// <returns>current</returns>
        private LNode<T> find(T findItem)
        {
            current = new LNode<T>();
            current = header.next;
            while (!(findItem.Equals(default(T))) && current.value != null && !(current.value.Equals(findItem)))
            {
                current = current.next;
            }
            return current;
        }

        /// <summary>
        /// removes a given item from the circulary list
        /// </summary>
        /// <param name="findObject"></param>
        public void remove(T findObject)
        {
            // finds the object which should be removed
            LNode<T> temp = findPrevious(findObject);
            if (temp.next != null && temp.next.value != null)
            {
                // linking the previous node to the next node in order to remove the item
                temp.next = temp.next.next;
                // decrement the count
                count--;
            }
        }

        public void insert(T item, T after)
        {
            current = new LNode<T>();
            LNode<T> newNode = new LNode<T>(item);

            // finding the node where the new node should be added after
            current = find(after);

            // redirecting the links of the nodes
            newNode.next = current.next;
            current.next = newNode;

            // increment the count
            count++;
        }

        /// <summary>
        /// adds a item to the begin of the circulary linked list
        /// </summary>
        /// <param name="item"></param>
        public void add(T item)
        {
            LNode<T> current = new LNode<T>(item);

            // redirecting the links of the header and previous first node of the list.
            current.next = header.next;
            header.next = current;

            // increment the count
            count++;
        }

        /*
        public LNode<T> move(int n)
        {
            LNode<T> current = header.next;
            LNode<T> temp;
            for(int i = 0; i <= n; i++)
            {
                current = current.next;

            }
            if (!(current.value.Equals(header.value)))
            {
                current = current.next;
            }
            temp = current;
            return temp;
        }*/

        public int getCount()
        {
            return count;
        }
    }
}
