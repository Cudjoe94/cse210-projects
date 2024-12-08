using System;

public class JournalEntry
{
    public string Date { get; private set; }
    public string Content { get; private set; }

    public JournalEntry(string content)
    {
        Date = DateTime.Now.ToShortDateString();
        Content = content;
    }

    public override string ToString()
    {
        return $"{Date}|{Content}";
    }

    public static JournalEntry FromString(string data)
    {
        var parts = data.Split('|');
        return new JournalEntry(parts[1]) { Date = parts[0] };
    }
}

