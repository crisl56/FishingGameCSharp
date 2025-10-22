using System;

namespace FishingGame
{
    public class FishingWindow
    {
        // ~^~_~^~
        //   <*(((><
        public static Cell[,] waterMatrix = new Cell[10, 10] {
            {new Water(), new Water(), new Water(), new Water(), new Water(), new Water(), new Water(), new Water(), new Water(), new Water() },
            {new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell() },
            {new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell() },
            {new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell() },
            {new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell() },
            {new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell() },
            {new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell() },
            {new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell() },
            {new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell() },
            {new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell() },

        };
        public FishingWindow()
        {

        }
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
                    waterMatrix[row, col].DisplayASCII();
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
