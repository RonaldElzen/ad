using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eindopdracht
{
    class Queue
    {


      public static void enqueue<T>(T item, ArrayList queue)
        {
            queue.Add(item);
        }

        public static void dequeue(ArrayList queue)
        {
            queue.RemoveAt(0);
        }

        public static object Peek(ArrayList queue)
        {
            return queue[0];
        }

        public static void Clear(ArrayList queue)
        {
            queue.Clear();
        }

        public static int Count(ArrayList queue)
        {
    
            return queue.Count;
        }


    }
}
