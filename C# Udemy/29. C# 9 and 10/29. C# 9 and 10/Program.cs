// =======================================
// 1. Global Using (C# 10)
// =======================================
global using System;
global using System.Runtime.CompilerServices;

// =======================================
// 2. File Scoped Namespace (C# 10)
// =======================================
namespace CSharp9And10FullDemo;

// =======================================
// 3–4. Init Only + Deconstruct
// =======================================
class Person
{
    public string Name { get; init; }
    public int Age { get; init; }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public void Deconstruct(out string name, out int age)
    {
        name = Name;
        age = Age;
    }
}

class Order
{
    public Person Customer { get; set; } = null!;
}

// =======================================
// MAIN PROGRAM
// =======================================
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        // 5. Nullable Reference Types
        string name = "Hari";
        string? nullableName = null;

        // 6. Null-forgiving Operator
        string? name2 = "Hari";
        Console.WriteLine(name2!.Length);

        // 7. Target-Typed new
        Startup startup = new();

        // 8. Type Pattern
        object obj = "Hari";
        if (obj is string)
            Console.WriteLine("It is string");

        // 9. Pattern Matching with when
        switch (obj)
        {
            case string s when s.Length > 3:
                Console.WriteLine("Long string");
                break;
            case string:
                Console.WriteLine("Short string");
                break;
        }

        // 10. Switch Expression
        object personObj = new Person("Hari", 25);
        string result = personObj switch
        {
            Person p when p.Age > 18 => "Adult",
            Person => "Minor",
            _ => "Unknown"
        };
        Console.WriteLine(result);

        // 11. Relational Pattern
        int number = 10;
        Console.WriteLine(number switch
        {
            < 0 => "Negative",
            > 0 => "Positive",
            0 => "Zero"
        });

        // 12. Logical Pattern
        int age = 25;
        Console.WriteLine(age switch
        {
            > 18 and < 60 => "Working Age",
            < 18 => "Minor",
            _ => "Senior"
        });

        // 13. Property Pattern
        Person person = new("Hari", 25);
        Console.WriteLine(person switch
        {
            { Age: > 18 } => "Adult",
            _ => "Minor"
        });

        // 14. Tuple Pattern
        int x = 0, y = 1;
        Console.WriteLine((x, y) switch
        {
            (0, 0) => "Origin",
            (0, _) => "Y Axis",
            (_, 0) => "X Axis",
            _ => "Other"
        });

        // 15. Positional Pattern
        Console.WriteLine(person switch
        {
            ("Hari", > 18) => "Adult Hari",
            _ => "Other"
        });

        // 16. Nested Property Pattern
        Order order = new()
        {
            Customer = new Person("Hari", 25)
        };

        Console.WriteLine(order switch
        {
            { Customer: { Age: > 18 } } => "Adult Customer",
            _ => "Other"
        });

        // 17. Extended Property Pattern (C# 10)
        Console.WriteLine(order switch
        {
            { Customer.Age: > 18 } => "Adult Customer",
            _ => "Other"
        });

        // ===============================
        // RECORDS
        // ===============================

        // 18. Basic Record (Value Equality)
        var p1 = new PersonRecord("Hari", 21);
        var p2 = new PersonRecord("Hari", 21);
        Console.WriteLine(p1 == p2);

        // 19. Nested Record
        var personWithAddress =
            new PersonWithAddress("Hari", 21, new Address("Chennai", "India"));
        Console.WriteLine(personWithAddress.Address.City);

        // 20. Mutable Record
        var mutable = new MutablePerson("Krishna") { Age = 20 };
        mutable.Age = 25;
        Console.WriteLine(mutable.Age);

        // 21. With Expression
        var modified = p1 with { Age = 30 };
        Console.WriteLine(modified);

        // 22. Record Deconstruction
        var (personName, personAge) = p1;
        Console.WriteLine(personName + " " + personAge);

        // 23. Auto ToString
        Console.WriteLine(p1);

        // 24. Record Validation
        var validPerson = new PersonWithValidation("Ram", 25);
        Console.WriteLine(validPerson);

        // 25. Readonly Struct
        Point pt = new(5, 6);
        Console.WriteLine($"Point: {pt.X}, {pt.Y}");

        // 26. Module Initializer executes automatically

        // 27. Record Inheritance
        var emp = new Employee("Hari", 25, 50000);
        Console.WriteLine(emp);

        // 28. Record Struct
        var pointRec = new PointRecord(10, 20);
        Console.WriteLine(pointRec);

        // 29. Sealed ToString
        Console.WriteLine(p1.ToString());

        // 30. Command Line Arguments
        if (args.Length > 0)
            Console.WriteLine("Argument: " + args[0]);

        // 31. Partial Method Return
        var calc = new Calculator();
        Console.WriteLine(calc.Add(5, 3));

        // 32. Static Lambda
        Func<int, int> square = static x => x * x;
        Console.WriteLine(square(5));

        // 33. Explicit Lambda Return Type
        var addFunc = int (int a, int b) => a + b;
        Console.WriteLine(addFunc(10, 20));

        // 34. Const Interpolated String
        const string firstName = "Hari";
        const string message = $"Hello {firstName}";
        Console.WriteLine(message);

        // 35–38 Interface Features
        IAdvanced.StaticMethod();
        IAdvanced adv = new AdvancedClass();
        adv.Display();

        // 39. Index From End
        int[] numbers = { 10, 20, 30, 40 };
        Console.WriteLine(numbers[^1]);
        Console.WriteLine(numbers[^2]);
    }
}

// =======================================
// RECORD DEFINITIONS
// =======================================

record PersonRecord(string Name, int Age)
{
    public sealed override string ToString()
        => $"Name: {Name}, Age: {Age}";
}

record Address(string City, string Country);
record PersonWithAddress(string Name, int Age, Address Address);

record MutablePerson(string Name)
{
    public int Age { get; set; }
}

record PersonWithValidation
{
    public string Name { get; init; }
    public int Age { get; init; }

    public PersonWithValidation(string name, int age)
    {
        if (age < 0)
            throw new ArgumentException("Age cannot be negative");

        Name = name;
        Age = age;
    }
}

record Employee(string Name, int Age, int Salary)
    : PersonRecord(Name, Age);

record struct PointRecord(int X, int Y);

// =======================================
// 25. Readonly Struct
// =======================================
readonly struct Point
{
    public int X { get; init; }
    public int Y { get; init; }

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }
}

// =======================================
// 31. Partial Methods
// =======================================
partial class Calculator
{
    public partial int Add(int a, int b);
}

partial class Calculator
{
    public partial int Add(int a, int b)
        => a + b;
}

// =======================================
// 35–38 Interface Features
// =======================================
interface IAdvanced
{
    static void StaticMethod()
    {
        Console.WriteLine("Static method in interface");
    }

    void Display()
    {
        Helper();
    }

    private void Helper()
    {
        Console.WriteLine("Private helper method");
    }
}

class AdvancedClass : IAdvanced { }

// =======================================
// 26. Module Initializer
// =======================================
class Startup
{
    [ModuleInitializer]
    public static void Initialize()
    {
        Console.WriteLine("Module Initializer Executed");
    }
}