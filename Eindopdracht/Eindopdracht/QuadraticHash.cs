using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace HashProject
{
    class QuadraticHash
    {
        string[] arrayString;
        public QuadraticHash(int arraySize)
        {
            arrayString = new string[arraySize + 1];
            string[] someNames = new String[]{"Floor", "Wouter", "Roeland", "Ronald", "Shahrukh", "Fabian", "Esther", "Bjorne"};
            for(int i = 0; i <= someNames.GetUpperBound(0); i++)
            {
                string name = someNames[i];
                int hashVal = quadraticHash(name);
                arrayString[hashVal] = name;
            }
            for(int i = 0; i <= arrayString.GetUpperBound(0); i++)
            {
                if(arrayString[i] != null)
                {
                    Console.WriteLine(i + " " + arrayString[i]);
                }
            }
        }

        public int hash(string invoeg)
        {
            long hashReturn = 0;
            char[] charArray = invoeg.ToCharArray();
            for (int i = 0; i <= charArray.GetUpperBound(0); i++)
                hashReturn += 37 * charArray[i];
            hashReturn = hashReturn % arrayString.GetUpperBound(0);
            if(hashReturn < 0)
            {
                hashReturn += arrayString.GetUpperBound(0);
            }
            return (int)hashReturn;
        }

        public int quadraticHash(string invoeg)
        {
            int Qhash = 0;
            int hashReturn = hash(invoeg);
            int j = 0;
            Boolean check = true;
            if (arrayString[hashReturn] == null)
            {
                return hashReturn;
            }
            for (int i = 1; i <= arrayString.GetUpperBound(0); i++)
            {
                if(check == true)
                {
                    j = i * i;
                    check = false;
                }
                else
                {
                    j = j * -1;
                    check = true;
                }
                Qhash = (hashReturn + j) % arrayString.GetUpperBound(0); 
                if(Qhash < 0)
                {
                    Qhash += arrayString.GetUpperBound(0);
                }
                //if(Qhash > arrayString.GetUpperBound(0))
                //{
                        //voeg nieuwe arrayruimte toe, moet nog geïmplementeerd worden
                //}
                if(arrayString[Qhash] == null)
                {
                    return Qhash;
                }
            }
            return -1;
        }

        public void insert()
        {

        }

        public void retrieve()
        {

        }
    }
}
