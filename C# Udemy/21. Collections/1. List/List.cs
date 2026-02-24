using System;
using System.Collections.Generic;

namespace Collections
{
    public class List
    {
        /*

          list - dynamically sized
                 allow duplicate values
                 index based
                 not sorted by default
                 generic class
                 path(namespaces) - System.Collections.Generic.List
                 
          collections internally uses arrays        

          how collection works
          collection(10 elements) - add new element - create new array - copy the 10 element - add new element

         */

        public void Method()
        {

            List<int> myList = new List<int>() { 10, 20, 30 };
            List<int> myList2 = new List<int>(10) { 10, 20, 30 }; // this does not create array everytime until 11 element is getting added
            List<int> myList3 = new List<int>() { 1, 2, 3, 4, 5 };

            //for each loop
            foreach (int item in myList)
            {
                Console.WriteLine(item);       //10,20,30
            }

            //for loop
            for (int i = 0; i < myList.Count; i++)
            {
                Console.WriteLine(myList[i]);   //10,20,30
            }

            /*
             
             add - add single element
             addrange - adds multiple element

             Add(T newValue)
             AddRange(IEnumerable<T> collection)

             IEnumerable<T> represents any collection of type T that can be iterated using foreach
             I - iterate, Enumerable - can be listed
             IEnumerable<T> - this does not perform any opertions but loops through any collection you provide

            */

            myList.Add(25);                        //{10,20,30,25}
            myList2.AddRange(new int[] { 1, 2 });  //{ 10, 20, 30, 1, 2 }

            /*
             
            Insert(int index, T newValue)
            InsertRange(int index, IEnumerable<T> newValue)
             
             */

            myList.Insert(1, 88);   //{10,88,20,30,25}
            myList2.InsertRange(2, new List<int>() { 19, 200 }); //{ 10, 20, 30,19,200, 1, 2 }

            //Remove(T newValue) 
            myList.Remove(30);     //{10,88,20,25}

            //RemoveAt(int index)
            myList.RemoveAt(0);   //{88,20,25} 

            //RemoveRange(int index, int count)
            myList.RemoveRange(0, 2);  //{25}

            //RemoveAll(value => condition)
            myList2.RemoveAll(n => n >= 30);    //{ 10,20,19,1, 2 }

            //Clear()
            myList.Clear();  //clears all list

            /*
            
            IndexOf() - searches the given value,if found returns its index else returns -1
            it performs linear search,if found stop searching
            linear search has good performance for small collection
            for large collection binary search is recommended

            IndexOf(T value, int startIndex)

            */
            myList2.IndexOf(19, 1);
            myList2.IndexOf(19);


            /*
              
            binary search if found return index else -1
            works only if list is sorted

            how it works
            list - middle(n/2)
            checks middle value is lesser/greater than the given value
            if lesser - search first section
            if greater - search second section
            thus search half of array and improves performance

            */
            myList3.BinarySearch(3);

            //Contains( T value ) - true or false
            myList3.Contains(5);

            //Sort() - sort the list
            myList3.Sort();

            //Reverse() - reverse the total list
            myList3.Reverse();

            /*
             
            ToArray() - convert to array
            list - dynamic, built in methods, occupy slightly more memory
            array - fixed, only index access, occupy less memory

             */
            myList3.ToArray();

            //ForEach
            myList3.ForEach(n => 
            { 
                Console.WriteLine(n); 
            });

            myList3.ForEach(n => Console.WriteLine(n));

            //Exists()
            myList3.Exists(n => n>3);  //true(atleast one element) or false

            //Find()
            myList.Find(n => n>3); //returns first matching element else return default value

            //FindIndex()
            myList.FindIndex(n => n > 3); //returns first matching index else returns -1

            //FindLast()
            myList3.FindLast(n => n > 3); //retuns last matching element else return default value

            //FindlastIndex()
            myList.FindLastIndex(n => n > 3); //returns last matching index else returns -1

            //FindAll()
            myList3.FindAll(n => n > 2);  //returns all matching value else returns empty collection

            //ConvertAll()
            myList.ConvertAll(n => Convert.ToDouble(n));

        }





    }
}
