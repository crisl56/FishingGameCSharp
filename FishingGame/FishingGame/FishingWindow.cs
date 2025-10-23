using System;
using System.ComponentModel;

namespace FishingGame
{
    public class FishingWindow
    {
        const int MaxFish = 10;
        // ~^~_~^~
        //   <*(((><
        public static Cell[,] waterMatrix = new Cell[10, 10] {
            {new Water(), new Water(), new Water(), new Water(), new Water(), new Water(), new Water(), new Water(), new Water(), new Water() },
            {new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell() },
            {new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new GoldFish(), new Cell(), new Cell(), new Cell() },
            {new Cell(), new Cell(), new Tuna(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell() },
            {new Cell(), new Cell(), new Cell(), new Cell(), new Salmon(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell() },
            {new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell() },
            {new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell() },
            {new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Tuna(), new Cell() },
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
            Console.SetCursorPosition(1 + Player.PositionRaw, 1);
            Console.Write(" _n_   Clyde W. Watson\r\n");
            Console.SetCursorPosition(1 + Player.PositionRaw, 2);
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

        public static void LiveGame()
        {
            while (true)
            {
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.A:
                        Player.Position -= 1;

                        break;
                    case ConsoleKey.D:
                        Player.Position += 1;
                        break;
                    case ConsoleKey.Spacebar:
                        FishingActions.GoFish();
                        break;
                    case ConsoleKey.Escape:
                        Console.Clear();
                        return;
                    case ConsoleKey.E:
                        Player.ShowInventory();
                        Console.WriteLine("Press anything to close your inventory");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.Q:
                        Shop.OpenMenu();
                        Shop.running = true;
                        break;
                }
                BoatAsset();
                Console.SetCursorPosition(0, Console.CursorTop);
                UpdateFishesAndDisplay();
                Console.SetCursorPosition(0, 12);
            }
        }
        public static void UpdateFishesAndDisplay()
        {
            FishMovement();
            if (CountFish() < MaxFish) FishSpawning();
            Console.Clear();
            FishingWindow.Display();
        }

        public static void FishMovement() // By Ken
        {
            Random random = new Random();
            // Loop through matrix using i and j as indices
            for (int i = 0; i < waterMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < waterMatrix.GetLength(1); j++)
                {
                    // if the current cell has a fish, execut fish movement logic
                    if (waterMatrix[i,j].HasFish)
                    {
                        Fish fish = (Fish)waterMatrix[i,j]; // Copy the fish in the cell 

                        int directionToMove = random.Next(4);
                        switch (directionToMove)
                        {
                            case 0:
                                if (j - 1 >= 0) // within bounds
                                {// Move Fish Left
                                    if (!waterMatrix[i, j - 1].HasFish)
                                    {// If cell to the left is occupied, do nothing
                                        // Clear the original cell and paste the copied fish into the cell to the left of it
                                        waterMatrix[i, j] = new Cell();
                                        waterMatrix[i, j - 1] = fish;
                                    }
                                }
                                else
                                {// Means Fish exited the boundaries
                                    waterMatrix[i, j] = new Cell();
                                }
                                break;
                            case 1:
                                if (j + 1 < waterMatrix.GetLength(1))
                                {// Move Fish Right
                                    // Clear the original cell and paste the copied fish into the cell to the right of it
                                    if (!waterMatrix[i, j + 1].HasFish)
                                    {
                                        waterMatrix[i, j] = new Cell();
                                        waterMatrix[i, j + 1] = fish;
                                    }
                                }
                                else
                                {// Fish exited boundaries
                                    waterMatrix[i, j] = new Cell();
                                }
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }
        public static void FishSpawning() // By Ken
        {
            Random random = new Random();
            int spawnRate = random.Next(10);
            int fishToSpawn = 0;
            if (spawnRate > 5)
            {
                switch (spawnRate)
                {
                    case 6:
                        fishToSpawn = 1;
                        break;
                    case 7:
                        fishToSpawn = 2;
                        break;
                    case 8:
                        fishToSpawn = 3;
                        break;
                    case 9:
                        fishToSpawn = 4;
                        break;
                }
            }

            void SpawnFish(Fish fish) // By Ken
            {// Only needed in this function therefore created in the scope of FishSpawning
                // Will find a space unnocupied by another fish to spawn in
                while (true)
                {
                    int row = random.Next(9)+1; // Avoids the first row (water cells)
                    int col = random.Next(10);
                    if (!waterMatrix[row, col].HasFish)
                    {
                        waterMatrix[row, col] = fish;
                        return;
                    }
                }
            }
            // Spawn fishes according to fishToSpawn
            for (int i = 0; i < fishToSpawn; i++)
            {
                int randomFishSpecies = random.Next(4);
                switch (randomFishSpecies)
                {
                    case 0:// New Tuna
                        SpawnFish(new Tuna());
                        break;
                    case 1:
                        SpawnFish(new ClownFish());
                        break;
                    case 2:
                        SpawnFish(new GoldFish());
                        break;
                    case 3:
                        SpawnFish(new Salmon());
                        break;
                }
            }
        }
        public static int CountFish() // By Ken
        {
            int count = 0;
            for (int i = 0; i < waterMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < waterMatrix.GetLength(1); j++)
                { 
                    if (waterMatrix[j,i].HasFish)
                    {
                        count++;
                    }
                }
            }
            return count;
        }
    }
}
