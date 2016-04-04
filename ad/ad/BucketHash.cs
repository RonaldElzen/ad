
namespace ad
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace Eindopdracht
    {
        public class bucketHash
        {
            //Needs to be dynamic
            int size = 0;
            ArrayList[] data;
            public bucketHash(int size)
            {
                data = new ArrayList[size];
                for (int i = 0; i < size - 1; i++)
                {
                    data[i] = new ArrayList(4);
                }
            }
            public int Hash<T>(T item) where T : IComparable<T>
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


            public void Insert<T>(T item) where T : IComparable<T>
            {
                int hash_value;
                hash_value = Hash(item);
                if (data[hash_value].Contains(item))
                {
                    data[hash_value].Add(item);
                }
            }

            public void Remove<T>(T item) where T : IComparable<T>
            {
                int hash_value;
                hash_value = Hash(item);
                if (data[hash_value].Contains(item))
                {
                    data[hash_value].Remove(item);
                }
            }

            public ArrayList[] getBucketHash()
            {
                return data;
            }
        }
    }

}
