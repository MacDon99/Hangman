using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace src
{
    public class GameManager
    {
        public void GenerateGameRules()
        {
            Console.WriteLine("Welcome to the Hangman game!");
            Console.WriteLine("Rules are simple. You have to guess the random word by writing a letter it could contain each round.");
            Console.WriteLine("You have 5 lives, so you can be wrong 5 times with no consequences.");
            Console.WriteLine("Loosing last live means you loose the game.");
            Console.WriteLine("After 5 good tries in a row without loosing any live you get a hint!");
            System.Console.WriteLine("Write start to start a game!");
        }
        public (string, string) GetRandomWordFromFile()
        {
            var filePath = "files/countries_and_capitals.txt";
            var dictionary = new Dictionary<string, string>();
            var rand = new Random();

            File.ReadAllLines(filePath)
                .ToList()
                .ForEach(el =>
                {
                    var splittedItems = el.Split(" | ");
                    if (splittedItems.Count() == 2)
                        dictionary.Add(splittedItems[0], splittedItems[1]);
                });

            var randomItemIndex = rand.Next(0, dictionary.Count);

            var city = dictionary.Keys.ElementAt(randomItemIndex);
            var capital = dictionary.Values.ElementAt(randomItemIndex);

            return (city, capital);
        }
    }
}