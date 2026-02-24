namespace AbstractInterafaces
{

    // abstract class and methods
    public abstract class AbstractClass
    {
        // can have fields,methods,constructor,properties - cant create objects
        public abstract void Show();  // default virtual
    }
    public class Program : AbstractClass
    {
        public override void Show()
        {
            Console.WriteLine("abstract class");
        }
    }

    // interfaces - default public and abstract
    interface IInterface
    {
        int Show();
    }
    public class Program2 : IInterface
    {
        public int Show()
        {
            return 10;
        }
    }

    // cant create object for interface but can create refernce for interface
    public class Program3
    {
        public void Display()
        {
            IInterface i = new Program2();  // access only interface methods
            i.Show();
        }
    }

    /*
     
    polymorphism
    ------------
    compile time polymorphism - method overloading
    run time polymorphism  - method overriding
      
     
     */

    // in c# multiple inheritance is possible using interfaces
    interface IFly
    {
        void Fly();
    }
    interface ISwim
    {
        void Swim();
    }

    class Duck : IFly, ISwim  // interface inheritance and multiple inheritance
    {
        public void Fly()  // in interface method must be public (multiple inheritance)
        {
            Console.WriteLine("fly");
        }

        public void Swim()
        {
            Console.WriteLine("swim");
        }
    }

    // explicit interface implementation
    interface ICar
    {
        void Ride();
    }
    interface IBike
    {
        void Ride();
    }

    class Vehicle : ICar, IBike
    {
        void ICar.Ride()  // should be private always
        {
            Console.WriteLine("car ride");
        }

        void IBike.Ride()
        {
            Console.WriteLine("bike ride");
        }


    }

}
