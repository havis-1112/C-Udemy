using System;
using System.Collections.Generic;

class Customer : IEquatable<Customer>
{
    public string CustomerID { get; set; }

    public bool Equals(Customer other)
    {
        return this.CustomerID == other.CustomerID;
    }
}

class Program
{
    static void Main()
    {
        List<Customer> customers = new List<Customer>();

        Customer c1 = new Customer { CustomerID = "A101" };
        customers.Add(c1);

        Customer c2 = new Customer { CustomerID = "A101" };

        Console.WriteLine(customers.Contains(c1)); 
        Console.WriteLine(customers.Contains(c2)); 
    }
}
