using System;
using System.Collections.Generic;

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
