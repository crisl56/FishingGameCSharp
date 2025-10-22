using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingGame
{
    public class ClownFish : Fish
    {
        // Base Constructor
        public ClownFish() : base()
        {
            mHasFish = true;
            this.species = "Clownfish";
            this.mAsset = " <*7>< ";
            this.mAssetReversed = " ><7*> ";

            this.mDisplayColor = ConsoleColor.Red;
        }

        // Parameterized Constructor
        public ClownFish(ConsoleColor displayColor) : this()
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
