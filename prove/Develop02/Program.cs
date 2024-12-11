using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        while (true)
        {
            Console.WriteLine("Journal Menu:");
            Console.WriteLine("1. Write a New Entry");
            Console.WriteLine("2. Display All Entries");
            Console.WriteLine("3. Save Journal to File");
            Console.WriteLine("4. Load Journal from File");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Here’s your prompt:");
                    Console.WriteLine(promptGenerator.GetRandomPrompt());
                    Console.Write("Your response: ");
                    string content = Console.ReadLine();
                    Console.Write("Add tags (comma-separated): ");
                    string tagsInput = Console.ReadLine();
                    List<string> tags = new List<string>(tagsInput.Split(','));
                    journal.AddEntry(new JournalEntry(content, tags));
                    break;

                case "2":
                    journal.DisplayEntries();
                    break;

                case "3":
                    journal.SaveToFile();
                    break;

                case "4":
                    journal.LoadFromFile();
                    break;

                case "5":
                    Console.WriteLine("Goodbye!");
                    return;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}

class Journal
{
    private List<JournalEntry> entries = new List<JournalEntry>();

    public void AddEntry(JournalEntry entry)
    {
        entries.Add(entry);
        Console.WriteLine("Entry added successfully.");
    }

    public void DisplayEntries()
    {
        foreach (var entry in entries)
        {
            Console.WriteLine($"[{entry.Timestamp}] {entry.Content}");
            if (entry.Tags.Count > 0)
            {
                Console.WriteLine("Tags: " + string.Join(", ", entry.Tags));
            }
        }
    }

    public void SaveToFile()
    {
        // Implementation for saving to file (not shown here for brevity)
    }

    public void LoadFromFile()
    {
        // Implementation for loading from file (not shown here for brevity)
    }
}

class JournalEntry
{
    public string Content { get; }
    public DateTime Timestamp { get; }
    public List<string> Tags { get; }

    public JournalEntry(string content, List<string> tags)
    {
        Content = content;
        Timestamp = DateTime.Now;
        Tags = tags;
    }
}

class PromptGenerator
{
    private List<string> prompts = new List<string> { "What made you smile today?", "Describe your perfect day.", "What are you grateful for?" };

    public string GetRandomPrompt()
    {
        Random random = new Random();
        return prompts[random.Next(prompts.Count)];
    }
}

/*
Enhancements added:
1. Timestamp: Each journal entry now includes a timestamp to record when it was created.
2. Tagging System: Users can add tags to entries for categorization and easy search in the future.
*/
