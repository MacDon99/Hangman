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
            var (city, capital) = getRandomWordFromFile();
            System.Console.WriteLine(city);
            System.Console.WriteLine(capital);
        }
        private static (string, string) getRandomWordFromFile()
        {
            var filePath = "files/countries_and_capitals.txt";
            var dictionary = new Dictionary<string, string>();
            var rand = new Random();

            File.ReadAllLines(filePath)
                .ToList()
                .ForEach(el => {
                    var splittedItems = el.Split(" | ");
                    if(splittedItems.Count() == 2)
                        dictionary.Add(splittedItems[0],splittedItems[1]);
                    });

            var randomItemIndex = rand.Next(0, dictionary.Count);

            var city = dictionary.Keys.ElementAt(randomItemIndex);
            var capital = dictionary.Values.ElementAt(randomItemIndex);

            return (city, capital);
        }
    }
}
