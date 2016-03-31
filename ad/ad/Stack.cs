using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ad
{
    public class Stack
    {

        public static void push<T>(T item, int index, ArrayList stack) where T : IComparable<T>
        {
            stack.Add(item);
            index = index + 1;
        }

        public static object pop(int index, ArrayList stack)
        {
            object value = stack[index];
            stack.RemoveAt(index);
            index--;
            return value;
        }

        public static int getLength(ArrayList stack)
        {
            return stack.Count;
        }

        public static void clear(int index, ArrayList stack)
        {
            stack.Clear();
            index = -1;
        }
    }
}
