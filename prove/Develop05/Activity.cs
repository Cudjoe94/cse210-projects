using System;
using System.Threading;

public abstract class Activity
{
    // Shared attributes
    protected string _name;
    protected string _description;
    protected int _duration;

    // Constructor
    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    // Standard starting message
    public void DisplayStartingMessage()
    {
        Console.WriteLine($"\nWelcome to the {_name}.");
        Console.WriteLine(_description);
        Console.Write("Enter the duration of the activity in seconds: ");
        _duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Prepare to begin...");
        ShowSpinner(3);
    }

    // Standard ending message
    public void DisplayEndingMessage()
    {
        Console.WriteLine("\nGreat job! You have completed the activity.");
        Console.WriteLine($"You completed the {_name} for {_duration} seconds.");
        ShowSpinner(3);
    }

    // Spinner animation
    protected void ShowSpinner(int seconds)
    {
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        while (DateTime.Now < endTime)
        {
            Console.Write("-\b");
            Thread.Sleep(200);
            Console.Write("\\\b");
            Thread.Sleep(200);
            Console.Write("|\b");
            Thread.Sleep(200);
            Console.Write("/\b");
            Thread.Sleep(200);
        }
        Console.Write(" \b"); // Clear spinner
    }

    // Countdown animation
    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"{i}...\b\b\b");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }

    // Abstract method for Run
    public abstract void Run();
}
