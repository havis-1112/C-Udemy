namespace ParameterModifiers
{
    /*
     
    default
    ref
    out
    in
    params
     
     */
    public class Class1
    {
        // 1. default (argument -> parameter)
        public void Print(string name)
        {
            Console.WriteLine(name);
        }

        // 2. ref (argument <-> parameter)
        public void PrintNum(ref int num)
        {
            num = num + 2;
        }

        // 3.out (parameter -> argument)
        public void PrintAge(out int age)
        {
            age = 50;
        }

        // 4. in(argument -> paramater but readonly)
        public void PrintHeight(in int height)
        {
            //height = 50;
        }

        // 5. ref return
        int[] nums = {1,2,3,4,5,6,7,8};

        public ref int GetIndex(int i) 
        { 
          return ref nums[i];
        }

        // 6. params
        public void ParamsMethod(params int[] param)
        {
            string Hello()   // 7. local functions , static local fucntions access ststic fields alone
            {
            return "hello";
            }
        }

    }
    public class Class2 
    {
        static void Main()
        {
            Class1 c = new Class1();

            // default
            string name = "Havis";
            c.Print(name);

            // ref
            int x = 5;
            c.PrintNum(ref x);
            Console.WriteLine(x);  // 7

            // out
            c.PrintAge(out int y);
            Console.WriteLine(y); // 50

            // in
            int z = 35;
            c.PrintHeight(z);

            // ref return
            ref int value = ref c.GetIndex(2);
            value = 22; // this changes in array also ( value is not passed ,refernce is passed)

            // params
            c.ParamsMethod(1, 2, 3, 4, 5, 6, 7);

        }
    }

}

