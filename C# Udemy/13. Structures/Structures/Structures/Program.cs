namespace Structures
{
    /*
     
    struct
    ------

    store simple data
    stored in stack
    ccontains fields, methods, parameterized constructor, properties, events
    no parameterless constructor or destructor
    cannot inherit class/struct
    can implement interface
    faster than class
    
    struct - lightweight with limited oops features
     
     */
    struct Student
    {
        public int Id;
        public string Name;

        public Student(int id, string name)
        {
            Id = id;    
        }
    }

    // new keyword does not create object for struct it just calls the constructor

    // readonly struct

    readonly struct Employee
    {
        public readonly int EmpId;  // can be changed only through constructor
    }

    // all primitive types are structures
    // sbyte -> System.SByte
}
