namespace PartialStaticEnumerations
{
    // at compile time partial class merge into single file
    partial class File1
    {
        public string Previous;
        partial void Method();  // method declaration in one class
        
    }

    public partial class File1
    {
        // always private and void , if no body provided it is removed in compile time
        partial void Method()
        {
            Console.WriteLine("hello");
        }
    }

    // static class have static members only

    // enumerations - collection of constants
    enum Color
    {
        Red,Blue,Green // default 0 to ....
    }

    enum Cars
    {
        Honda =1,Ford =2
    }
}
