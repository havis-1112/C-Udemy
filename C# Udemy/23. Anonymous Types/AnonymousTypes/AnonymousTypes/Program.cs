using ClassLibrary1;

namespace AnonymousTypes
{
    internal class Program
    {
        // anonymous type - default sealed class, properties are readonly , when u dont want to declare a separate class for properties use this
        static void Main()
        {
            Person p = new Person();

            var ps = new{Name= p.GetName(), Age=p.GetAge()}; // at compile time it is converted to a random class
            var person = new
            {
                PersonName = p.GetName(),
                Age = p.GetAge(),
                Address = new { Street = "abc", City = "xyz" } // nested anonymous objects
            };

            // anonymous arrays
            var persons = new[] {
                new { PersonName = "Scott", Email = "scott@gmail.com" },
                new { PersonName = "Smith", Email = "smith@gmail.com" },
                new { PersonName = "Allen", Email = "allen@gmail.com" },
                new { PersonName = "Jones", Email = "jones@gmail.com"  }
            };

            foreach (var item in persons)
            {
                Console.Write(item.PersonName);
                Console.Write(", ");
                Console.WriteLine(item.Email);
            }

            Console.WriteLine(ps.Name);
        }
    }
}
