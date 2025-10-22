// Main Programmer: Ken Arigo

using System;


namespace FishingGame
{
    public static class FishingActions
    {
        public static void GoFish()
        {
            Random random = new Random();
            int catchChance = random.Next(1, 5);
            if (catchChance > Player.CatchRate)
            {
                Console.WriteLine("You caught a fish!");
                Fish newFish = new Fish();
                newFish.DisplayStats();
                Player.AddFish(newFish);
                Console.WriteLine("Press Enter to Continue");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("You casted your line and no fish bit :(");
                Console.WriteLine("Press Enter to Continue");
                Console.ReadLine();
            }

            // Fish Line going down
            for (int lineDepth = 0; lineDepth < FishingWindow.waterMatrix.Length; lineDepth++)
            {
                if (FishingWindow.waterMatrix[Player.Position, lineDepth].HasFish)
                {
                    // Logic
                    //FishOnTheLine(FishingWindow.waterMatrix[Player.Position, lineDepth]);
                    break;
                }
            }
        }
        private static void FishOnTheLine(Fish fish)
        {
            Console.WriteLine("A fish is on the line! Press Enter to reel it in!");
            Console.ReadLine();
            Random random = new Random();
            int catchChance = random.Next(1, 5);
            if (catchChance > Player.CatchRate)
            {
                Console.WriteLine("You caught a fish!");
                Fish newFish = new Fish();
                newFish.DisplayStats();
                Player.AddFish(newFish);
                Console.WriteLine("Press Enter to Continue");
                Console.ReadLine();
            }else
            {
                Console.WriteLine("The fish got away!");
                Console.ReadKey();
            }
        }
        public static void SellFish(int index)
        {
            if (Player.inventory[index] != null)
            {
                int fishValue = Player.inventory[index].Weight / 5; // A random estimate for how much each fish is worth
                Player.Money += fishValue;
                Console.WriteLine("You sold a {0} for ${1}!",Player.inventory[index].Species,fishValue);
                Player.InventoryRemoveAtIndex(index);
                Console.WriteLine("Press Enter to Continue");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("There's no fish at that index!");
                Console.WriteLine("Press Enter to Continue");
                Console.ReadLine();
            }
        }

        public static void BuyStuff()// WIP
        {
            Console.WriteLine("Stuff to buy");
            Console.WriteLine("====================");
        }

    }
}
