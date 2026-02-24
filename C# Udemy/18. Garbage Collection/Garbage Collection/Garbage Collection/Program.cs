using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarbageCollection
{
    /*

       garbage collection - deleting objects that are no longer needed from memory

       memory allocation - clr allocate memory in heap (alive objects)
       garbage collection - when heap space is low, gc collects unreferenced objects from heap (dead objects)

       gc trigger conditions:
       ----------------------
       1. when heap memory is full or low
       2. explicit call to gc.collect() method

       generations:
       ------------
       0 - short lived objects (newly created objects)
       1 - medium lived objects (objects that survive gen 0 collection)
       2 - long lived objects (objects that survive gen 1 collection, static objects)

       managed vs unmanaged resources:
       -------------------------------
       managed - memory managed by clr (strings, arrays, custom objects)
       unmanaged - memory not managed by clr (file handles, database connections, gdi objects)

       clearing unmanaged resources:
       -----------------------------
       1. Destructor (finalizer) - runs automatically at object cleanup,usually at end of the app
       2. IDisposable interface - provides a Dispose() method for manual cleanup of unmanaged resources

       destructor:
       -----------
       ~classname()
       called automatically by clr just before object deletion.
       does not deallocate memory (gc handles memory)

       gc - finds unreferenced objects and calls their destructors (finalizers) to cleanup unmanaged resources
       destructor - cleans object memory is still allocated until gc deallocates it
       gc - collects object from memory

       dispose method:
       ---------------
       IDisposable interface has Dispose() method → used to clean unmanaged resources (file streams, DB connections, etc.)

       gc - run automatically when memory low or no space that time destructor runs
       dispose - run manually when no longer needed (using statement automates this)

        */

    public class Connection
    {
        // constructor
        public Connection()
        {
            Console.WriteLine("DB connection opened");
        }

        // destructor (finalizer) - compiled to finalize method
        ~Connection()
        {
            // cleanup code (unmanaged resource cleanup)
            Console.WriteLine("DB connection closed (Destructor)");
        }

    }

    public class Connection2 : IDisposable
    {
        public Connection2()
        {
            Console.WriteLine("db connection opened");
        }

        // dispose method for cleanup
        public void Dispose()
        {
            Console.WriteLine("db connection closed (dispose)");
        }
    }

    public class Program
    {
        static void Main()
        {
            Connection c = new Connection();

            c = null; // object becomes unreferenced

            GC.Collect();                 //  gc “schedules” cleanup of unreferenced objects
            GC.WaitForPendingFinalizers(); // wait until the cleanup actually happens

            using (Connection2 c2 = new Connection2())
            {

            } // dispose() automatically called here
        }
    }

}