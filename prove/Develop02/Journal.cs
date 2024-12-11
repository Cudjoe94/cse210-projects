using System;
using System.Collections.Generic;

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
