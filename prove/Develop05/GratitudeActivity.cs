using System;
using System.IO;
using MindfulnessApp;

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
