using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ad
{
    public static class Sort
    {
        public static void BubbleSortArrayList<T>(this T[] arr) where T : IComparable<T>
        {
            // Outer loop
            for (var i = 0; i < arr.Length; i++)
            {

                // Innter loop
                for (var j = 0; j < arr.Length - 1; j++)
                {
                    // swap two elements if the left element is greater than the right element.
                    if (arr[j].CompareTo(arr[j + 1]) > 0)
                    {
                        // Swap Elements
                        Swap.swap<T>(ref arr[j], ref arr[j + 1]);
                    }
                }
            }

        }

        public static void InsertionSortArrayList<T>(this T[] arr) where T : IComparable<T>
        {
            //Based on http://www.developerin.net/a/55-Algorithm-in-CSharp/38-Insertion-Sort

            T temp;
            int j;

            // Outer loop
            for (int i = 1; i < arr.Length; i++)
            {
                temp = arr[i];
                j = i - 1;

                //Inner loop

                while (j >= 0 && (arr[j].CompareTo(temp) > 0))
                {
                    arr[j + 1] = arr[j];

                    j--;
                }
                arr[j + 1] = temp;


            }
        }
        public static void SmartBubbleSortArrayList<T>(this T[] arr) where T : IComparable<T>
        {
            bool swapped = false;

            // Outer loop
            for (var i = 0; i < arr.Length; i++)
            {
                swapped = false;
                // Inner loop
                for (var j = 0; j < arr.Length - 1; j++)
                {
                    // swap two elements if the left element is greater than the right element.
                    if (arr[j].CompareTo(arr[j + 1]) > 0)
                    {
                        // Swap Elements
                        Swap.swap<T>(ref arr[j], ref arr[j + 1]);
                        swapped = true;
                    }
                }
                if (swapped == false)
                {
                    i = arr.Length;
                }
            }
        }
    }
}
