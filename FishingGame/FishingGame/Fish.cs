using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingGame
{
    public class Fish
    {
        // Constructor
        public Fish()
        {
            Random random = new Random();
            species = "tuna"; // Everything is a tuna in this demo
            size = random.Next(maxSize - minSize) + minSize+1; // picks a random number between the minSize and the max Size
            weight = size/3; // A really rough estimate of how heavy a yellowfin tuna is compared to its length (~0.33lbs / cm)
        }

        // Constants
        const int minSize = 50;
        const int maxSize = 2000;

        // Members
        private string species;
        private int size;
        private int weight;

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

        // Display
        public void Stats()
        {
            Console.WriteLine("Species: {0}", Species);
            Console.WriteLine("Size: {0}cm", Size);
            Console.WriteLine("Weight: {0}lbs", Weight);
            Console.WriteLine("====================");
        }
    }
}
