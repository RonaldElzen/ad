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
        int count = 0;

        public Stack()
        {
            
        }

        public void push<T>(T item, int index) where T : IComparable<T> 
        {
            stack.Add(item);
            index = index + 1;
        }

        public object pop(int index)   // T implementeren en IComparable
        {
            object value = stack[index];
            stack.RemoveAt(index);
            index--;
            return value;
        }

        public int getLength()
        {
            return stack.Count;
        }

        public  void remove(int index)
        {
            stack.Remove(index);
        }

        public ArrayList getStack()
        {
            return stack;
        }
    }
}
