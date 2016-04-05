using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ad
{
    /// <summary>
    /// ArrayList Class
    /// </summary>
    /// <typeparam name="T">Type</typeparam>
    public class ArrayList<T>
    {
        private T[] list = new T[0];

        //Add items to the arraylist
        public void Add(T item)
        {
            Array.Resize(ref list, list.Length + 1);
            list[list.Length - 1] = item;
        }

        //returns the length of the array
        public int Length()
        {
            return list.Length;
        }


        public T Get(int item)
        {
            return list[item];
        }


        //clear
        public void Clear()
        {
            Array.Resize(ref list, 0);
        }

        /// <summary>
        /// Contains method:Check item exits in the array and returns true if exist
        /// </summary>
        /// <param name="item">item</param>
        /// <returns>true/false</returns>
        public bool Contains(T item)
        {
            var itemExists = false;
            foreach (var t in list.Where(t => t.Equals(item)))
            {
                itemExists = true;
            }
            return itemExists;
        }

        /// <summary>
        /// check if item exist in array
        /// </summary>
        /// <param name="item">int</param>
        /// <returns></returns>
        public int IndexOf(T item)
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

        /// <summary>
        /// insert items at given index
        /// </summary>
        /// <param name="index"></param>
        /// <param name="item"></param>
        public void Insert(int index, T item)
        {
            if (index <= Length() && index >= 0)
            {
                list[index] = item;
            }
        }


        /// <summary>
        /// Remove items from array.
        /// it removes the same number of items at the end of the array
        /// </summary>
        /// <param name="item"></param>
        public void Remove(T item)
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

        /// <summary>
        /// remove items at the index of the array
        /// </summary>
        /// <param name="index">type-int</param>
        public void RemoveI(int index)
        {
            for (var i = index; i < list.Length - 1; i++)
            {
                list[i] = list[i + 1];
            }
            Array.Resize(ref list, list.Length - 1);
        }

        /// <summary>
        /// print the content
        /// </summary>
        public void Show()
        {
            for (var i = 0; i < Length(); i++)
            {
                Console.WriteLine(list[i]);
            }
        }



    }
}