namespace HandlingNull
{
    public class Program
    {
        class Person
        {
            public string Name { get; set; }
        }
        static void Main()
        {
            // value types - struct,enum       -> non nullable
            // refernce type - class,interface -> nullable

            // converting value type to nullable

            Nullable<int> a = null;
            int? b = null;

            // accessing values
            Console.WriteLine(a.Value);
            Console.WriteLine(a.HasValue);

            // null coalescing operator(??) - check value is null if yes return right side else left side
            int? c = null;
            int d = c ?? 100; // 100

            // null propagation operator(?.) - if left hand obj is not null return value else return null(no exception)
            Person p1 = null;
            Person p2 = new Person { Name = "havis" };

            Console.WriteLine(p1?.Name); // null
            Console.WriteLine(p2?.Name); // havis

        }
    }
}
