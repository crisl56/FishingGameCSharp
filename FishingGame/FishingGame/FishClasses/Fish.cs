using System;

namespace FishingGame
{
    // Class by Cris Odonel

    public class Fish
    {
        // Variables
        protected Random random = new Random();

        // Constants
        // This is sizes in terms of cm
        protected int minSize = 5;
        protected int maxSize = 200;

        // Members
        protected string species;
        protected int size;
        protected int weight;
        protected string fishASCII = "<O(((><"; // max ASCII is 7 characters

        // Other
        protected ConsoleColor fishDisplayColor = ConsoleColor.White;

        // Constructor
        public Fish()
        {
            species = "Fish"; // Default Fish
            CalculateSizeWeight();
        }

        // Parametized Constructor
        public Fish(string fishName, string fishASCII, ConsoleColor fishDisplayColour) : this()
        {
            // This Assumes the FishASCII is less than 7 chars lol
            this.species = fishName;
            this.fishASCII = fishASCII;
            this.fishDisplayColor = fishDisplayColour;
        }

        // Functions 
        protected virtual void CalculateSizeWeight()
        {
            size = random.Next(maxSize - minSize) + minSize + 1; // picks a random number between the minSize and the max Size
            weight = size / 3; // A really rough estimate from cm to lb
        }

        public int GetSellingPrice()
        {
            // Random formula to determine the selling point of the fish
            return weight * 6;
        }

        // Display
        public void DisplayStats()
        {
            Console.WriteLine(
                "============================" +
                $"Species        : {Species}" +
                $"Size           : {size}cm" +
                $"Size Category  : SIZE 1" +
                $"Weight         : {Weight}lbs" +
                "============================"
                );
        }

        public void DisplayFishASCII(bool shouldReverse)
        {
            string fishASCIIToPrint = fishASCII;

            if (shouldReverse) { fishASCIIToPrint = ReverseString(fishASCII); }

            // Custom colours
            Console.ForegroundColor = fishDisplayColor;
            // Max ASCII art is 7 characters
            Console.WriteLine(fishASCIIToPrint);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void DisplayFishASCII()
        {
            DisplayFishASCII(false);
        }

        private static string ReverseString(string stringToReverse)
        {
            char[] charArray = stringToReverse.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        // Getters Setters
        public string Species
        {
            get => species; set => species = value;
        }
        public int Size
        {
            get => size; set => size = value;
        }
        public int Weight
        {
            get => weight; set => weight = value;
        }

        public string FishASCII
        {
            get => fishASCII;
            set
            {
                // Check if the length is in the range
                if(value.Length > 7)
                {
                    throw new ArgumentException("The input for FishASCII is too long!");
                }
                else
                {
                    fishASCII = value;
                }
            }
        }
    }
}
