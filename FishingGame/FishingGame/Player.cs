using System;

namespace FishingGame
{
    public static class Player
    {
        // Constants
        private static int maxInventorySize = 10;
        // Members
        private static int catchRate = 2;
        private static int _money = 0;
        public static Fish?[] inventory = new Fish[maxInventorySize];  // This is nullable to make empty slots
        private static int mPosition = 0;
        public static int Position
        {
            get => mPosition/7;
            set
            {
                int tempPosition = (0 + (value * (7)));
                Console.WriteLine("Value:       " + value);
                if (tempPosition > 70)
                {
                    mPosition = 70;
                }
                else if (tempPosition <= 0)
                {
                    mPosition = 0;
                }
                else
                {
                    mPosition = tempPosition;
                }
            }
        }

        public static int PositionRaw
        {
            get => mPosition;
            set => mPosition = value;
        }

        // Getters / Setters
        public static int CatchRate
        {
            get { return catchRate; }
            set
            {
                if (catchRate > 0)
                {
                    catchRate = value;
                }
            }
        }
        public static int Money
        {
            get => _money; set => _money = value;
        }

        public static void ShowInventory()
        {
            int index = 0;
            Console.WriteLine("=====================");
            foreach (Fish fish in inventory)
            {
                if (fish != null)
                {
                    Console.WriteLine("Slot {0}", index);
                    Console.WriteLine("Species: {0}", fish.Species);
                    Console.WriteLine("Size: {0}cm", fish.Size);
                    Console.WriteLine("Weight: {0}lbs",fish.Weight);
                    Console.WriteLine("====================");
                    index++;
                }
            }
        }

        public static void InventoryRemoveAtIndex(int index)
        {
            if (index >= inventory.Length)
            {
                Console.WriteLine("Index not found");
                return;
            } 
            if (inventory[index] == null)
            {
                Console.WriteLine("That space in your inventory is empty");
                return;
            }

            inventory[index] = null;
            // Fill in
            while (index < maxInventorySize && inventory[index+1] != null)
            {// Should move all fish to the 'left-most' index
                inventory[index] = inventory[index+1];
                inventory[index+1] = null;
                index++;
            }
        }

        public static void AddFish(Fish fishToAdd)
        {
            for (int i = 0; i < inventory.Length; i++)
            {
                if (inventory[i] == null)
                {
                    inventory[i] = fishToAdd;
                    return;
                }
            }
            // Will Reach if array is full
            Console.WriteLine("Your inventory is full! You release the fish into the water"); // Can add replace fish function later
            Console.WriteLine("Press Enter to Continue");
            Console.ReadLine();
        }
    }
}
