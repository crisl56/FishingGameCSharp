// See https://aka.ms/new-console-template for more information

namespace FishingGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FishingWindow.Display();
            Console.SetCursorPosition(0, 12);
            FishingWindow.LiveGame();
            //Player.Position = 3;
            //Console.WriteLine(Player.Position);
            //Console.WriteLine(Player.PositionRaw);
        }

    }

}