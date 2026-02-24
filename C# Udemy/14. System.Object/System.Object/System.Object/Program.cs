using System;

namespace ObjectDemo
{
    public class Student
    {
        public int Id;
        public string Name;

        // Equals(): compares object fields (not reference)
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Student))
                return false;

            Student s = (Student)obj;
            return this.Id == s.Id && this.Name == s.Name;
        }

        // GetHashCode(): returns hash based on Id
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        // ToString(): custom string representation
        public override string ToString()
        {
            return $"Student Id: {Id}, Name: {Name}";
        }

        static void Main(string[] args)
        {
            Student s1 = new Student { Id = 1, Name = "Hari" };
            Student s2 = new Student { Id = 1, Name = "Hari" };

            Console.WriteLine(s1.Equals(s2));    // True 
            Console.WriteLine(s1.GetHashCode()); // Hash value
            Console.WriteLine(s1.GetType());     // ObjectDemo.Student
            Console.WriteLine(s1.ToString());    // Student Id: 1, Name: Hari


            // boxing - value type → reference type
            int number = 10;
            object boxedObj = number;

            // unboxing - reference type → value type
            int unboxedNumber = (int)boxedObj;

            Console.WriteLine(unboxedNumber); // 10
        }
    }
}
