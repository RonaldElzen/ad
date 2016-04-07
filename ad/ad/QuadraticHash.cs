using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ad
{
    /// <summary>
    /// This class creates an array of a size and inserts items on a calculated index in the array by use of quadratic probing.
    /// Hash method is based on the book "Algoritmes and datastructures using C#"
    /// </summary>
    /// <typeparam name="T">Any object can be inserted by use of generics</typeparam>
public class QuadraticHash<T>
    {
        int size;
        public T[] QhashArray;

        public QuadraticHash(int size)
        {
            this.size = size;
            QhashArray = new T[size];
        }
      

        /// <summary>
        /// The hash class calculates a key value to the given input.
        /// </summary>
        /// <param name="item">the item to which a key value is calculated</param>
        /// <returns>The key value of the given item</returns>
        public int hash(T item)
        {
            
            long hashReturn = 0;
            char[] charArray = item.ToString().ToCharArray();         //convert the item to a chararray
            for (int i = 0; i <= charArray.GetUpperBound(0); i++)
                hashReturn += 37 * charArray[i];                        //measure for each char of the chararray and count to the total
            hashReturn = hashReturn % QhashArray.GetUpperBound(0);      //remeasure the value to fit within the arraysize
            if (hashReturn < 0)                                         //when the value is smaller than zero...
            {
                hashReturn += QhashArray.GetUpperBound(0);              //measure the value greater than zero
            }
            return (int)hashReturn;                                     //return the measured value
        }

        /// <summary>
        /// Insert an item into the array.
        /// </summary>
        /// <param name="item">The item to insert into the array.</param>
        public void insert(T item)
        {
            int hashReturn = quadraticHash(item);
            QhashArray[hashReturn] = item;
        }

        /// <summary>
        /// Get the value of the given key.
        /// </summary>
        /// <param name="key">The key to a certain object in the array</param>
        /// <returns>The item of the given key or a default T when the key is invalid or the retrieved value is empty.</returns>
        public T retrieveValue(int key)
        {
            if (key > 0 && key <= QhashArray.GetUpperBound(0))
            {
                if (QhashArray[key] != null)
                {
                    return QhashArray[key];
                }
            }
            return default(T);
        }

        /// <summary>
        /// This method calculates the next available index in the array by quadratic probing when the hash method returns a value that collides.
        /// </summary>
        /// <param name="item">The item to calculate the value.</param>
        /// <returns>A key of an emty value.</returns>
        public int quadraticHash(T item)
        {
            int hashReturn = hash(item);                          //receive a hashvalue by using the hash() method
            if (QhashArray[hashReturn] == null)                     //if measured index is empty...
            {
                return hashReturn;                                  //...return the measured key
            }
            int Qhash = 0;
            int j = 0;
            Boolean check = true;
            for (int i = 1; i <= QhashArray.GetUpperBound(0); i++)  //...when the index in the array not is empty:
            {
                if (check == true)                                  //this if/else calculates wether the i^2 is plus or minus
                {
                    j = i * i;
                    check = false;
                }
                else
                {
                    j = j * -1;
                    check = true;
                }
                Qhash = hashReturn + j;                             //the new index to check is the value returned by hash() +/- i^2 modulo the arraysize
                if (Qhash < 0)                                      //if the index is smaller than zero, measure a new index
                {
                    Qhash += QhashArray.GetUpperBound(0);
                }
                if (Qhash > QhashArray.GetUpperBound(0))             //if the new index is greater than the arraysize, create a new array with double the size and copy the elements to this new array
                {
                    size = size * 2;
                    T[] newQhashArray = new T[size];
                    QhashArray.CopyTo(newQhashArray, 0);
                    QhashArray = newQhashArray;
                }
                if (QhashArray[Qhash] == null)                      //when the new index in the array is empty return this value
                {
                    return Qhash;
                }
            }
            return -1;
        }

        /// <summary>
        /// This method returns the total length of the array.
        /// </summary>
        /// <returns>the length of the array</returns>
        public int count()
        {
            return QhashArray.GetLength(0);
        }

        /// <summary>
        /// Remove the value at the given key.
        /// </summary>
        /// <param name="key">The key of the value to remove.</param>
        public void remove(int key)
        {
            if (key > 0 && key <= QhashArray.GetUpperBound(0))
            {
                if (QhashArray[key] != null)
                {
                    QhashArray[key] = default(T);
                }
            }
        }

        /// <summary>
        /// Return the Hash
        /// </summary>
        public T[] getArray()
        {
            return QhashArray;
            }
        }
    }

