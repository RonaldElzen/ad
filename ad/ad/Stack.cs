using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ad
{
    public class Stack<T>
    {
        ArrayList stack = new ArrayList();
        public Stack()
        {

        }

        public void push<T>(T item, int index) where T : IComparable<T>
        {
            stack.Add(item);
            index = index + 1;
        }

        public  object pop(int index)
        {
            object value = stack[index];
            stack.RemoveAt(index);
            index--;
            return value;
        }

        public int getLength(ArrayList stack)
        {
            return stack.Count;
        }

        public  void clear(int index, ArrayList stack)
        {
            stack.Clear();
            index = -1;
        }

        public ArrayList getStack()
        {
            return stack;
        }
    }
}
