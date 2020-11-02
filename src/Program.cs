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
            var (city, capital) = gm.GetRandomWordFromFile();

            var encoded = EncodeWord(capital);
            System.Console.WriteLine(capital);
            System.Console.WriteLine(encoded);
            gm.GenerateGameRules();
        }

        private static string EncodeWord(string word)
        {
            var encodedWord = "";
            foreach(var letter in word)
            {
                if(letter != ' ')
                    encodedWord += "_";
                else
                    encodedWord += " ";
            }
            return encodedWord;
        }
    }
}
