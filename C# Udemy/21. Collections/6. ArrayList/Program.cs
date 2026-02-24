using System;
using System.Collections;

namespace Arraylist
{
    public class Program
    {
        /*
         
        arraylist - store any type of elements
                    path(namespaces) - System.Collection.ArrayList
                    dynamic sized
                    index based access
                    not sorted by default
                    each element is treated as System.Object type while adding,retrieving,searchig elements

        syntax
        ArrayList referenceVariable = new ArrayList( );
         
         */

        public void Method()
        {
            ArrayList list = new ArrayList();

            // Add elements
            list.Add(10);
            list.Add(20);
            list.Add(30);

            // AddRange
            list.AddRange(new int[] { 40, 50 });

            // Count and Capacity
            Console.WriteLine(list.Count);
            Console.WriteLine(list.Capacity);

            // Insert
            list.Insert(1, 15);

            //foreach
            foreach (var item in list) Console.WriteLine(item);

            // InsertRange
            list.InsertRange(3, new int[] { 25, 26 });

            // IndexOf
            list.IndexOf(30);

            // BinarySearch (ArrayList must be sorted first)
            list.Sort();
            int index = list.BinarySearch(25);

            // Contains
            Console.WriteLine(list.Contains(15));

            // Remove
            list.Remove(26);

            // RemoveAt
            list.RemoveAt(0);

            // RemoveRange
            list.RemoveRange(1, 2);

            // Reverse
            list.Reverse();

            // ToArray
            object[] arr = list.ToArray();

            // Clear
            list.Clear();

        }
    }
}
