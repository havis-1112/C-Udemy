using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _26_StringDateTimeMath
{
    /*
     string is an object
     properties: indexing, length
     can store up to 2 billion characters
     immutable - cannot be modified
    */

    public class Program
    {
        class Person
        {
            public string PersonName { get; set; }
            public DateTime DateOfBirth { get; set; }
        }
        class Employee
        {
            public string EmployeeName { get; set; }
            public DateTime DateOfJoining { get; set; }
            public double ExperienceYears { get; set; }
            public double ExperienceMonths { get; set; }
        }
        static void Main(string[] args)
        {
            string x = "Hello World";
            string y = "Hello World"; // same address like x to avoid memory consumption
            string z = x; // copy address
            x = "hello";
            Console.WriteLine(x); // hello
            Console.WriteLine(y); // Hello World
            Console.WriteLine(z); // Hello World

            string text = "  Hello World  ";

            Console.WriteLine(text.ToUpper());                 // HELLO WORLD
            Console.WriteLine(text.ToLower());                 // hello world
            Console.WriteLine("Harivishnu".Substring(2, 5));   // rivis
            Console.WriteLine(text.Replace("World", "C#"));    // Hello C#

            string data = "Ram,Sam,Ravi";
            string[] arr = data.Split(',');             // split by ,
            Console.WriteLine(arr[0]);                  // Ram

            Console.WriteLine(text.Trim());              // Hello World

            char[] ch = "Hi".ToCharArray();              // H i
            Console.WriteLine(ch[0]);                    // H

            Console.WriteLine(string.Join("-", arr));    // Ram-Sam-Ravi

            Console.WriteLine("Hi".Equals("Hi"));        // True
            Console.WriteLine("Hello".StartsWith("He")); // True
            Console.WriteLine("Hello".EndsWith("lo"));   // True
            Console.WriteLine("Hello".Contains("el"));   // True

            Console.WriteLine("Hello World".IndexOf("World"));     // 6
            Console.WriteLine("Hello Hello".LastIndexOf("Hello")); // 6

            Console.WriteLine(string.IsNullOrEmpty(""));     // True
            Console.WriteLine(string.IsNullOrWhiteSpace(" ")); // True

            Console.WriteLine(
                string.Format("{0} Oriented {1}", "Object", "Programming")
            ); // Object Oriented Programming

            Console.WriteLine("HelloWorld".Insert(5, " ")); // Hello World
            Console.WriteLine("HelloWorld".Remove(5, 5));   // Hello


            // for loop
            string name = "developer@example.com";
            char[] vowels = new char[] { 'A', 'E', 'I', 'O', 'U', 'a', 'e', 'i', 'o', 'u' };

            //for loop
            int vowelsCount = 0;
            for (int i = 0; i < name.Length; i++)
            {
                bool isMatch = false;
                for (int j = 0; j < vowels.Length; j++)
                    if (name[i] == vowels[j])
                        isMatch = true;

                if (isMatch)
                    vowelsCount++;

                //Console.WriteLine(name[i] + " " + isMatch);
            }
            Console.WriteLine(vowelsCount + " vowels found");
            //i = 0  name[i]  name[0]

            //Using methods of arrays / collections
            vowelsCount = 0;
            for (int i = 0; i < name.Length; i++)
            {
                if (Array.IndexOf(vowels, name[i]) >= 0)
                    vowelsCount++;
            }
            Console.WriteLine(vowelsCount + " vowels found");

            //Using LINQ
            Console.WriteLine(name.Count(ch => true)); // 22
            Console.WriteLine(name.Count(ch => Array.IndexOf(vowels, ch) >= 0) + " vowels found");

            // string builder - mutable

            //create an array of strings
            string[] words = new string[] { "The", "quick", "brown", "fox", "jumps", "over", "the", "lazy", "dog" };
            //Expected output: "The quick brown fox jumps over the lazy dog"
            string sentence = "";
            foreach (string word in words)
            {
                sentence = sentence + " " + word; //Problem: new object will be created for each iteration.
                //1st iteration: " The"
                //2nd iteration: " The quick"
                //...
            }
            //Console.WriteLine(sentence);

            //StringBuilder
            StringBuilder builder = new StringBuilder("hello ", 20);
            foreach (string word in words)
            {
                builder.Append(word);
                builder.Append(" ");
                Console.WriteLine(builder.ToString() + ", " + builder.Length + ", " + builder.Capacity);
            }
            builder[0] = 'v';
            Console.WriteLine(builder.ToString());
            Console.WriteLine(builder.MaxCapacity);

            Console.WriteLine(builder.Insert(5, "updated"));
            Console.WriteLine(builder.Remove(builder.ToString().IndexOf("q"), 5));
            Console.WriteLine(builder.Replace("a", "r"));

            // date time
            Person person1 = new Person();
            person1.PersonName = "Miller";
            person1.DateOfBirth = DateTime.Parse("2000-12-31 11:59:59.999 am");
            Console.WriteLine(person1.DateOfBirth.ToString());

            Console.WriteLine("Day " + person1.DateOfBirth.Day);
            Console.WriteLine("Month " + person1.DateOfBirth.Month);
            Console.WriteLine("Year " + person1.DateOfBirth.Year);
            Console.WriteLine("Hours " + person1.DateOfBirth.Hour);
            Console.WriteLine("Minutes " + person1.DateOfBirth.Minute);
            Console.WriteLine("Seconds " + person1.DateOfBirth.Second);
            Console.WriteLine("Milliseconds " + person1.DateOfBirth.Millisecond);
            Console.WriteLine("Day of week " + person1.DateOfBirth.DayOfWeek);
            Console.WriteLine("Day of week " + (int)person1.DateOfBirth.DayOfWeek);
            Console.WriteLine("Day of year " + person1.DateOfBirth.DayOfYear);

            DateTime dt = DateTime.Now;
            Console.WriteLine(dt.ToString());

            //DateTime dt = DateTime.Parse("2020-12-31 11:59:59.999 pm");
            //DateTime dt = DateTime.ParseExact("31/12/2020 23:59:59", "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None); //dd/MM/yyyy HH:mm:ss

            DateTime dt2 = new DateTime(2020, 12, 31, 23, 59, 59, 999);
            string str1 = dt2.ToString(); //MM/dd/yyyy hh:mm:ss tt
            string str2 = dt2.ToShortDateString(); //MM/dd/yyyy
            string str3 = dt2.ToLongDateString(); //dd MMMM yyyy
            string str4 = dt2.ToShortTimeString(); //hh:mm tt
            string str5 = dt2.ToLongTimeString(); //hh:mm:ss tt
            string str6 = dt2.ToString("dd-MM-yyyy HH:mm:ss");

            // date time subraction
            Employee emp = new Employee() { EmployeeName = "John", DateOfJoining = DateTime.Parse("2015-01-01") };
            //Today: 2021-10-11
            DateTime today = DateTime.Now;
            if (today.CompareTo(emp.DateOfJoining) == 1) //1, 0, -1
            {
                TimeSpan ts = today.Subtract(emp.DateOfJoining);
                emp.ExperienceYears = Math.Floor(ts.TotalDays / 365);
                emp.ExperienceMonths = Math.Floor((ts.TotalDays - (emp.ExperienceYears * 365)) / 30);
                Console.WriteLine(emp.ExperienceYears + " years and " + emp.ExperienceMonths + " months");
            }
            else
            {
                Console.WriteLine("Date of joining is greater than today's date. Subtraction is not possible");
            }

            // date time addition
            DateTime dt3 = DateTime.Parse("2022-01-01 12:00 am");
            DateTime dt3_after_10_days = dt.AddDays(10);
            Console.WriteLine("After 10 days: " + dt3_after_10_days);
            DateTime dt3_before_10_days = dt.AddDays(-10);
            Console.WriteLine("Before 10 days: " + dt3_before_10_days);

            DateTime dt_after_20_months_and_5_days = dt.AddMonths(20).AddDays(5);
            Console.WriteLine("After 20 months and 5 days: " + dt_after_20_months_and_5_days);

            // math
            double a = Math.Pow(10, 4); //10 power 4 (10 * 10 * 10 * 10)
            double b = Math.Min(5.623, 10.82); //smaller among given numbers
            double c = Math.Max(5.623, 10.82); //bigger among given numbers
            double d = Math.Floor(20.83984); //returns the integer part
            double e = Math.Ceiling(20.23984); //returns the next integer
            double f = Math.Round(20.23984); //round down
            double g = Math.Round(20.53984); //round up
            double h = Math.Round(20.53984, 2); //round up

            Console.WriteLine(a); //Output: 10000
            Console.WriteLine(b); //Output: 5.623
            Console.WriteLine(c); //Output: 10.82
            Console.WriteLine(d); //Output: 20
            Console.WriteLine(e); //Output: 21
            Console.WriteLine(f); //Output: 20
            Console.WriteLine(g); //Output: 21
            Console.WriteLine(h); //Output: 20.54

            double a = Math.Pow(10, 4); //10 power 4 (10 * 10 * 10 * 10)
            double b = Math.Min(5.623, 10.82); //smaller among given numbers
            double c = Math.Max(5.623, 10.82); //bigger among given numbers
            double d = Math.Floor(20.83984); //returns the integer part
            double e = Math.Ceiling(20.23984); //returns the next integer
            double f = Math.Round(20.23984); //round down
            double g = Math.Round(20.53984); //round up
            double h = Math.Round(20.53984, 2); //round up
            double i = Math.Sign(-10); //-1 if negative value
            double j = Math.Abs(-10); //returns positive number based on given negative number
            //10 / 3 = Quotient: 3; remainder: 1
            int rem;
            double quo = Math.DivRem(10, 3, out rem);
            double k = Math.Sqrt(25);

            Console.WriteLine(a); //Output: 10000
            Console.WriteLine(b); //Output: 5.623
            Console.WriteLine(c); //Output: 10.82
            Console.WriteLine(d); //Output: 20
            Console.WriteLine(e); //Output: 21
            Console.WriteLine(f); //Output: 20
            Console.WriteLine(g); //Output: 21
            Console.WriteLine(h); //Output: 20.54
            Console.WriteLine(i); //Output: -1
            Console.WriteLine(j); //Output: 10
            Console.WriteLine("Quotient: " + quo + ", Remainder: " + rem); //3 and 1
            Console.WriteLine(Math.Floor(Convert.ToDouble(10) / 3)); //3
            Console.WriteLine(10 % 3); //1
            Console.WriteLine(k); //5


            // regex
            Regex regex = new Regex("^[A-Za-z ]*$");
            Console.WriteLine("Enter a name: ");
            string inputValue = Console.ReadLine();
            bool result = regex.IsMatch(inputValue);
            Console.WriteLine(result);
            if (result == true)
            {
                Console.WriteLine("Valid name");
            }
            else
            {
                Console.WriteLine("Invalid name");
            }

            /*
             
             [0-9]
             [a-z]
             [A-Z]
             [1,2,3]
            \d - digits 0 to 9
            \w -  word
            \s - space

             */

        }
    }
}
