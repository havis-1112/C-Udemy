using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("without yield:");
        foreach (int n in EvenNumbers_WithoutYield())
        {
            Console.WriteLine(n);
        }

        Console.WriteLine("with yield:");
        foreach (int n in EvenNumbers_WithYield())
        {
            Console.WriteLine(n);
        }
    }

    // ----------------------------------------------------
    // WITHOUT yield (NORMAL METHOD)
    // ----------------------------------------------------
    static IEnumerable<int> EvenNumbers_WithoutYield()
    {
        // A list is created to store ALL even numbers
        List<int> numbers = new List<int>();

        // Loop runs COMPLETELY from 1 to 10
        for (int i = 1; i <= 10; i++)
        {
            // Check for even number
            if (i % 2 == 0)
            {
                // Add even number to the list
                // Values are STORED in memory
                numbers.Add(i);
            }
        }

        // After the loop finishes,
        // the ENTIRE collection is returned at once
        return numbers;

        /*
         MEMORY:
         [2, 4, 6, 8, 10]

         EXECUTION:
         - Method runs fully
         - Then foreach starts
         - More memory used
        */
    }

    // ----------------------------------------------------
    // WITH yield (ITERATOR METHOD)
    // ----------------------------------------------------
    static IEnumerable<int> EvenNumbers_WithYield()
    {
        // Loop does NOT run fully at once
        for (int i = 1; i <= 10; i++)
        {
            // Check for even number
            if (i % 2 == 0)
            {
                // yield return sends ONE value
                // and PAUSES the method here
                yield return i;

                // Next value is produced ONLY
                // when foreach asks again
            }
        }

        /*
         MEMORY:
         2 → pause
         4 → pause
         6 → pause
         8 → pause
         10 → pause

         EXECUTION:
         - No list created
         - Values produced one-by-one
         - Less memory (lazy execution)
        */
    }
}
