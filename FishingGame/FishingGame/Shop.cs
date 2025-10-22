/*int fishToSellIndex;
Player.ShowInventory();
Console.WriteLine("Which fish would you like to sell?");
Console.Write("Select index of fish to sell: ");
if (int.TryParse(Console.ReadLine(), out fishToSellIndex))
{
    FishingActions.SellFish(fishToSellIndex);
}
break;*/




namespace FishingGame
{
    public static class Shop
    {
        public static void OpenMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Your Money: ${Player.Money}");
                Console.WriteLine("1. Sell Fish");
                Console.WriteLine("2. Buy Items");
                Console.WriteLine("0. Exit Shop");
                Console.WriteLine("================");

                Input.ReadInt(out int userChoice. 0, 2, "Chose an option: ");

                switch(userChoice)
                {
                    case 1
                        SellFishMenu();
                        break;
                    case 2:
                        BuyItemsMenu();
                        break;
                    case 0:
                        return;
                }
            }
        }

        private static void SellFishMenu()
        {
            Console.Clear();
            Console.WriteLine("===== SELL FISH =====");

            //Player.ShowInventory();
        }
    }
}