using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ad
{
    /// <summary>
    /// Create a queue in which items can be stored.
    /// </summary>
    class Queue<T>
    {
        public List<T> queue = new List<T>();

        /// <summary>
        /// This method adds an item to the beginning of the queue. 
        /// </summary>
        /// <param name="item">the item to add to the queue</param>
        public void enqueue(T item)
        {
            queue.Add(item);
        }

        /// <summary>
        /// Remove an item from the beginning of the queue.
        /// </summary>
        public void dequeue()
        {
            queue.RemoveAt(0);
        }

        /// <summary>
        /// Return the object at the beginning of the queue.
        /// </summary>
        /// <returns>the object at the beginning of the queue</returns>
        public object Peek()
        {
            return queue[0];
        }

        /// <summary>
        /// clear the queue.
        /// </summary>
        public void Clear()
        {
            queue.Clear();
        }

        /// <summary>
        /// count the element in the queue.
        /// </summary>
        /// <returns>the number of elements in the queue.</returns>
        public int Count()
        {
            return queue.Count;
        }

        /// <summary>
        /// set a arraylist as queue.
        /// </summary>
        /// <param name="newQueue">the arraylist to set as queue</param>
        public void setArrayList(ArrayList newQueue)
        {
            queue.Clear();
            foreach (T item in newQueue)                     //clear the queue and then add the items of the newQueue ArrayList to queue
            {
                queue.Add(item);
            }
        }

        /// <summary>
        /// Return the items from queue in a ArrayList so they can be used in other classes.
        /// </summary>
        /// <returns>the items of the list queue in a arraylist</returns>
        public ArrayList getArrayList()
        {
            ArrayList newQueue = new ArrayList();
            foreach (T item in queue)                        //add the items of queue to the arraylist newQueue.
            {
                newQueue.Add(item);
            }
            return newQueue;
        }

        /// <summary>
        /// Print a test line to the console output.
        /// </summary>
        public void printArray()
        {
            for (int i = 0; i < queue.Count; i++)
            {
                Console.WriteLine("item: " + queue[i]);
            }
        }
    }
}
