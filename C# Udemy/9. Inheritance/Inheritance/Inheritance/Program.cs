namespace Inheritance
{
    public class Program
    {
        /*
         
        types of inheritance
        --------------------

        1. single inheritance
          
           class A
           class B : A

        2. multi-level inheritance
           
           class A
           class B : A
           class C : B

        3. heirarchical inheritance

           class A
           class B : A
           class C : A

        4. multiple inheritance
           
           class A
           class B
           class C : A,B

        5. hybrid inheritance (multi-level + hierarchical)
           
           class A
           class B : A
           class C : B
           class D : A

         
         */

        // creating inheritance
        public class Parent
        {
            public void Show()
            {
                Console.WriteLine("parent method");
            }
        }
        public class Child : Parent
        {
            // method hiding - new keyword hides parent class method without overriding it (compile time)
            // method call decided at compile time based on reference time

            public void Show()
            {
                Console.WriteLine("child show");
            }
            public void ParentMethod()
            {
                base.Show();
            }

        }

        public class NewClass
        {
            public void Method()
            {
                Parent p = new Parent();
                p.Show(); // parent show

                Child c = new Child();
                c.Show();  // child show

                Parent pc = new Child();
                pc.Show();  // parent show (based on ref type)
            }
        }

        /*
         
        parent class constructor
        ------------------------

        1. it is option to call parent class parameterless constructor
        2.  if parent class constructor parameterized call from child class


         */

        public class A 
        {
            int Age;
            public A(int age)
            {
                Age = age;
            }

            public virtual void Display()
            {
                Console.WriteLine("parent display");
            }
        }

        public class B : A
        {
            public B() :base(4)  // parent parameterized constructor
            {
                Console.WriteLine("child constructor");
            }

            public override void Display()  // method overriding
            {
                Console.WriteLine("child display");
            }
        }

        public class Display
        {
            public void Show()
            {
                A ab = new B();
                ab.Display();  // child display (decided at runtime)
            }
        }

        // sealed class - caant inherit this class
        // sealed methods - cant override this method

    }
}
