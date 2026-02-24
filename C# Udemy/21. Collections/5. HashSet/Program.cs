using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashSet
{
    /*
     
    hashset - stores unique values
              path(namespaces) - System.Collection.Generic.Hashset
              generate index based on hashcode
              add value as linkedlist for similar index
              generic class
              cant get/set based on key/index
              hashset allows only one null value
              hashtable stores only one null key but multiple null values
              use contains method to search element
              cant sort element in hashset
    
    syntax
    HashSet<T> referenceVariable = new HashSet<T>( );

     */
    public class Program
    {
        public void Method()
        {
            HashSet<int> set = new HashSet<int>();

            // Add elements
            set.Add(1);
            set.Add(2);
            set.Add(3);
            set.Add(4);

            //Count
            Console.WriteLine(set.Count);

            // Contains
            Console.WriteLine(set.Contains(3));

            // Remove
            set.Remove(2);

            // RemoveWhere (remove even numbers)
            set.RemoveWhere(x => x % 2 == 0);

            //foreach
            foreach (int val in set)
            {
                Console.WriteLine(val);
            }

            // UnionWith
            HashSet<int> set2 = new HashSet<int> { 5, 6, 3 };
            set.UnionWith(set2);

            // IntersectWith
            HashSet<int> set3 = new HashSet<int> { 3, 5, 7 };
            set.IntersectWith(set3);

            // Clear
            set.Clear();
        }

    }
}
