using System;
using MindfulnessApp;

class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to the Enhanced Mindfulness Program!");

        while (true)
        {
            Console.WriteLine("\nSelect an activity:");
            Console.WriteLine("1. Breathing");
            Console.WriteLine("2. Gratitude Journal");
            Console.WriteLine("3. View Logs");
            Console.WriteLine("4. Exit");

            string choice = Console.ReadLine();
            MindfulnessActivity activity = null;

            switch (choice)
            {
                case "1":
                    activity = new BreathingActivity();
                    break;
                case "2":
                    activity = new GratitudeActivity();
                    break;
                case "3":
                    ShowLogs();
                    continue;
                case "4":
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    continue;
            }

            activity.StartActivity();
        }
    }

    static void ShowLogs()
    {
        string logFilePath = "SessionLog.txt";
        string gratitudeLogFilePath = "GratitudeLog.txt";

        Console.WriteLine("\nActivity Logs:");

        if (File.Exists(logFilePath))
        {
            Console.WriteLine(File.ReadAllText(logFilePath));
        }
        else
        {
            Console.WriteLine("No activity logs available.");
        }

        Console.WriteLine("\nGratitude Logs:");
        if (File.Exists(gratitudeLogFilePath))
        {
            Console.WriteLine(File.ReadAllText(gratitudeLogFilePath));
        }
        else
        {
            Console.WriteLine("No gratitude logs available.");
        }
    }
}

/* 
Exceeding Requirements:
1. Added a log viewer feature to display both session logs and gratitude logs.
2. Implemented animations for countdown and spinner to enhance user experience.
3. Designed the program to use separate files for each class, adhering to SOLID principles.
4. Enhanced usability by allowing the user to select activities dynamically from a menu.
5. Included detailed prompts and feedback for each activity to make the interface intuitive.
6. Added graceful error handling for invalid input during duration entry.
7. Modularized the logging system for easier maintenance and future extensions.
*/
