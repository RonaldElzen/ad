using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eindopdracht
{
    class Swap
    {
        public static void swap<T>(ref T val1, ref T val2)
        {
            T temp;
            temp = val1;
            val1 = val2;
            val2 = temp;
        }
    }
}
