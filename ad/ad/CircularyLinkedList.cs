using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ad
{
  public  class CircularyLinkedList<T> where T : IComparable
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
            count = 0;
        }

        /// <summary>
        /// looping over the list and puts the node values in an array
        /// </summary>
        /// <returns>Array with node values</returns>
        public T[] getList()
        {
            LNode<T> current = new LNode<T>();
            current = header;
            T[] returnArray = new T[count];
            int i = 0;
            while (current.next.value != null && !(current.next.value.ToString() == "header"))
            {
                returnArray[i] = current.next.value;
                current = current.next;
                i++;
            }
            return returnArray;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="findItem"></param>
        /// <returns></returns>
        public LNode<T> findPrevious(T findItem)
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
        public LNode<T> find(T findItem)
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

        /// <summary>
        /// inserts a new item to the list after a given node value
        /// </summary>
        /// <param name="item"></param>
        /// <param name="after"></param>
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

        /// <summary>
        /// returns the number of nodes in the list
        /// </summary>
        /// <returns>count</returns>
        public int getCount()
        {
            return count;
        }
    }
}
