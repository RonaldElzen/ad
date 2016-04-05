using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ad
{
    // Bij onderstaande code is gebruik gemaakt van het boek en het github project van onderstaande link:
    // https://gist.github.com/ashish01/8593936

    /// <summary>
    /// Create a queue with items and their priority.
    /// </summary>
    class PriorityQueue<T>
    {
        internal class Node : IComparable<Node>
        {
            public int priority1;
            public T item1;

            /// <summary>
            /// The priority of the items is compared to the priority of the other items.
            /// </summary>
            /// <param name="other">the node to which this method compares</param>
            /// <returns>The relative order of the object being compared.</returns>
            public int CompareTo(Node other)
            {
                return priority1.CompareTo(other.priority1);
            }
        }

        /// <summary>
        /// The items in priorityList contain a priority and an item by using internal class Node. 
        /// </summary>
        public List<Node> priorityList = new List<Node>();

        /// <summary>
        /// Add an item to PriorityList. The minimum priority is 1. The maximum priority is 20.
        /// </summary>
        /// <param name="priority">This integer value sets the priority of the item.</param>
        /// <param name="item">The item to add to PriorityList</param>
        public void enqueue(int priority, T item)
        {
            if (priority > 20)
            {
                priority = 20;
            }
            if (priority < 1)
            {
                priority = 1;
            }

            priorityList.Add(new Node() { priority1 = priority, item1 = item });
        }

        /// <summary>
        /// Remove the item with the highest priority from PriorityList. 
        /// If there are two items with the same priority the top item is removed.
        /// </summary>
        public void dequeue()
        {
            int min = priorityList[0].priority1;                        //set a min priority by taking the first item of the list
            int minIndex = 0;
            for (int i = 1; i < priorityList.Count; i++)
            {
                if (priorityList[i].priority1 < min)                    //compare the priority of the current item to the min priority
                {
                    min = priorityList[i].priority1;                    //set the new lowest priority
                    minIndex = i;
                }
            }
            for (int i = 0; i <= priorityList.Count; i++)
            {
                if (i == minIndex && priorityList[i].priority1 == min)  //if the current priority equals the declared lowest priority and place in list...
                {
                    priorityList.RemoveAt(i);                           //remove this item
                }
            }
        }

        /// <summary>
        /// Return the first item in the list.
        /// </summary>
        /// <returns>first item in PriorityList</returns>
        public object peek()
        {
            return priorityList[0];
        }

        /// <summary>
        /// Clear priorityList.
        /// </summary>
        public void clear()
        {
            priorityList.Clear();
        }

        /// <summary>
        /// Count the number of elements in priorityList.
        /// </summary>
        /// <returns>number of elements in priorityList</returns>
        public int count()
        {
            return priorityList.Count;
        }

        /// <summary>
        /// Print a test line to the console output.
        /// </summary>
        public void printArray()
        {
            for (int i = 0; i < priorityList.Count; i++)
            {
                Console.WriteLine("item: " + priorityList[i].item1 + " priority: " + priorityList[i].priority1);
            }
        }
    }
}
}
