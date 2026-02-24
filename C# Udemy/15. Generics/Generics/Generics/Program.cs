using System;

namespace Generics
{

    // generic class  - one or more type parameters
    class Box<T>
    {
        public T Value;  // T - temporary type
        
    }

    class Program
    {
        static void Main()
        {
            Box<int> box = new Box<int> {Value = 10};
            Box<string> box2 = new Box<string> { Value = "havis"};

            Console.WriteLine(box.Value); // 10
            Console.WriteLine(box2.Value); // havis

            // generic methods

            void Print<T>(T value)
            {
                Console.WriteLine(value);
            }

            Print<int>(10);
            Print<string>("Hello");
        }
    }

    /*
     
    generic constraints
    -------------------
    where T : class
    where T : struct
    where T : ClassName
    where T : InterfaceName
    where T : new( )

    adds restriction to type,can have multiple constraints
     
     */
}
