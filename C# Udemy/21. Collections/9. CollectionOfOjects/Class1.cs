using Product;

namespace CollectionOfOjects
{
    public class Class1
    {
        static void Main()
        {
                List<SingleProduct> products = new List<SingleProduct>();
                string choice;
                do
                {
                    Console.WriteLine("Enter the id");
                    int id = int.Parse(Console.ReadLine());

                    Console.WriteLine("Enter the name");
                    string name = Console.ReadLine();

                    SingleProduct product = new SingleProduct{Id=id,Name=name};

                     products.Add(product);

                    Console.WriteLine("Enter choice");
                    choice = Console.ReadLine();
                }
                while (choice != "N");
        }
        

    }
}
