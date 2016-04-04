using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ad
{
    public class ArrayList<X>
    {
        private X[] list = new X[0];

        //add
        public void Add(X item)
        {
            Array.Resize(ref list, list.Length + 1);
            list[list.Length - 1] = item;
        }

        public int Length()
        {
            return list.Length;
        }

        public X Get(int item)
        {
            return list[item];
        }


        //clear
        public void Clear()
        {
            Array.Resize(ref list, 0);
        }

        //contains 
        public bool Contains(X item)
        {
            var itemExists = false;
            foreach (var x in list.Where(x => x.Equals(item)))
            {
                itemExists = true;
            }
            return itemExists;
        }



        //indexof
        public int IndexOf(X item)
        {
            var index = -1;
            for (var i = 0; i < list.Length; i++)
            {
                if (list[i].Equals(item))
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

        //insert
        public void Insert(int index, X item)
        {
            if (index <= Length() && index >= 0)
            {
                list[index] = item;
            }
        }


        //remove
        public void Remove(X item)
        {
            var itemToRemove = new int[list.Length];
            var numberOfItems = 0;

            for (var i = 0; i < list.Length; i++)
            {
                if (list[i].Equals(item))
                {
                    itemToRemove[numberOfItems] = i;
                    numberOfItems++;
                }
            }

            for (var y = 0; y < numberOfItems; y++)
            {
                for (var j = itemToRemove[y]; j < list.Length - 1; j++)
                {
                    list[j] = list[j + 1];
                }
            }

            Array.Resize(ref list, list.Length - numberOfItems);
        }

        //remove i
        public void RemoveI(int index)
        {
            for (var i = index; i < list.Length - 1; i++)
            {
                list[i] = list[i + 1];
            }
            Array.Resize(ref list, list.Length - 1);
        }

        //shows the arraylist
        public void Show()
        {
            for (var i = 0; i < Length(); i++)
            {
                Console.WriteLine(list[i]);
            }
        }



    }
}
