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

        public bool isEmpty()
        {
            return (header.next == null);
        }

        public void makeEmpty()
        {
            header.next = null;
        }

        public void printList()
        {
            LNode<T> current = new LNode<T>();
            current = header;
            Console.WriteLine("Circulary List:");

            while (current.next.value != null && !(current.next.value.ToString() == "header"))
            {
                Console.WriteLine(current.next.value);
                current = current.next;
            }
            Console.WriteLine("--------------------------------");
        }

        private LNode<T> findPrevious(T findItem)
        {
            LNode<T> current = header;
            // hier zit nog een fout in. nullpointer exception. iets dat de header naar 
            // zichzelf linkt als er verder niets in de class staat
            while (!(current.next == null) && !current.next.value.Equals(findItem))
            {
                current = current.next;
            }
            return current;
        }

        private LNode<T> find(T findObject)
        {
            LNode<T> current = new LNode<T>();
            current = header.next;
            while (!(current.value.Equals(findObject)))
            {
                current = current.next;
            }
            return current;
        }

        public void remove(T findObject)
        {
            LNode<T> temp = findPrevious(findObject);
            if (!(temp.next == null))
            {

                temp.next = temp.next.next;
            }
            count--;
        }

        public void insert(T n1, T n2)
        {
            LNode<T> current = new LNode<T>();
            LNode<T> newNode = new LNode<T>(n1);
            current = find(n2);
            newNode.next = current.next;
            current.next = newNode;
            count++;
        }

        public void add(T newObject)
        {
            LNode<T> current = new LNode<T>(newObject);
            current.next = header.next;
            header.next = current;
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
    }
}
