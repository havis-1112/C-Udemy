using System;
using System.Collections.Generic;
using System.IO;

namespace _28._Exception__Handling
{
    internal class Program
    {
        static void Main()
        {
            /*
                Exception Hierarchy Reference:

                Object
                  └── Exception
                        ├── SystemException
                        │      ├── NullReferenceException
                        │      ├── FormatException
                        │      ├── IndexOutOfRangeException
                        │      ├── DivideByZeroException
                        │      ├── InvalidOperationException
                        │      ├── NotImplementedException
                        │      ├── NotSupportedException
                        │      └── IOException
                        │
                        └── ApplicationException
                               └── ArgumentException
                                     ├── ArgumentNullException
                                     └── ArgumentOutOfRangeException
            */

            // 1. DivideByZeroException
            try
            {
                int a = 10, b = 0;
                int c = a / b;
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("DivideByZeroException caught: " + ex.Message);
                Console.WriteLine("Stack Trace:\n" + ex.StackTrace);
            }

            // 2. FormatException
            try
            {
                string input = "abc";   // Not a number
                int number = int.Parse(input);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("FormatException caught: Invalid format! Please enter a valid number.");
                Console.WriteLine("Stack Trace:\n" + ex.StackTrace);
            }

            // 3. IndexOutOfRangeException
            try
            {
                int[] numbers1 = { 10, 20, 30 };
                Console.WriteLine(numbers1[3]);  // Error
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("IndexOutOfRangeException caught: Index is out of range!");
                Console.WriteLine("Stack Trace:\n" + ex.StackTrace);
            }

            // 4. NullReferenceException
            try
            {
                string name = null;
                Console.WriteLine(name.Length);
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("NullReferenceException caught: " + ex.Message);
                Console.WriteLine("Stack Trace:\n" + ex.StackTrace);
            }

            // 5. ArgumentNullException
            try
            {
                PrintName(null);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"ArgumentNullException caught: {ex.Message}");
                Console.WriteLine("Stack Trace:\n" + ex.StackTrace);
            }

            // 6. Inner Exception Example
            try
            {
                try
                {
                    int a = 10;
                    int b = 0;
                    int c = a / b;  // DivideByZeroException
                }
                catch (Exception ex)
                {
                    throw new Exception("Cannot divide numbers!", ex);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Outer Exception: " + ex.Message);
                Console.WriteLine("Stack Trace:\n" + ex.StackTrace);
                if (ex.InnerException != null)
                    Console.WriteLine("Inner Exception: " + ex.InnerException.Message);
            }

            // 7. ArgumentOutOfRangeException
            try
            {
                int[] numbers2 = { 10, 20, 30 };
                int index = 5;

                if (index < 0 || index >= numbers2.Length)
                    throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("ArgumentOutOfRangeException caught: " + ex.Message);
                Console.WriteLine("Stack Trace:\n" + ex.StackTrace);
            }

            // 8. ArgumentException Example
            try
            {
                SetAge(-5); // Invalid age
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"ArgumentException caught: {ex.Message}");
                Console.WriteLine("Stack Trace:\n" + ex.StackTrace);
            }

            // 9. InvalidOperationException
            try
            {
                Stack<int> stack = new Stack<int>();
                Console.WriteLine(stack.Pop()); // Stack is empty
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("InvalidOperationException caught: " + ex.Message);
                Console.WriteLine("Stack Trace:\n" + ex.StackTrace);
            }

            // 10. Custom Exception
            try
            {
                TransferFunds(100, 2000);
            }
            catch (InsufficientFundsException ex)
            {
                Console.WriteLine("Custom Exception Caught: " + ex.Message);
                Console.WriteLine("Stack Trace:\n" + ex.StackTrace);
            }

            // 11. Custom Exception with Inner Exception
            try
            {
                try
                {
                    int a = 10;
                    int b = 0;
                    int c = a / b; // DivideByZeroException
                }
                catch (DivideByZeroException ex)
                {
                    throw new InsufficientFundsException(
                        "Transfer failed due to insufficient funds!", ex);
                }
            }
            catch (InsufficientFundsException ex)
            {
                Console.WriteLine("Custom Exception Caught: " + ex.Message);
                Console.WriteLine("Stack Trace:\n" + ex.StackTrace);

                if (ex.InnerException != null)
                    Console.WriteLine("Inner Exception: " + ex.InnerException.Message);

                ExceptionLogger.AddException(ex); // Log to file
            }

            // 12. Catch When Example (Exception Filters)
            int x = 10;
            int y = 0;

            try
            {
                int c = x / y;
            }
            catch (DivideByZeroException ex) when (y == 0)
            {
                Console.WriteLine("Cannot divide by zero! y was zero.");
            }

            Console.ReadKey();
        }

        // ---------------- Helper Methods ----------------

        static void PrintName(string name)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name), "Name cannot be null");

            Console.WriteLine(name);
        }

        static void SetAge(int age)
        {
            if (age < 0 || age > 120)
                throw new ArgumentException("Age must be between 0 and 120", nameof(age));

            Console.WriteLine($"Age set to {age}");
        }

        static void TransferFunds(double balance, double amount)
        {
            if (amount > balance)
                throw new InsufficientFundsException($"Cannot transfer {amount}, only {balance} available.");

            Console.WriteLine("Transfer successful");
        }
    }

    // ---------------- Custom Exception Class ----------------
    public class InsufficientFundsException : Exception
    {
        public InsufficientFundsException() { }
        public InsufficientFundsException(string message) : base(message) { }
        public InsufficientFundsException(string message, Exception inner) : base(message, inner) { }
    }

    // ---------------- Exception Logger ----------------
    public static class ExceptionLogger
    {
        public static void AddException(Exception ex)
        {
            string filePath = @"c:\practice\ErrorLog.txt";

            using (StreamWriter writer = File.AppendText(filePath))
            {
                writer.WriteLine("\n\nException on " + DateTime.Now);
                writer.WriteLine("Exception Type: " + ex.GetType());
                writer.WriteLine("Message: " + ex.Message);
                writer.WriteLine("Stack Trace:\n" + ex.StackTrace);
            }
        }
    }
}
