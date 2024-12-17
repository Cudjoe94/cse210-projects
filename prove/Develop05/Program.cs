using System;

class Program
{
    // Exceeding Core Requirements Report:
    // 1. Reusable Spinner and Countdown Animations:
    //    The spinner and countdown are implemented as reusable methods in the base class `Activity`. These methods help improve the user experience with smooth and engaging animations during pauses.
    //
    // 2. Randomized Prompts and Questions:
    //    The `ListingActivity` and `ReflectingActivity` classes randomly select prompts and reflection questions. This ensures variety in each activity, making it more engaging and personalized for each session.
    //
    // 3. Polished User Input Flow:
    //    The program gracefully handles user input by prompting for activity duration and providing consistent and clear transition messages between steps, making the experience smoother and user-friendly.
    //
    // 4. Duration Flexibility:
    //    Users can input a custom duration for each activity, which allows the program to be flexible to different time constraints, whether the user wants a quick 5-minute activity or a longer session.
    //
    // 5. Encapsulation and Abstraction:
    //    The base class `Activity` encapsulates all common attributes (name, description, duration) and behaviors (starting and ending messages, animations), ensuring good object-oriented design and avoiding unnecessary repetition.
    //
    // 6. Extendable Design:
    //    The program's design is extendable, allowing easy addition of new activities in the future by simply inheriting from the base class and overriding necessary methods.
    //
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program\n");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Listing Activity");
            Console.WriteLine("3. Reflecting Activity");
            Console.WriteLine("4. Quit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    new BreathingActivity().Run();
                    break;
                case "2":
                    new ListingActivity().Run();
                    break;
                case "3":
                    new ReflectingActivity().Run();
                    break;
                case "4":
                    Console.WriteLine("Thank you for using the program. Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
    }
}
