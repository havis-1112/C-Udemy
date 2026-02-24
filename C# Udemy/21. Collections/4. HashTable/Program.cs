using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    public class Program
    {
        /*
         
        hashtable - stores in key/value pairs
        path(namespace) - System.Collection.Hashtable
        
        hashcode for key %  size of hashtable
        number - hashcode is number
        string - based on some characted logic

        if same index for 2 buckets store as linked list and linear search them to find bucket

        dynamically sized
        key cant be null or duplicate but value can be
        non generic class
        not index based,access using key

        syntax
        Hashtable referenceVariable = new Hashtable();


        */
        public void Method()
        {
            Hashtable ht = new Hashtable();

            // Add(key, value)
            ht.Add(1, "Apple");
            ht.Add(2, "Banana");
            ht.Add(3, "Orange");

            // Count
            Console.WriteLine(ht.Count);

            // [key] indexer
            Console.WriteLine(ht[2]);

            // Keys
            foreach (object key in ht.Keys)
            {
                Console.WriteLine(key);
            }

            // Values
            foreach (object value in ht.Values)
            {
                Console.WriteLine(value);
            }

            // ContainsKey
            Console.WriteLine(ht.ContainsKey(3));

            // ContainsValue
            Console.WriteLine(ht.ContainsValue("Apple"));

            // Remove(key)
            ht.Remove(2);
            Console.WriteLine(ht.Count);

            // Clear
            ht.Clear();

        }
    }
}
