using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ad
{
    public class LinearHash<T> where T : IComparable
    {

        T[] data;

        public LinearHash(int size)
        {
            data = new T[size];

        }

        /// <summary>
        /// Method to get the hash value of the item
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int Hash(T item)
        {
            long tot = 0;
            char[] charray;

            charray = item.ToString().ToCharArray();
            for (int i = 0; i < item.ToString().Length - 1; i++)
            {
                tot += 37 * tot + (int)charray[i];
            }
            tot = tot % data.GetUpperBound(0);
            if (tot < 0)
            {
                tot += data.GetUpperBound(0);
            }
            return (int)tot;
        }

        /// <summary>
        /// Inserts a new item to the Array at index of the hash
        /// </summary>
        /// <param name="item"></param>
        public void Insert(T item)
        {
            int hash_value;
            hash_value = Hash(item);

            // if the hash index already a item inserted to it, it should calculate a new hash
            while (data[hash_value] != null)
            {
                hash_value = hash_value + 1 % data.GetUpperBound(0);
            }
            data[hash_value] = item;
        }

        /// <summary>
        /// Removes an item from the array
        /// </summary>
        /// <param name="item"></param>
        public void Remove(T item)
        {
            // calculate the hash of the item.
            int hash_value = Hash(item);
            int i = 0;
            while (data[hash_value] != null)
            {
                i++;
                hash_value = hash_value + 1 % data.GetUpperBound(0);
            }
            data[hash_value] = default(T);
        }

        /// <summary>
        /// Method to return the array
        /// </summary>
        /// <returns></returns>
        public T[] GetLinearHash()
        {
            return data;
        }
    }
}


