using System;
using System.Collections.Generic;

namespace IComparerExample
{
    class Employee
    {
        public int EmpID { get; set; }
        public string EmpName { get; set; }
        public string Job { get; set; }
    }

    public enum SortBy
    {
        EmpID, EmpName, Job
    }

    class CustomComparer : IComparer<Employee>
    {
        
        public int Compare(Employee x, Employee y)
        {
            return x.EmpID - y.EmpID;
        }

        //Sort by EmpName
        //public int Compare(Employee x, Employee y)
        //{
        //    return x.EmpName.CompareTo(y.EmpName);
        //}

        
           }
    class Program
    {
        static void Main()
        {
            //collection of objects
            List<Employee> employees = new List<Employee>()
            {
                new Employee() { EmpID = 104, EmpName = "Mary", Job = "Designer"},
                new Employee() { EmpID = 102, EmpName = "Alexa", Job = "Manager"},
                new Employee() { EmpID = 101, EmpName = "Steven", Job = "Consultant"},
                new Employee() { EmpID = 103, EmpName = "Jade", Job = "Manager"},
                new Employee() { EmpID = 105, EmpName = "Sara", Job = null}
            };

            CustomComparer customComparer = new CustomComparer();
            employees.Sort(customComparer); //EmpName
            //employees.Reverse();

            foreach (Employee emp in employees)
            {
                Console.WriteLine(emp.EmpID + ", " + emp.EmpName + ", " + emp.Job);
            }
            Console.ReadKey();
        }
    }
}