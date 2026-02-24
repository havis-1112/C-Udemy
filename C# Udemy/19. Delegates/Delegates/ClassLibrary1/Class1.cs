using System;

namespace ClassLibrary1
{
    public class Sample
    {
        // Single-cast delegate method (expression-bodied)
        public int Add(int a, int b) => a + b;

        // Multi-cast delegate methods
        public void Subract(double a, double b) => Console.WriteLine("Subtraction is: " + (a - b));
        public void Multiply(double a, double b) => Console.WriteLine("Multiplication is: " + (a * b));
    }
}
