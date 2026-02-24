namespace Methods
{
    public class Methods
    {
        /*
         
         accessmodifer modifier returntype methodname(parameter)
         
         */


        // 1. encapsulation -> data (private/public fields) + operations (private/public methods)

        private int _age;

        public int age
        {
            get { return _age; }
            set { _age = value; }
        }

        // 2. local variables and parameters -> both are stored in stack
        // 3. this keywords represents current object

        /*
         
        4. static methods - via class name
           
           instance - instance + static fields
           static - static fields
           
           this keyword - only instance methods
            
         
         */

        // 5. reference variable as arguments
        class Person
        {
            public string FriendName = "havis";

        // 7. named arguments    
            public void PrintDetails(int age,string name)
            {
                Console.WriteLine(age + " " + name);
            }
        }

        class Program()
        {
            static void ChangeName(Person person)
            {
                {
                    person.FriendName = "dila";
                }

                Person p = new Person();
                ChangeName(p);

                Console.WriteLine(p.FriendName);

                // named arguments
                p.PrintDetails(40, "Surya");
                p.PrintDetails(name: "Manda", age: 40);

            }
        }

        // 6. default arguments - if no arguments is passed default is set, value type - 0(byte,short,int...),bool(false), ref type - null
        // 7. method overloading - same methods,different parameters
        // 8. recursion - method call within itself until condition is met
    
        
    }

}
