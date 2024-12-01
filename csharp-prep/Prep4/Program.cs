using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create a list to store the numbers
        List<int> numbers = new List<int>();
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        // Prompt the user for input until they enter 0
        int input;
        do
        {
            Console.Write("Enter number: ");
            input = int.Parse(Console.ReadLine());
            if (input != 0)
            {
                numbers.Add(input);
            }
        } while (input != 0);

        // Compute the sum of the numbers
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }

        // Compute the average of the numbers
        double average = (numbers.Count > 0) ? (double)sum / numbers.Count : 0;

        // Find the maximum number in the list
        int max = (numbers.Count > 0) ? numbers[0] : 0;
        foreach (int number in numbers)
        {
            if (number > max)
            {
                max = number;
            }
        }

        // Display the results
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {max}");
    }
}

