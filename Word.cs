using System;

namespace _07_speed
{
    public class Word : Actor
    {

        private string _word;
        private int _points;

        /// <summary>
        /// Constructor for the Word class
        /// </summary>
        /// <param name="word"></param>
        public Word(string word)
        {
            _word = word;
            _points = word.Length;
            _text = _word;
            _velocity = GenerateVelocity();
            _position = SetPosition();
        }

        /// <summary>
        /// Creates a random velocity for the actor when called
        /// </summary>
        /// <returns Point="velocity"></returns>
        private Point GenerateVelocity()
        {
            Random random = new Random();
            Point velocity = new Point((random.Next(1, 3) * -1), 0);
            return velocity;
        }

        /// <summary>
        /// Sets the actor's position to a random height
        /// </summary>
        /// <returns Point="position"></returns>
        private Point SetPosition()
        {
            Random random = new Random();
            Point position = new Point(550, random.Next(1, 350));
            return position;
        }

        /// <summary>
        /// Returns _word.
        /// </summary>
        /// <returns string="_word"></returns>
        public string GetWord()
        {
            return _word;
        }
        /// <summary>
        /// Returns _points.
        /// </summary>
        /// <returns int="_points"></returns>
        public int GetPoints()
        {
            return _points;
        }
    }
}
