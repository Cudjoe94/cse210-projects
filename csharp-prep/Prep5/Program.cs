using System;

class Program
{
    static void Main(string[] args)
    {
        // Call the DisplayWelcome function
        DisplayWelcome();
        
        // Get the user's name
        string userName = PromptUserName();
        
        // Get the user's favorite number
        int favoriteNumber = PromptUserNumber();
        
        // Calculate the square of the number
        int squaredNumber = SquareNumber(favoriteNumber);
        
        // Display the result
        DisplayResult(userName, squaredNumber);
    }

    // Function to display a welcome message
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    // Function to prompt the user for their name
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        return Console.ReadLine();
    }

    // Function to prompt the user for their favorite number
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        return int.Parse(Console.ReadLine());
    }

    // Function to calculate the square of a number
    static int SquareNumber(int number)
    {
        return number * number;
    }

    // Function to display the result
    static void DisplayResult(string name, int squaredNumber)
    {
        Console.WriteLine($"{name}, the square of your number is {squaredNumber}");
    }
}