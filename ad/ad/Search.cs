using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ad
{
   public class Search
    {

        //Based on http://www.c-sharpcorner.com/blogs/binary-search-implementation-using-c-sharp1 
        public static int binarySearch(int[] inputArray, int key, int min, int max)

        {

            while (min <= max)

            {


                //Search for the mid point
                int mid = (min + max) / 2;

                if (mid == inputArray.Length)
                {
                    return -1;
                }

                //If the key equals the value 
                if (key == inputArray[mid])
                {
                    //Return mid
                    return mid + 1;
                }


                else if (key < inputArray[mid])
                {
                    max = mid - 1;
                }

                else

                {
                    min = mid + 1;
                }

            }
            return -1;
        }

        public static int sequentialSearch(int[] arr, int searchNumber)
        {
            int found = -1;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == searchNumber)
                {
                    found = i + 1;
                    i = arr.Length;
                }
            }
            return found;
        }

        public static int highestValue(int[] arr)
        {
            int max = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                }
            }
            return max;
        }

        public static int lowestValue(int[] arr)
        {
            int min = 10;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < min)
                {
                    min = arr[i];
                }
            }
            return min;
        }

    }
}
