using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    public class Program
    {
        /*
         
        queue - works in FIFO
                path(namespaces) - System.Collections.Generic.Queue
                generic class
                enqueue,dequeue,peek          
                
        syntax
        Queue<T> referenceVariable = new Queue<T>();

         */

        public void Method()
        {
            Queue<int> queue = new Queue<int>();

            // Enqueue(T) – add elements to queue
            queue.Enqueue(10);
            queue.Enqueue(20);
            queue.Enqueue(30);

            //foreach
            foreach(var item in queue)
            Console.WriteLine(item);

            // Count
            Console.WriteLine(queue.Count);

            // Peek() – view first element without removing
            Console.WriteLine(queue.Peek());

            // Dequeue() – remove and return first element
            Console.WriteLine(queue.Dequeue());

            // Contains(T)
            Console.WriteLine(queue.Contains(20));
            Console.WriteLine(queue.Contains(10));

            // ToArray()
            int[] arr = queue.ToArray();

            // Clear()
            queue.Clear();
        }

    }
}
