using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace src
{
    class Program
    {
        public static GameManager GameManager { get; set; } = new GameManager();
        public static string Option { get; set; }
        static void Main(string[] args)
        {
            GameManager.ShowGameRules();
            do
            {
                if (Option != "returned" && Option != "exit")
                    Option = Console.ReadLine();

                switch(Option)
                {
                    case "start":
                        GameManager.StartGame();
                        Option = "returned";
                        break;
                    case "returned":
                        Console.Clear();
                        AskIfPlayerWantToPlayAgain();
                        break;
                    case "exit":
                        break;
                    default:
                        Console.WriteLine("Type the right option.");
                        break;
                }
            }while(Option != "exit");

            Console.WriteLine("Thanks for playing.");
        }

        public static void AskIfPlayerWantToPlayAgain()
        {
             var currentOption = "";
            Console.WriteLine("Do you want to play again?");
            do
            {
                currentOption = Console.ReadLine();
                switch(currentOption)
                {
                    case "yes":
                        GameManager.ShowGameRules();
                        Option = "start";
                        break;
                    case "no":
                        Option = "exit";
                        break;
                    default:
                        Console.WriteLine("Please enter a correct answer.");
                        break;
                }
            }while(currentOption != "yes" && currentOption != "no");
        }
    }
}
