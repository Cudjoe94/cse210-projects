using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureMemorizer
{
    public class Scripture
    {
        private Reference _reference;
        private List<Word> _words;

        public Scripture(Reference reference, string text)
        {
            _reference = reference;
            _words = text.Split(' ').Select(word => new Word(word)).ToList();
        }

        public bool IsCompletelyHidden
        {
            get { return _words.All(word => word.IsHidden()); }
        }

        public void HideRandomWords()
        {
            Random rand = new Random();
            int wordsToHide = rand.Next(1, 4);

            for (int i = 0; i < wordsToHide; i++)
            {
                var visibleWords = _words.Where(word => !word.IsHidden()).ToList();
                if (visibleWords.Count == 0) break;

                var wordToHide = visibleWords[rand.Next(visibleWords.Count)];
                wordToHide.Hide();
            }
        }

        public string GetDisplayText()
        {
            string scriptureText = string.Join(" ", _words.Select(word => word.GetDisplayText()));
            return $"{_reference.GetDisplayText()}\n\n{scriptureText}";
        }
    }
}

