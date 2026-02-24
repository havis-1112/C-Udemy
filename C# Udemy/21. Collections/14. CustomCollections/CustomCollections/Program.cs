using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace csharpeg
{
    public class Program
    {
        public enum TypeOfGender
        {
            Male, Female, Other
        }

        public class Customer
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public TypeOfGender Gender { get; set; }
            public override string ToString()
            {
                return $"{Name} - {Age} - {Gender}";
            }
        }

        public class CustomerData : IEnumerable
        {
            private List<Customer> customers = new List<Customer>()
            {
             new Customer(){ Name="Havis",Age =21,Gender=TypeOfGender.Male },
             new Customer(){ Name="Surya",Age =22,Gender=TypeOfGender.Male },
             new Customer(){ Name="Dila",Age =23,Gender=TypeOfGender.Male },

            };

            /*
             
            public IEnumerator GetEnumerator()
            {   
              yield return customers[0];
              yield return customers[1];
              yield return customers[2];
                
            }

             */
            public IEnumerator GetEnumerator()
            {
                for (int i = 0; i < customers.Count; i++)
                {
                    yield return customers[i];
                }
            }

            public void AddCustomer(Customer cust)
            {
                //add validation logic here
                customers.Add(cust);
            }


        }
        static void Main(string[] args)
        {
            CustomerData customerlist = new CustomerData();

            var enumerator = customerlist.GetEnumerator();
            //enumerator.Reset(); - cant use this in yield return

            //enumerator.MoveNext();
            //Console.WriteLine(enumerator.Current);

            foreach (Customer cust in customerlist)
            {
                Console.WriteLine(cust.Name);
            }
            Console.ReadKey();


        }
    }
}