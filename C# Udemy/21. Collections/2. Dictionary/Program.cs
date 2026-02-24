using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    public class Program
    {
        /*

         dictionary - contains elements in key/value pairs
                      path(namespace) - System.Collection.Generic.Dictionary
                      dynamically sized
                      key cant be null or duplicate but value can be
                      not sorted
                      can get/set value based on key
         
         syntax
         Dictionary<TKey, TValue> referenceVariable = new Dictionary<TKey, TValue>( );

        */

        public void Method()
        {
            Dictionary<int, string> dict = new Dictionary<int, string>();

            // Add elements
            dict.Add(1, "Apple");
            dict.Add(2, "Banana");
            dict.Add(3, "Orange");

            // Count property
            Console.WriteLine(dict.Count);

            // [TKey] indexer - get value using key
            Console.WriteLine(dict[2]);

            // Keys property
            foreach (int key in dict.Keys)
            {
                Console.WriteLine(key);
            }

            // Values property
            foreach (string value in dict.Values)
            {
                Console.WriteLine(value);
            }

            // ContainsKey method
            Console.WriteLine(dict.ContainsKey(3));

            // ContainsValue method
            Console.WriteLine(dict.ContainsValue("Apple"));

            // Remove method
            dict.Remove(2);

            // Clear method
            dict.Clear();

        }

    }
}
