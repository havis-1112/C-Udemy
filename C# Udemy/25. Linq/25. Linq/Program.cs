namespace _25._Linq
{
        class Employee
        {
            public int EmpID { get; set; }
            public string EmpName { get; set; }
            public string Job { get; set; }
            public string City { get; set; }
        }

        class Person
        {
            public string PersonName { get; set; }
        }

        class Programs
        {
            static void Main()
            {
                // collection of objects
                List<Employee> employees = new List<Employee>()
            {
                new Employee() { EmpID = 101, EmpName = "Henry",   Job = "Designer",  City = "Boston" },
                new Employee() { EmpID = 102, EmpName = "Jack",    Job = "Developer", City = "New York" },
                new Employee() { EmpID = 103, EmpName = "Gabriel", Job = "Analyst",   City = "Tokyo" },
                new Employee() { EmpID = 104, EmpName = "William", Job = "Manager",   City = "Tokyo" },
                new Employee() { EmpID = 105, EmpName = "Alexa",   Job = "Manager",   City = "New York" }
            };

                // where
                IEnumerable<Employee> result = employees.Where(emp => emp.City == "London");

                foreach (Employee item in result)
                {
                    Console.WriteLine(item.EmpID + ", " + item.EmpName + ", " + item.Job + ", " + item.City);
                }

                // order by
                /*
                IOrderedEnumerable<Employee> sortedEmployees =
                    employees.OrderBy(emp => emp.Job)
                             .ThenBy(emp => emp.EmpName);
                */

                IOrderedEnumerable<Employee> sortedEmployees =
                    employees.OrderByDescending(emp => emp.Job)
                             .ThenByDescending(emp => emp.EmpName);

                // filter and convert to list
                List<Employee> filteredEmployees =
                    employees.Where(emp => emp.Job == "Manager").ToList();

                Console.WriteLine(filteredEmployees[0].EmpID + ", " + filteredEmployees[0].EmpID);

                // first
                Employee firstManager =
                    employees.First(emp => emp.Job == "Manager");

                Console.WriteLine(firstManager.EmpID + ", " + firstManager.EmpName);

                // first or default
                Employee firstManager2 =
                    employees.FirstOrDefault(emp => emp.Job == "Clerk");

                // last item from filtered list
                List<Employee> filteredEmployees2 =
                    employees.Where(emp => emp.Job == "Manager").ToList();

                Console.WriteLine(
                    filteredEmployees[filteredEmployees.Count - 1].EmpID + ", " +
                    filteredEmployees[filteredEmployees.Count - 1].EmpName + ", " +
                    filteredEmployees[filteredEmployees.Count - 1].Job
                );

                // last
                Employee lastEmployee =
                    employees.Last(emp => emp.Job == "Manager");

                Console.WriteLine(lastEmployee.EmpID + ", " + lastEmployee.EmpName + ", " + lastEmployee.Job);

                // last or default
                Employee lastEmployee2 =
                    employees.LastOrDefault(emp => emp.Job == "Clerk");

                // element at
                Employee resultEmp =
                    employees.Where(emp => emp.Job == "Manager").ElementAt(1);

                Console.WriteLine(resultEmp.EmpID + ", " + resultEmp.EmpName + ", " + resultEmp.Job);

                // element at or default
                Employee resultEmp2 =
                    employees.Where(emp => emp.Job == "Manager").ElementAtOrDefault(4);

                // single
                Employee resultEmployee1 =
                    employees.Single(emp => emp.EmpID == 102);

                Console.WriteLine(resultEmployee1.EmpID + ", " + resultEmployee1.EmpName + ", " + resultEmployee1.Job);

                // single or default
                Employee resultEmployee2 =
                    employees.SingleOrDefault(emp => emp.Job == "Clerk");

                // select
                List<Person> result2 =
                    employees.Select(emp => new Person()
                    {
                        PersonName = emp.EmpName
                    }).ToList();

                // min, max, sum, average, count
                double min = employees.Min(emp => emp.EmpID);
                double max = employees.Max(emp => emp.EmpID);
                double sum = employees.Sum(emp => emp.EmpID);
                double avg = employees.Average(emp => emp.EmpID);
                double cnt = employees.Count();

                Console.ReadKey();
            }
        }
    }
