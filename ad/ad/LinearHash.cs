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

        public int Hash<T>(T item)
        {


            long tot = 0;
            char[] charray;

            //Make item a string and make a chararray
            //NEEDS TO BE CHECKED

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

        public void Insert(T item)
        {
            int hash_value;
            hash_value = Hash(item);

            while (data[hash_value] != null)
            {
                hash_value = hash_value + 1 % data.GetUpperBound(0);
            }
            data[hash_value] = item;


        }

        public void Remove(T item)
        {
            int hash_value = Hash(item);
            int i = 0;
            while (data[hash_value] != null)
            {
                i++;
                hash_value = hash_value + 1 % data.GetUpperBound(0);
            }
            data[hash_value] = default(T);
        }

        public T[] GetLinearHash()
        {
            return data;
        }
    }
}


