namespace FishingGame
{
    public static class Shop
    {
        public static bool running = true;
        public static void OpenMenu()
        {
            
            while (running)
            {
                DisplayShopOptions();
                Menus();
            }

            Console.Clear();
            Console.WriteLine("You leave the shop and head back to your boat...");
            Console.ReadLine();
        }

        private static void DisplayShopOptions()
        {
            Console.Clear();
            Console.WriteLine("=== Welcome to the local Fishing Shop! ===");
            Console.WriteLine($"Your Money: ${Player.Money}");
            Console.WriteLine();
            Console.WriteLine("================");
            Console.WriteLine("1. Sell Fish");
            Console.WriteLine("2. Buy Upgrades");
            Console.WriteLine("0. Exit Shop");
            Console.WriteLine("================");
            Console.WriteLine("Choose an option: ");
        }

        private static void Menus()
        {
            int userChoice;
            Input.ReadInt(out userChoice, 0, 2);

            switch (userChoice)
            {
                case 1:
                    SellFishMenu();
                    break;
                case 2:
                    BuyItemsMenu();
                    break;
                case 0:
                    running = false;
                    break;
            }
        }

        private static void SellFishMenu()
        {
            Console.Clear();
            Console.WriteLine("===== SELL FISH =====");
            Player.ShowInventory();

            // Increase the number whhen we get an upgrade
            Console.WriteLine($"Select a slot number to sell (0 - {Player.MaxInventorySize - 1}), or -1 to cancel:");
            Input.ReadInt(out int slot, -1, Player.MaxInventorySize - 1);

            if(slot == -1)
            {
                Console.WriteLine("Canceled sale");
                Console.ReadLine();
                return;
            }

            FishingActions.SellFish(slot);
        }

        private static void BuyItemsMenu()
        {
            bool buying = true;

            while(buying)
            {
                Console.Clear();
                Console.WriteLine("=== Buy Upgrades ===");
                Console.WriteLine($"Your money: ${Player.Money}");
                Console.WriteLine("====================");
                Console.WriteLine("1. Better Rod (+1 Catch Rate) -$150");
                Console.WriteLine("2. Bigger Backpack (+5 slots) - $100");
                Console.WriteLine("3. Ulitmate Trophy - $10 000");
                Console.WriteLine("0. Return to Shop");
                Console.WriteLine("====================");
                Console.WriteLine("Choose an upgrade");

                int upgradeChoice;
                Input.ReadInt(out upgradeChoice, 0, 3);

                switch(upgradeChoice)
                {
                    case 1:
                        BuyBetterRod();
                        break;
                    case 2:
                        BuyBiggerBackpack();
                        break;
                    case 3:
                        BuyTrophy();
                        break;
                    case 0:
                        buying = false;
                        break;

                }
            }
        }

        private static void BuyBetterRod()
        {
            if(Player.Money < 150)
            {
                Console.WriteLine("You don't have enough money for a better rod!");
                Console.ReadLine();
                return;
            }

            Player.Money -= 150;
            Player.CatchRate = Player.CatchRate + 1;
            Console.WriteLine("You bought a better rod! Catch rate has been increased!");
            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
        }

        private static void BuyBiggerBackpack()
        {
            if (Player.Money < 100)
            {
                Console.WriteLine("You don't have enough money for a bigger backpack!");
                Console.ReadLine(); 
                return;
            }

            Player.Money -= 100;
            Player.UpgradeBackpack(Player.MaxInventorySize + 5);
            Console.WriteLine("You bought a bigger Backpack! Max inventory has been increased!");
            Console.WriteLine($"You can now carry {Player.MaxInventorySize} fish");
            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
        }

        private static void BuyTrophy()
        {
            if(Player.Money < 10000)
            {
                Console.WriteLine("You do not have enough money for the ultimate trophy!");
                Console.ReadLine();
                return;
            }

            Player.Money -= 10000;
            Console.WriteLine("You bought the Ulitmate Fishing Trophy! You are now the best Fisher on the lake!");
            Console.WriteLine("Whats your goal now?...");
            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();

        }
    }
}