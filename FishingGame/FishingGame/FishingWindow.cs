using System;

namespace FishingGame
{
    public class FishingWindow
    {
        //   <*(((><
        public static string[,] waterMatrix = new string[10, 10] {
            {"~^~_~^~", "~^~_~^~", "~^~_~^~", "~^~_~^~", "~^~_~^~", "~^~_~^~", "~^~_~^~", "~^~_~^~", "~^~_~^~", "~^~_~^~", },
            {"       ", "       ", "       ", "       ", "       ", "       ", "       ", "       ", "       ", "       " },
            {"       ", "       ", "       ", "       ", "       ", "       ", "       ", "       ", "       ", "       " },
            {"       ", "       ", "       ", "       ", "       ", "       ", "       ", "       ", "       ", "       " },
            {"       ", "       ", "       ", "       ", "       ", "       ", "       ", "       ", "       ", "       " },
            {"       ", "       ", "       ", "       ", "       ", "       ", "       ", "       ", "       ", "       " },
            {"       ", "       ", "       ", "       ", "       ", "       ", "       ", "       ", "       ", "       " },
            {"       ", "       ", "       ", "       ", "       ", "       ", "       ", "       ", "       ", "       " },
            {"       ", "       ", "       ", "       ", "       ", "       ", "       ", "       ", "       ", "       " },
            {"       ", "       ", "       ", "       ", "       ", "       ", "       ", "       ", "       ", "       " },
        };

        public static void Display()
        {
            int CursorPosX = Console.CursorLeft;
            int CursorPosY = Console.CursorLeft;
            //~^~_~^~
            BoatAsset();
            WaterDisplay();
            
            Console.SetCursorPosition(CursorPosX, CursorPosY);   // Resets cursor position


        }
        public static void BoatAsset()
        {
            int CursorPosX = Console.CursorLeft;
            int CursorPosY = Console.CursorTop;
            Console.SetCursorPosition(0, 0);
            Console.WriteLine(new string(' ', Console.WindowWidth));
            Console.WriteLine(new string(' ', Console.WindowWidth));
            Console.WriteLine(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(1 + Player.Position, 1);
            Console.Write(" _n_   Clyde W. Watson\r\n");
            Console.SetCursorPosition(1 + Player.Position, 2);
            Console.Write("(---)");
            Console.SetCursorPosition(CursorPosX, CursorPosY);
        }
        public static void WaterDisplay()
        {
            int CursorPosX = Console.CursorLeft;
            int CursorPosY = Console.CursorTop;
            Console.SetCursorPosition(0, 3);
            for (int row = 0; row < 10; row++)
            {
                for (int col = 0; col < 10; col++)
                {
                    Console.Write(waterMatrix[row, col]);
                }
                Console.WriteLine();
            }
            Console.SetCursorPosition(CursorPosX, CursorPosY);
        }

        public static void BoatMovement()
        {
            while (true)
            {
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.A:
                        Player.PositionRaw -= 7;

                        break;
                    case ConsoleKey.D:
                        Player.PositionRaw += 7;
                        break;
                    case ConsoleKey.Escape:
                        return;
                }
                BoatAsset();
                Console.Write(Player.Position);
            }

        }
    }
}
