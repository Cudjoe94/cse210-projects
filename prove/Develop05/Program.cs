using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

abstract class MindfulnessActivity
{
    private string _activityName;
    private string _activityDescription;
    protected int _durationInSeconds; // Duration is shared by all derived classes

    public string ActivityName
    {
        get { return _activityName; }
        protected set { _activityName = value; }
    }

    public string ActivityDescription
    {
        get { return _activityDescription; }
        protected set { _activityDescription = value; }
    }

    public void StartActivity()
    {
        ShowStartingMessage();
        _durationInSeconds = GetDuration();
        PrepareUser();
        ExecuteActivity();
        EndActivity();
        LogSession();
    }

    protected abstract void ShowStartingMessage();
    protected abstract void ExecuteActivity();
    protected abstract void ShowEndingMessage();

    protected int GetDuration()
    {
        Console.Write("Enter the duration of the activity in seconds: ");
        return int.Parse(Console.ReadLine());
    }

    protected void PrepareUser()
    {
        Console.WriteLine("Get ready... Preparing to start...");
        Thread.Sleep(3000); // 3-second pause
    }

    protected void EndActivity()
    {
        ShowEndingMessage();
        Console.WriteLine("Great job! You've completed your activity.");
        Thread.Sleep(3000); // 3-second pause
    }

    // Pausing/Animation Feature
    protected void Countdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i + " ");
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
        Console.WriteLine();
    }

    protected void ShowSpinnerAnimation()
    {
        string[] spinner = { "/", "-", "\\", "|" };
        int i = 0;

        for (int j = 0; j < 10; j++) // Show spinner for 10 seconds
        {
            Console.Write(spinner[i]);
            Thread.Sleep(500);
            Console.Write("\b \b"); // Erase last character
            i = (i + 1) % 4;
        }
    }

    protected void LogSession()
    {
        string logFilePath = "SessionLog.txt";
        File.AppendAllText(logFilePath, $"{DateTime.Now}: Completed {ActivityName} activity for {_durationInSeconds} seconds.\n");
    }
}

class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity()
    {
        ActivityName = "Breathing";
        ActivityDescription = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
    }

    protected override void ShowStartingMessage()
    {
        Console.WriteLine($"{ActivityName}: {ActivityDescription}");
    }

    protected override void ExecuteActivity()
    {
        DateTime endTime = DateTime.Now.AddSeconds(_durationInSeconds);
        bool breathingIn = true;

        while (DateTime.Now < endTime)
        {
            if (breathingIn)
            {
                Console.WriteLine("Breathe in...");
            }
            else
            {
                Console.WriteLine("Breathe out...");
            }

            breathingIn = !breathingIn;
            Countdown(4); // 4 seconds of breathing in/out
            Thread.Sleep(1000); // Slight pause before next message
        }
    }

    protected override void ShowEndingMessage()
    {
        Console.WriteLine("You've completed your breathing session.");
    }
}

class GratitudeActivity : MindfulnessActivity
{
    public GratitudeActivity()
    {
        ActivityName = "Gratitude Journal";
        ActivityDescription = "This activity allows you to write a gratitude note and save it for reflection later.";
    }

    protected override void ShowStartingMessage()
    {
        Console.WriteLine($"{ActivityName}: {ActivityDescription}");
    }

    protected override void ExecuteActivity()
    {
        Console.WriteLine("Write a short gratitude note: ");
        string note = Console.ReadLine();

        File.AppendAllText("GratitudeLog.txt", $"{DateTime.Now}: {note}\n");
        Console.WriteLine("Your gratitude note has been saved.");
    }

    protected override void ShowEndingMessage()
    {
        Console.WriteLine("Thank you for practicing gratitude.");
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to the Enhanced Mindfulness Program!");

        while (true)
        {
            // Creativity: Menu allows access to multiple activities
            Console.WriteLine("\nSelect an activity:");
            Console.WriteLine("1. Breathing");
            Console.WriteLine("2. Reflection");
            Console.WriteLine("3. Listing");
            Console.WriteLine("4. Gratitude Journal");
            Console.WriteLine("5. View Logs");
            Console.WriteLine("6. Exit");

            string choice = Console.ReadLine();
            MindfulnessActivity activity = null;

            switch (choice)
            {
                case "1":
                    activity = new BreathingActivity();
                    break;
                case "4":
                    activity = new GratitudeActivity();
                    break;
                case "5":
                    ShowLogs();
                    continue;
                case "6":
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    continue;
            }

            activity.StartActivity();
        }
    }

    // New Feature: Log Viewer (Creativity)
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
