// See https://aka.ms/new-console-template for more information

namespace FishingGame
{
    internal class Program
    {
        // enum for user choices
        enum UserChoice
        {
            play = 1,
            controls = 2,
            exit = 3,
        }

        // Variables
        static MainMenu mainMenu = new MainMenu(); // Main menu class
        static bool continueGame = true; // continue game flag
        static bool shownIntro = false; // intro flag

        static void Main(string[] args)
        {
            // Loop for game options
            while (continueGame)
            {
                ShowIntro();

                int userChoice;
                Input.ReadInt(out userChoice, 1, 3);

                DoUserChoice(userChoice);
            }

            // ending message
            Console.WriteLine("Thank you for playing!!!");
        }

        private static void ShowIntro()
        {
            if (!shownIntro)
            {
                mainMenu.DisplayIntro(500);
                shownIntro = true;
            }
            else { mainMenu.DisplayIntro(0); }
        }

        private static void DoUserChoice(int userChoice)
        {
            switch((UserChoice)userChoice)
            {
                case UserChoice.play:
                    mainMenu.DisplayStory(200);

                    StartGame();
                    break;
                case UserChoice.controls:
                    mainMenu.DisplayControls(100);
                    break;
                case UserChoice.exit:
                    continueGame = false;
                    // does nothing tbh
                    break;
            }
        }

        private static void StartGame()
        {
            Console.Clear();
            FishingWindow.Display();
            Console.SetCursorPosition(0, 12);
            FishingWindow.LiveGame();
            //Player.Position = 3;
            //Console.WriteLine(Player.Position);
            //Console.WriteLine(Player.PositionRaw);
        }

    }

}