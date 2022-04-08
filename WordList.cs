using System;
using System.Collections.Generic;


namespace _07_speed
{
    /// <summary>
    /// This class holds te word bank and creates new instances of the word class
    /// and holds a  list of those classes.
    /// </summary>
    public class WordList
    {
        private List<string> _wordBank;
        private List<Word> _words = new List<Word>();
        List<Word> _removalList = new List<Word>();

        /// <summary>
        /// This constructor initializes the _wordBank.
        /// </summary>
        public WordList()
        {
            string[] file = System.IO.File.ReadAllLines(@"wordlist.10000.txt");
            _wordBank = new List<string>(file);
            return;
        }

        /// <summary>
        /// Returns a list of words.
        /// </summary>
        /// <return List="_words"></return>
        public List<Word> GetWords()
        {
            return _words;
        }

        /// <summary>
        /// This creates new instances of the word class.
        /// </summary>
        public void GenerateWord()
        {
            Random random = new Random();
            _words.Add(new Word(_wordBank[random.Next(0, _wordBank.Count)]));
            return;
        }

        /// <summary>
        /// Creates a list of items that need to be removed and adds or subtracts
        /// points from the score baord.
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="scoreBoard"></param>
        public void CreateRemovalList(Buffer buffer, ScoreBoard scoreBoard)
        {
            // Console.WriteLine(buffer);
            foreach (Word word in _words)
            {
                string bufferText = buffer.GetUserInput().ToUpper();
                if (bufferText.Contains(word.GetText().ToUpper(), StringComparison.CurrentCultureIgnoreCase))
                {
                    _removalList.Add(word);
                    scoreBoard.AddPoints(word.GetPoints());
                    buffer.ClearBuffer();
                }
                else if (word.GetPosition().GetX() <= 0)
                {
                    _removalList.Add(word);
                    scoreBoard.MinusPoints(word.GetPoints());
                }
            }

        }

        /// <summary>
        /// Goes through the list of words that need to be removed, and removes them.
        /// </summary>
        public void RemoveFromWordList()
        {
            foreach (Word word in _removalList)
            {
                if (_words.Contains(word))
                {
                    _words.Remove(word);
                }
            }

        }

        /// <summary>
        /// Calls the functions to create a removal list and remove those items.
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="scoreBoard"></param>
        public void RemoveWords(Buffer buffer, ScoreBoard scoreBoard)
        {
            CreateRemovalList(buffer, scoreBoard);
            RemoveFromWordList();
            _removalList.Clear();
        }

        /// <summary>
        /// Helps the Director randomly decide whether or not to create a new word.
        /// </summary>
        public bool NewWordMaybe()
        {
            Random random1 = new Random();
            if (random1.Next(0, 60) == 25)
            {
                return true;
            }

            else
            {
                return false;
            }
        }

    }
}
