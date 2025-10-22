// See https://aka.ms/new-console-template for more information

namespace FishingGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Fish fish = new Fish();
            Fish fish2 = new Fish();
            Fish fish3 = new Fish();
            Player.AddFish(fish);
            Player.AddFish(fish2);
            Player.AddFish(fish3);
            Shop.OpenMenu();
           // FishingWindow.Display();
            //Console.SetCursorPosition(0, 12);
            //FishingWindow.BoatMovement();
            //Player.Position = 3;
            //Console.WriteLine(Player.Position);
            //Console.WriteLine(Player.PositionRaw);
        }

    }

}