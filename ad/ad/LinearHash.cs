using ad;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ad
{
    class LinearHash
    {
        int size = 0;
        ArrayList[] data;

        public LinearHash(int size)
        {
            ArrayList[] data = new ArrayList[size];

        }

        public int Hash<T>(T item)
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

        public void Insert<T>(T item)
        {
            int hash_value = Hash(item);
            int i = 0;
            while (data[hash_value] != null)
            {
                hash_value = hash_value + 1 % data.GetUpperBound(0);
            }
            data[hash_value].Add(item);
        }

        public void Remove(string item)
        {
            int hashValue = Hash(item);
            int i = 0;
            while (data[hashValue] == null)
            {
                i++;
                hashValue = hashValue + 1 % data.GetUpperBound(0);
            }
            data[hashValue] = null;
        }

        public ArrayList[] GetLinearHash()
        {
            return data;
        }
    }
}



