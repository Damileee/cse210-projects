using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random = new Random();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ').Select(w => new Word(w)).ToList();
    }

    public void HideRandomWords()
    {
        int wordsToHide = 3;
        var visibleWords = _words.Where(w => !w.IsHidden()).ToList();

        for (int i = 0; i < wordsToHide && visibleWords.Count > 0; i++)
        {
            int index = _random.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }
    }

    public string GetDisplayText()
    {
        return $"{_reference.GetDisplayText()}\n\n{string.Join(" ", _words.Select(w => w.GetDisplayText()))}";
    }

    public bool AllWordsHidden()
    {
        return _words.All(w => w.IsHidden());
    }
}