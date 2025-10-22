// Main Programmer: Ken Arigo

using System;


namespace FishingGame
{
    public static class FishingActions
    {
        public static void GoFish()
        {

            // Fish Line going down
            for (int lineDepth = 0; lineDepth < FishingWindow.waterMatrix.GetLength(1); lineDepth++)
            {
                if (FishingWindow.waterMatrix[lineDepth, Player.Position].HasFish)
                {
                    // Logic
                    Fish fishOnLine = (Fish)FishingWindow.waterMatrix[lineDepth, Player.Position];
                    if (FishOnTheLine(fishOnLine))
                    {
                        // Fish caught, therefore fish no longer on map
                        FishingWindow.waterMatrix[lineDepth, Player.Position] = new Cell();
                    }
                    break;
                }
            }
            // Replace this with logic that clears just that spot on the display
            Console.Clear();
            FishingWindow.Display();
            Console.SetCursorPosition(0, 12);

        }
        private static bool FishOnTheLine(Fish fish)
        {
            void ContinueWithSpace()
            {
                bool foundSpace = false;
                while (!foundSpace)
                {
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.Spacebar:
                            foundSpace = true;
                            break;
                    }
                }
            }
            Console.WriteLine("A fish is on the line! Press Space to reel it in!");
            ContinueWithSpace();
            Random random = new Random();
            int catchChance = random.Next(1, 5);
            if (catchChance > Player.CatchRate)
            {
                Console.WriteLine("You caught a fish!");
                Fish newFish = new Fish();
                newFish.DisplayStats();
                Player.AddFish(newFish);
                Console.WriteLine("Press Space to Continue");
                ContinueWithSpace();
                return true;
            }else
            {
                Console.WriteLine("The fish got away!");
                Console.ReadKey();
                return false;
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
