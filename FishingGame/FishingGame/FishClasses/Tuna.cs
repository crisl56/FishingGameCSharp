using System;

namespace FishingGame
{
    // Class by Cris

    public class Tuna : Fish
    {
        // Base Constructor
        public Tuna() : base()
        {
            this.species = "Tuna";
            this.mAsset = "<^(((><";

            this.mDisplayColor = ConsoleColor.Blue;
        }

        // Parameterized Constructor
        public Tuna(ConsoleColor displayColor) : this()
        {
            this.mDisplayColor = displayColor;
        }


        // Functions
        protected override void CalculateSizeWeight()
        {
            this.minSize = 50;
            this.maxSize = 385;

            size = random.Next(maxSize - minSize) + minSize + 1; // picks a random number between the minSize and the max Size
            weight = size * 5; // A really rough estimate from cm to lb for tuna
        }
    }
}
