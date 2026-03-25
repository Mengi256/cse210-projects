using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ')
                     .Select(w => new Word(w))
                     .ToList();
    }

    public void HideRandomWords(int count)
    {
        var visibleWords = _words.Where(w => w.IsShown()).ToList();
        if (visibleWords.Count == 0) return;

        Random random = new Random();
        int toHide = Math.Min(count, visibleWords.Count);

        for (int i = 0; i < toHide; i++)
        {
            int index = random.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(w => !w.IsShown());
    }

    public string GetDisplayText()
    {
        string wordsDisplay = string.Join(" ", _words.Select(w => w.GetDisplayText()));
        return $"{_reference.GetDisplayText()} {wordsDisplay}";
    }
}