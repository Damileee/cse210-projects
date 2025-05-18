using System;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry) => _entries.Add(entry);

    public void DisplayAll()
    {
        foreach (var entry in _entries)
            entry.Display();
    }

    public void SaveToFile(string filename)
    {
        File.WriteAllLines(filename, _entries.Select(e => e.ToFileString()));
    }

    public void LoadFromFile(string filename)
    {
        if (File.Exists(filename))
        {
            _entries = File.ReadAllLines(filename)
                           .Select(line => Entry.FromFileString(line)).ToList();
        }
        else Console.WriteLine("File not found.");
    }
}