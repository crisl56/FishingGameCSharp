// See https://aka.ms/new-console-template for more information

namespace FishingGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string playerInp;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("==========================");
                Console.WriteLine("1. Go Fish");
                Console.WriteLine("2. Open Inventory");
                Console.WriteLine("3. Sell Fish");
                Console.WriteLine("==========================");
                Console.Write("Choose an option: ");
                playerInp = Console.ReadLine();
                switch (playerInp)
                {
                    case "1":
                        FishingActions.GoFish();
                        break;
                    case "2":
                        Player.ShowInventory();
                        Console.WriteLine("Press Enter to exit your inventory");
                        Console.ReadLine();
                        break;
                    case "3":
                        int fishToSellIndex;
                        Player.ShowInventory();
                        Console.WriteLine("Which fish would you like to sell?");
                        Console.Write("Select index of fish to sell: ");
                        if (int.TryParse(Console.ReadLine(), out fishToSellIndex))
                        {
                            FishingActions.SellFish(fishToSellIndex);
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid Input, Press enter to try again");
                        Console.ReadLine();
                        break;
                }
                
            }
        }


    }

}