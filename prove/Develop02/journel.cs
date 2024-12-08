using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<JournalEntry> _entries = new List<JournalEntry>();
    private string _fileName = "journal.txt";

    public void AddEntry(JournalEntry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayEntries()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries in the journal.");
            return;
        }

        foreach (var entry in _entries)
        {
            Console.WriteLine($"Date: {entry.Date}");
            Console.WriteLine($"Content: {entry.Content}");
            Console.WriteLine(new string('-', 40));
        }
    }

    public void SaveToFile()
    {
        using (StreamWriter writer = new StreamWriter(_fileName))
        {
            foreach (var entry in _entries)
            {
                writer.WriteLine(entry.ToString());
            }
        }
        Console.WriteLine("Journal saved successfully.");
    }

    public void LoadFromFile()
    {
        if (!File.Exists(_fileName))
        {
            Console.WriteLine("No journal file found to load.");
            return;
        }

        _entries.Clear();
        var lines = File.ReadAllLines(_fileName);
        foreach (var line in lines)
        {
            _entries.Add(JournalEntry.FromString(line));
        }
        Console.WriteLine("Journal loaded successfully.");
    }
}

