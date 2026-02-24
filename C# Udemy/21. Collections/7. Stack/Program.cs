using System;
using System.Collections.Generic;


namespace Stack
{
    public class Program
    {
        /*

         stack - group of elements based on LIFO
                 path(namespaces) - System.Collections.Generic.Stack
                 stores elements in bottom up approach
                 cant access based on index
                 add - push ,remove - pop,access last element - peek
                 

        syntax
        Stack<T> referenceVariable = new Stack<T>( );

       */

        public void Method()
        {
            Stack<int> stack = new Stack<int>();

            // Push(T) – add elements
            stack.Push(10);
            stack.Push(20);
            stack.Push(30);

            //foreach
            foreach (var item in stack) Console.WriteLine(item);

            // Peek() – returns top element without removing
            Console.WriteLine(stack.Peek());

            // Pop() – removes and returns top element
            Console.WriteLine(stack.Pop());

            // Contains(T) – check if element exists
            Console.WriteLine(stack.Contains(20));
            Console.WriteLine(stack.Contains(30));

            // ToArray() – convert stack to array
            int[] arr = stack.ToArray();

            // Clear() – removes all elements
            stack.Clear();

        }
    }
}
