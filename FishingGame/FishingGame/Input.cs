using System;

namespace FishingGame
{
    public static class Input
    {
        // Changes Input variable given
        // Does not exit until input is within Range (inclusive)
        public static void ReadInt(out int Input, int Min, int Max) 
        {
            int originalCursorLeft = Console.CursorLeft;                                // saves column of cursor

            Input = 0;
            while (true)
            {
                string? inputToCheck = Console.ReadLine();

                if (int.TryParse(inputToCheck, out Input) && Input >= Min && Input <= Max)
                {
                    return;
                }

                Console.SetCursorPosition(originalCursorLeft, Console.CursorTop - 1);   //
                Console.SetCursorPosition(originalCursorLeft, Console.CursorTop - 2);   //
            }
        }

        // Changes Input variable given
        // Does not exit until input is !Null
        public static void ReadString(out string Input)
        {
            int originalCursorLeft = Console.CursorLeft;                               // Saves Column of cursor

            Input = "";
            while (true)
            {
                string? inputToCheck = Console.ReadLine();

                if (!(inputToCheck == "") || !(inputToCheck == null))
                {
                    Input = inputToCheck;
                    return;
                }

                Console.SetCursorPosition(originalCursorLeft, Console.CursorTop - 1);   // Resets cursor position
            }
        }
    }
}
