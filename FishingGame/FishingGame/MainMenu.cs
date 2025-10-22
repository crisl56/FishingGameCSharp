using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingGame
{
    public class MainMenu
    {
        // Class by Cris

        // List of stuff to print
        // Using this Text to ASCII Site: https://patorjk.com/software/taag/#p=display&f=Soft&t=&x=none&v=4&h=4&w=80&we=false
        private string[] title = [
            "========================================================================",
            @" ,-----.                                 ,--.   ,--.                 ",
            @"'  .-.  ' ,---. ,---.  ,--,--.,--,--,    |   `.'   | ,--,--.,--,--,  ",
            @"|  | |  || .--'| .-. :' ,-.  ||     \\   |  |'.'|  |' ,-.  ||    \\",
            @"'  '-'  '\\ `--.\\   --.\\ '-'  ||  ||   |   |  |  |  |\\ '-'  || || ",
            @" `-----'  `---' `----' `--`--'`--''--'    `--'   `--' `--`--'`--''--' ",
            "========================================================================",
            "By PG29 - Ken, Dylan, Cris, Vi"
            ];

        private string[] controls = [
            "======================",
            "a      - Move left",
            "d      - Move right",
            "space  - reel in fish",
            "key    - go to shop",
            "======================"
            ];

        private string[] story = [
            "The year is 20XX",
            "",
            "The world has ended.",
            "All of civilization has crumbled.",
            "",
            "But fish?",
            "There are many fish still",
            "",
            "GO OUT AND FISH!!!",
            "CAST YOUR LINE.",
            "CATCH YOUR DESTINY!.",
            "FOR ALL THAT IS LEFT IS FISH.",
            ];


        // Functions
        public void DisplayIntro(int delay)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            DisplayArray(title, delay);
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine();
            Console.WriteLine("Welcome to Ocean Man!!!");
            Console.WriteLine("The bestest fishing console game of October 2025!");
            Console.WriteLine("Good luck fishing!");
            Console.WriteLine();
            Console.WriteLine("Please select an option to do: (1-3)");
            Console.WriteLine("1. Play game");
            Console.WriteLine("2. See controls");
            Console.WriteLine("3. Exit");
        }

        public void DisplayControls(int delay)
        {
            Console.Clear();
            Console.WriteLine();

            DisplayArray(controls, delay);

            WaitForInput();
        }

        public void DisplayStory(int delay)
        {
            Console.Clear();
            Console.WriteLine();

            DisplayArray(story, delay);

            WaitForInput();
        }

        private static void WaitForInput()
        {
            Console.WriteLine("Press enter to continue!");
            Console.ReadLine();

            Console.Clear();
        }

        private void DisplayArray(string[] arrayToPrint, int delay)
        {
            foreach(string line in arrayToPrint)
            {
                Console.WriteLine(line);
                Thread.Sleep(delay);
            }
        }
    }
}
