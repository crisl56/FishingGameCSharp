using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingGame
{
    public  class Cell
    {
        protected virtual string mAsset { get; set; } = "       ";
        protected virtual ConsoleColor mDisplayColor { get; set; } = ConsoleColor.White ;
        public void DisplayASCII(bool shouldReverse)
        {
            string mAssetToPrint = mAsset;

            if (shouldReverse) { mAssetToPrint = ReverseString(mAsset); }

            // Custom colours
            Console.ForegroundColor = mDisplayColor;
            // Max ASCII art is 7 characters
            Console.Write(mAssetToPrint);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void DisplayASCII()
        {
            DisplayASCII(false);
        }


        private static string ReverseString(string stringToReverse)
        {
            char[] charArray = stringToReverse.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
