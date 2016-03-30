using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ad
{
    class Queue
    {

        /// <summary>
        /// Method to add items to queue
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        /// <param name="queue"></param>
        public static void enqueue<T>(T item, ArrayList queue)
        {
            queue.Add(item);
        }

        /// <summary>
        /// Method to remove item from queue
        /// </summary>
        /// <param name="queue"></param>
        public static void dequeue(ArrayList queue)
        {
            queue.RemoveAt(0);
        }

        /// <summary>
        /// Peek method to return the first value of queue
        /// </summary>
        /// <param name="queue"></param>
        /// <returns></returns>
        public static object Peek(ArrayList queue)
        {
            return queue[0];
        }

        /// <summary>
        /// Method to clear queue
        /// </summary>
        /// <param name="queue"></param>
        public static void Clear(ArrayList queue)
        {
            queue.Clear();
        }

        /// <summary>
        /// Return number of items in queue
        /// </summary>
        /// <param name="queue"></param>
        /// <returns></returns>
        public static int Count(ArrayList queue)
        {

            return queue.Count;
        }


    }
}
