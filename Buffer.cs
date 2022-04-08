using System;

namespace _07_speed
{
    public class Buffer : Actor
    {
        private string _userInput = "";

        /// <summary>
        /// Constructor for the Buffer class.
        /// </summary>
        public Buffer()
        {
            _position = new Point(0, Constants.MAX_Y - 25);
            UpdateBuffer();
        }
        /// <summary>
        /// Used to get the user's input.
        /// </summary>
        /// <returns string="_userInput"></returns>
        public string GetUserInput()
        {
            return _userInput;
        }

        /// <summary>
        /// Sets the actual user's input into a class variable.
        /// </summary>
        /// <param name="userInput"></param>
        public void SetUserInput(string userInput)
        {
            _userInput = userInput.ToLower();
        }

        /// <param name="keyPress"></param>
        /// <returns string="inputThree"></returns>
        public void AmmendString(char keyPress)
        {
            // string result = "";
            // Console.WriteLine(keyPress);

            // _userInput = _userInput + keyPress;

            if (keyPress != '\0')
            {
                //_text = _text + keyPress.ToString().ToLower();
                // string _inputTwo = _userInput + keyPress;
                _userInput = _userInput + keyPress;
                // Console.WriteLine(keyPress);
            }
            if (keyPress == 'ă' && _userInput != "ă")
            {
                _userInput = _userInput.Remove(_userInput.Length - 2, 2);
                //Console.WriteLine("AHHHHH");
            }
            // return result;
        }

        /// <summary>
        /// Updates the buffer text to add the new user input
        /// </summary>
        public void UpdateBuffer()
        {
            //Console.WriteLine(_userInput.GetType());
            _text = "Buffer: " + _userInput.ToLower();
        }

        public void ClearBuffer()
        {
            _userInput = "";
        }
    }
}