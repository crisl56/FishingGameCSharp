using System;

namespace FishingGame
{
    // Class by Cris Odonel

    public class Fish : Cell
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
        protected override string mAsset { get; set; } = "<O(((><"; // max ASCII is 7 characters
        protected override string mAssetReversed { get; set; } = "><)))O>";

        // Other
        protected override ConsoleColor mDisplayColor { get; set; } = ConsoleColor.White;

        // Constructor
        public Fish()
        {
            mHasFish = true;
            species = "Fish"; // Default Fish
            CalculateSizeWeight();
        }

        // Parametized Constructor
        public Fish(string fishName, string asset, ConsoleColor displayColor) : this()
        {
            // This Assumes the FishASCII is less than 7 chars lol
            this.species = fishName;
            this.mAsset = asset;
            this.mDisplayColor = displayColor;
        }

        // Functions 
        protected virtual void CalculateSizeWeight()
        {
            size = random.Next(maxSize - minSize) + minSize + 1; // picks a random number between the minSize and the max Size
            weight = size / 3; // A really rough estimate from cm to lb
        }

        public virtual int GetSellingPrice()
        {
            // Random formula to determine the selling point of the fish
            return weight * 6;
        }

        // Display
        public void DisplayStats()
        {
            Console.WriteLine(
                "============================ \n" +
                $"Species        : {Species} \n" +
                $"Size           : {size}cm \n" +
                $"Size Category  : SIZE 1 \n" +
                $"Weight         : {Weight}lbs \n" +
                $"Price          : ${GetSellingPrice()} \n" +
                "============================"
                );
        }

        public void DisplayFishASCII(bool shouldReverse)
        {
            string mAssetToPrint = mAsset;

            if (shouldReverse) { mAssetToPrint = ReverseString(mAsset); }

            // Custom colours
            Console.ForegroundColor = mDisplayColor;
            // Max ASCII art is 7 characters
            Console.Write(mAssetToPrint);
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

        public string Asset
        {
            get => mAsset;
            set
            {
                // Check if the length is in the range
                if(value.Length > 7)
                {
                    throw new ArgumentException("The input for FishASCII is too long!");
                }
                else
                {
                    mAsset = value;
                }
            }
        }
    }
}
