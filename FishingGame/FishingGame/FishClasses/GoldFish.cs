using System;


namespace FishingGame
{
    public class GoldFish : Fish
    {
        // Class by Cris

        // Base Constructor
        public GoldFish() : base()
        {
            this.species = "Gold Fish";
            this.mAsset = "  <><  ";
            this.mAssetReversed = "  ><>  ";

            this.mDisplayColor = ConsoleColor.Yellow;
        }

        // Parameterized Constructor
        public GoldFish(ConsoleColor displayColor) : this()
        {
            this.mDisplayColor = displayColor;
        }


        // Functions
        protected override void CalculateSizeWeight()
        {
            this.minSize = 15;
            this.maxSize = 50;

            size = random.Next(maxSize - minSize) + minSize + 1; // picks a random number between the minSize and the max Size
            weight = size * 2; // A really rough estimate from cm to lb for tuna
        }
    }
}
