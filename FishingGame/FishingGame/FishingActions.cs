using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                newFish.Stats();
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
