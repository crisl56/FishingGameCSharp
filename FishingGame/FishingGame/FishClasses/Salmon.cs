using System;

namespace FishingGame
{
    public class Salmon : Fish
    {
        // Class by Cris

        // Base Constructor
        public Salmon() : base()
        {
            this.species = "Salmon";
            this.mAsset = " <^>>< ";
            this.mAssetReversed = " ><^> ";
            
            this.mDisplayColor = ConsoleColor.Magenta;
        }

        // Parameterized Constructor
        public Salmon(ConsoleColor displayColor) : this()
        {
            this.mDisplayColor = displayColor;
        }

        // Functions
        protected override void CalculateSizeWeight()
        {
            this.minSize = 35;
            this.maxSize = 148;

            size = random.Next(maxSize - minSize) + minSize + 1; // picks a random number between the minSize and the max Size
            weight = size * 5; // A really rough estimate from cm to lb for salmon
        }
    }
}
