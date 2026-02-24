
namespace Tuples
{
    // tuples - when method has multiple return types and also can be used as parameter where anonymous type cannot be used,immutable
    class Sample
    {
        public Tuple<string, int> GetPersonDetails()
        {
            //create a new Tuple that stores person name and age
            Tuple<string, int> tuple = new Tuple<string, int>("Scott", 20);

            return tuple;
        }
    }
    class Customer
    {
        public (int customerID, string customerName, string email) GetCustomerDetails()
        {
            return (101, "Scott", "scott@gmail.com");
        }
    }
    class Program
    {

        static void Main()
        {
            Sample s = new Sample();
            Tuple<string, int> person = s.GetPersonDetails();

            //access values from tuple
            Console.WriteLine(person.Item1); //Scott
            Console.WriteLine(person.Item2); //20

            // value tuples - muttable , stored in stack/inline(faster) , can access through property names
            Customer customer = new Customer();

            (int customerID, string customerName, string email) cust = customer.GetCustomerDetails();

            Console.WriteLine(cust.customerID);
            Console.WriteLine(cust.customerName);
            Console.WriteLine(cust.email);

            // deconstruction - assign value to individual local variable
            (int customerID, string customerName, string email)  = customer.GetCustomerDetails();

            Console.WriteLine(customerID);
            Console.WriteLine(customerName);
            Console.WriteLine(email);

            // discards
            (int customerID1,_, string email1) = customer.GetCustomerDetails();

        }
    }
}
}
