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
        T[] teststack;
        int count = 0;

        public Stack()
        {
            teststack = new T[1]; // size given as parameter not done
        }

        public void push<T>(T item, int index) where T : IComparable<T> // waarom IComparable? en index?
        {
            /*if (count + 1 >= teststack.Length)
            {
                Array.Resize(ref teststack, (teststack.Length + 1) * 2);
            }
            count++;*/
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
