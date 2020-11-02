using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace src
{
    class Program
    {
        static void Main(string[] args)
        {
            var gm = new GameManager();
            var enteredText = "";
            gm.ShowGameRules();
            do
            {
                if (enteredText != "returned")
                    enteredText = Console.ReadLine();

                switch(enteredText)
                {
                    case "start":
                        gm.StartGame();
                        enteredText = "returned";
                        break;
                    case "returned":
                        Console.Clear();
                        gm.ShowGameRules();
                        enteredText = "";
                        break;
                    case "exit":
                        Console.WriteLine("Thanks for playing.");
                        break;
                    default:
                        Console.WriteLine("Type the right option.");
                        break;
                }
            }while(enteredText != "exit");
        }
    }
}
