using System;
using Raylib_cs;

namespace _07_speed
{
    public class InputService
    {
        public char GetChar()
        {
            int _numInput = Raylib.GetKeyPressed();
            char _input = Convert.ToChar(_numInput);
            return _input;
        }

        /// <summary>
        /// Returns true if the user has attempted to close the window.
        /// </summary>
        /// <returns></returns>
        public bool IsWindowClosing()
        {
            return Raylib.WindowShouldClose();
        }
    }
}
