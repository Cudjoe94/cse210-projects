using System;
using MindfulnessApp;

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
            Console.WriteLine(breathingIn ? "Breathe in..." : "Breathe out...");
            breathingIn = !breathingIn;
            Countdown(4);
            Thread.Sleep(1000);
        }
    }

    protected override void ShowEndingMessage()
    {
        Console.WriteLine("You've completed your breathing session.");
    }
}
