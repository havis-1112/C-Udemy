using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Arrays.Program;

namespace Arrays
{
    public class Program
    {
        public class Employee
        {
            public int EmpID { get; set; }
            public string EmpName { get; set; }
        }
        static void Main(string[] args)
        {
            // creating arrays
            int[] a = new int[5] { 10, 20, 30, 40, 50 };
            string[] b = new string[5] { "one", "two", "three", "four", "five" };

            // accessing array elements
            Console.WriteLine(a[4]);
            Console.WriteLine(b[0]);

            // array with for loop
            for (int i = 0; i < a.Length; i++)
            {
                Console.WriteLine(a[i]);
            }

            // array with foreach loop
            foreach (int i in a)
            {
                Console.WriteLine(i);
            }
            double[] a2 = new double[6] { 10, 20, 30, 40, 50, 30 };

            //search for 30 in the array
            int n1 = Array.IndexOf(a2, 30);
            int n2 = Array.IndexOf(a2, 30, 3); // 3 is the starting index

            // binary search (array must be sorted)
            int n3 = Array.BinarySearch(a, 30);

            // clear
            Array.Clear(a2, 0, 2); // clear first two elements

            // resize
            Array.Resize(ref a2, 10); // resize to 10 elements

            // sort
            Array.Sort(a2);

            // reverse
            Array.Reverse(a2);

            // multidimensional array - all rows have same number of columns
            int[,] multi = new int[3, 4] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 } };  // [,]2d [,,]3d [,,,]4d 

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(multi[i, j] + " ");
                }
                Console.WriteLine();
            }

            // jagged array
            int[][] jagged = new int[3][];
            jagged[0] = new int[2] { 1, 2 };
            jagged[1] = new int[3] { 3, 4, 5 };
            jagged[2] = new int[4] { 6, 7, 8, 9 };

            for (int i = 0; i < jagged.Length; i++)
            {
                for (int j = 0; j < jagged[i].Length; j++)
                {
                    Console.Write(jagged[i][j] + " ");
                }
                Console.WriteLine();
            }

            // array of objects
            Employee[] employees = new Employee[]
            {
                new Employee{ EmpID=101, EmpName="Alice" },
                new Employee{ EmpID=102, EmpName="Bob"  },
                new Employee{ EmpID=103, EmpName="Charlie"  }

            };

            foreach (Employee item in employees)
            {
                if (item.EmpID >= 102)
                {
                    Console.WriteLine(item.EmpID + ", " + item.EmpName);
                }
            }

            // copy to
            Employee[] highlyPaidEmployees = new Employee[5];
            employees.CopyTo(highlyPaidEmployees, 0); // copy starting at index 1

            // clone
            Employee[] clonedEmployees = (Employee[])employees.Clone();

            // deep copy
            Employee[] deepCopiedEmployees = new Employee[employees.Length];

            for (int i = 0; i < employees.Length; i++)
            {
                deepCopiedEmployees[i] = new Employee()
                {
                    EmpID = employees[i].EmpID,
                    EmpName = employees[i].EmpName
                };
            }

            employees[0].EmpName = "Changed Name";
            Console.WriteLine(highlyPaidEmployees[0].EmpName); // Changed Name (shallow copy)
            Console.WriteLine(clonedEmployees[0].EmpName); // Changed Name (shallow copy)
            Console.WriteLine(deepCopiedEmployees[0].EmpName); // Alice (deep copy)


        }
    }
}
