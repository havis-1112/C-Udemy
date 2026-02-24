
using System;
using System.Collections.Generic;


namespace SortedList
{
    public class Program
    {
        /*
         
        sorted list - contains elements in key/value pairs
                      path(namespace) - System.Collection.Generic.SortedList
                      get/set value based on key
                      key cant be null or duplicate
                      dynamically sized
                      sorted by default based on key
                      slow compared to dictionary
                      index access is possible here

        dictionary internally uses - hashtable
        sorted list internally uses - 2 arrays for key and value
                                                             
        syntax
        SortedList<TKey, TValue> referenceVariable = new SortedList<TKey, TValue>();

         */

        public void Method()
        {
            SortedList<int, string> sList = new SortedList<int, string>();

            // Add elements
            sList.Add(3, "C");
            sList.Add(1, "A");
            sList.Add(2, "B");

            // Count property
            Console.WriteLine(sList.Count);

            // [TKey] indexer - get value by key
            Console.WriteLine(sList[2]);

            // Keys property
            foreach (int key in sList.Keys)
            {
                Console.WriteLine(key);
            }

            // Values property
            foreach (string value in sList.Values)
            {
                Console.WriteLine(value);
            }

            // ContainsKey method
            Console.WriteLine(sList.ContainsKey(1));

            // ContainsValue method
            Console.WriteLine(sList.ContainsValue("C"));

            // IndexOfKey method
            Console.WriteLine(sList.IndexOfKey(2));

            // IndexOfValue method
            Console.WriteLine(sList.IndexOfValue("B"));

            // Remove method
            sList.Remove(3);

            // Clear method
            sList.Clear();

        }
    }
}
