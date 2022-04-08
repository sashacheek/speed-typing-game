using System;

namespace _07_speed
{
    /// <summary>
    /// Base class for all actors in the game.
    /// </summary>
    public class Actor
    {
        protected Point _position;
        protected Point _velocity;

        protected string _text = "";

        public Actor()
        {

        }

        /// <summary>
        /// Gets the actor's tezt
        /// </summary>
        /// <returns string="text"></returns>
        public string GetText()
        {
            return _text;
        }

        /// <summary>
        /// Gets the actor's x coordinate
        /// </summary>
        /// <returns int="_position.GetX()"></returns>
        public int GetX()
        {
            return _position.GetX();
        }

        /// <summary>
        /// Gets the actor's y coordinate.
        /// </summary>
        /// <returns int="_position.GetY()"></returns>
        public int GetY()
        {
            return _position.GetY();
        }

        /// <summary>
        /// Gets the position of an actor..
        /// </summary>
        /// <return Point="_position"></return>
        public Point GetPosition()
        {
            return _position;
        }

        /// <summary>
        /// Returns _velocity.
        /// </summary>
        /// <returns point="_velocity"></returns>
        public Point GetVelocity()
        {
            return _velocity;
        }

        /// <summary>
        /// Sets the velocity of any new actor.
        /// </summary>
        public void SetVelocity(Point newVelocity)
        {
            _velocity = newVelocity;
        }

        /// <summary>
        /// Moves the actor forward one space according to the current
        /// velocity.
        /// </summary>
        public void MoveNext()
        {
            int x = _position.GetX();
            int y = _position.GetY();

            int dx = _velocity.GetX();
            int dy = _velocity.GetY();

            int newX = (x + dx) % Constants.MAX_X;
            int newY = (y + dy) % Constants.MAX_Y;

            //  if (newX < 0)
            //  {
            //      newX = Constants.Max_X;
            //  }

            //  if (newY < 0)
            //  {
            //      newY = Constants.MAX_Y;
            //  }

            _position = new Point(newX, newY);
        }

        /// <summary>
        /// Returns override string.
        /// </summary>
        /// <return string=""></return>
        public override string ToString()
        {
            return $"Position: ({_position.GetX()}, {_position.GetY()}), Velocity({_velocity.GetX()}, {_velocity.GetY()})";
        }

    }

}