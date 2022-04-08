using System;

namespace _07_speed
{
    public class Director
    {
        private bool _keepPlaying = true;
        private char _inputLetter;
        private int _timer = 0;

        OutputService _outputService = new OutputService();
        InputService _inputService = new InputService();

        ScoreBoard _scoreboard = new ScoreBoard();
        Buffer _buffer = new Buffer();
        WordList _wordList = new WordList();

        public void StartGame()
        {
            PrepareGame();
            while (_keepPlaying)
            {
                GetInputs();
                DoUpdates();
                DoOutputs();

                if (_inputService.IsWindowClosing())
                {
                    _keepPlaying = false;
                }
            }
        }

        private void PrepareGame()
        {
            _outputService.OpenWindow(Constants.MAX_X, Constants.MAX_Y, "Speed Game", Constants.FRAME_RATE);

        }

        private void GetInputs()
        {
            _inputLetter = _inputService.GetChar();
        }

        private void DoUpdates()
        {
            if (_wordList.NewWordMaybe())
            {
                _wordList.GenerateWord();
            }

            _buffer.AmmendString(_inputLetter);
            // _buffer.SetUserInput(userInput);
            _buffer.UpdateBuffer();
            foreach (Word word in _wordList.GetWords())
            {
                word.MoveNext();
            }
            // Maybe get actual time instead
            _timer = (_timer + 1) % 30;

            _wordList.RemoveWords(_buffer, _scoreboard);

            // WordList.CreateRemovalList(_buffer.GetUserInput(), _scoreboard));

            // WordList.RemoveFromWordList();
        }

        private void DoOutputs()
        {
            _outputService.StartDrawing();

            _outputService.DrawActors(_wordList.GetWords());
            _outputService.DrawActor(_buffer);
            _outputService.DrawActor(_scoreboard);

            _outputService.EndDrawing();

            // Console.WriteLine(_wordList.GetWords());
        }

    }
}
