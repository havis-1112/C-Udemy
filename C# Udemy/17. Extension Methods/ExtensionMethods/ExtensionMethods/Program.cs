using ExtensionMethods2;

namespace ExtensionMethods
{
    public class Program
    {
        class Student
        {
            public int Id { get; set; }
        }
        static void Main()
        {
            string name = "havis";
            //Console.WriteLine(name.RemoveVowel()); -> there is no specific method in string class to remove vowels

            Console.WriteLine(name.RemoveVowels());

            // pattern matching
            object obj = new Student();

            if(obj is Student)
            {
                Student s = (Student)obj;
                Console.WriteLine(s.Id);   // old way -> check + typecast 
            }

            if(obj is Student stu)         // new way -> check + typecast
            {
                Console.WriteLine(stu.Id); 
            }

            // implicitly typed variable - data type decided at compile time
            var friend = "dila";
            //friend = 10; -> cant convert to another type

            // explicitly typed variable - data type decided at run time
            dynamic value = 10;
            value = "vishnu"; // can convert to any type    

            // inner class - class within a class
            
        }
    }
}
