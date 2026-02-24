namespace ConsoleApp1
{
    public class Program
    {
        public int Age;
        public string Name;
        public int Height;

        /*
         
        constructor - special method to intialize objects (fields)

        accessmodifier classname(parameter)
        {
         .............
        }
         
        rules of constructor
        --------------------
        constructor name should be same as class name
        reccommended to be public or internal
        no return type (not evenn void)
        can have parameters
        a class can have multiple constructors (constructor overloading)

        instance constructor - instance fields,execute automaticaly when object is created,private by default
        static constructor - static  fields,exexute only when first object is created,public by default,parameterless

        types of constructor - parameter,parameterless  implicit - after compilation,explicit - while coding

         */

        // constructor overloading
        public Program()
        {
            Console.WriteLine("havis");
        }

        public Program(int age)
        {
            Age = age; 
        }
        public Program(int age,string name)
        {
            Age = age;
            Name = name;    
        }
        static Program()
        {
            Console.WriteLine("static Constructor");
        }
        static void Main()
        {
            //object initializer - when no constructor is needed
            Program p1 = new Program() { Age = 10 };
            Program p2 = new Program(10) { Name="hari"};
        }
    }
}
