using System.Collections.Generic;
using Raylib_cs;
using System;

namespace _07_speed
{
    public class OutputService
    {
        private Raylib_cs.Color _backgroundColor = Raylib_cs.Color.WHITE;

        public OutputService()
        {

        }

        /// <summary>
        /// Opens a new window with the specified coordinates and title.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="title"></param>
        /// <param name="frameRate"></param>
        public void OpenWindow(int width, int height, string title, int frameRate)
        {
            Raylib.InitWindow(width, height, title);
            Raylib.SetTargetFPS(frameRate);
        }

        /// <summary>
        /// Closes the window
        /// </summary>
        public void CloseWindow()
        {
            Raylib.CloseWindow();
        }

        /// <summary>
        /// Starts the drawing process. This should be called
        /// before any draw commands.
        /// </summary>
        public void StartDrawing()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(_backgroundColor);
        }

        /// <summary>
        /// This finishes the drawing process. This should be called
        /// after all draw commands are finished.
        /// </summary>
        public void EndDrawing()
        {
            Raylib.EndDrawing();
        }

        /// <summary>
        /// Displays text on the screen at the provided coordinates.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="text"></param>
        public void DrawText(int x, int y, string text)
        {
            Raylib_cs.Color color = Raylib_cs.Color.BLACK;
            // string text;
            // Console.WriteLine(text);
            // if (actor.GetPosition() == new Point(0, Constants.MAX_Y - 25))
            // {
            //     text = string.Format("Buffer: {0}", actor.GetText());
            // }
            // else
            // {
            //     text = actor.GetText();
            // }

            Raylib.DrawText(text,
                x + Constants.TEXT_OFFSET,
                y + Constants.TEXT_OFFSET,
                Constants.FONT_SIZE,
                color);
        }

        /// <summary>
        /// Draws a single actor.
        /// </summary>
        /// <param name="actor"></param>
        public void DrawActor(Actor actor)
        {
            int x = actor.GetX();
            int y = actor.GetY();

            string text = actor.GetText();

            DrawText(x, y, text);
        }

        /// <summary>
        /// Draws a list of actors.
        /// </summary>
        /// <param name="actors"></param>
        public void DrawActors(List<Word> actors)
        {
            foreach (Word actor in actors)
            {
                DrawActor(actor);
            }
        }
    }
}
