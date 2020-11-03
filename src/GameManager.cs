using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace src
{
    public class GameManager
    {
        private bool GameOver { get; set; }
        private int LifePoints { get; set; }
        private string HiddenWord { get; set; }
        private int Tries { get; set; }
        private DateTime StartTime { get; set; } = DateTime.Now;
        private DateTime EndTime { get; set; }
        private TimeSpan AverageTime { get; set; }
        private (string, string) WordToGuess { get; set; }

        public GameManager()
        {
            GameOver = false;
        }
        public void ShowGameRules()
        {
            Console.WriteLine("Welcome to the Hangman game!");
            Console.WriteLine("Rules are simple. You have to guess the random word by writing a letter it could contain each round.");
            Console.WriteLine("You have 5 lives, so you can be wrong 5 times with no consequences.");
            Console.WriteLine("Loosing last live means you loose the game.");
            Console.WriteLine("You can guess a letter or a whole word.");
            Console.WriteLine("When you guess a word by typing it you get extra -10 seconds, but when you miss it, you lose 2 life points!");
            Console.WriteLine("After 5 good tries in a row without loosing any live you get a hint!");
            Console.WriteLine("Write start to start a game or exit to close it!");
        }
        public void StartGame()
        {
            LifePoints = 5;
            WordToGuess = GetRandomWordFromFile();
            HiddenWord = EncodeWord(WordToGuess.Item2);
            var newText = "";
            do
            {
                if(GameOver)
                {
                    GameOver = false;
                    LifePoints = 5;
                    return;
                }
                Console.Clear();

                if(Tries == 5 && LifePoints == 5)
                {
                    System.Console.WriteLine($"Hint: The capital of {WordToGuess.Item1}");
                }
                Console.WriteLine("Word to guess: " + HiddenWord);
                Console.WriteLine("Word to guess: " + WordToGuess.Item2);
                Console.WriteLine("Your life points: " + LifePoints);

                newText = AskForGuessingType();

                switch(newText)
                {
                    case "letter":
                        CheckIfWordToGuessContainGivenLetter();
                        break;
                    case "word":
                        CheckIfWordToGuessEqualsGivenWord();
                        break;
                    case "end":
                        Console.WriteLine("You have lost. Drawn word was: " + WordToGuess.Item2);
                        EndGame();
                        GameOver = false;
                        break;
                }
            }while(newText != "end");
        }

        private void CheckIfWordToGuessEqualsGivenWord()
        {
            Console.WriteLine("Write the word you want to check");
            var wordToCheck = Console.ReadLine();
            var normalizedWordToGuess = WordToGuess.Item2.ToLower();

            if(normalizedWordToGuess.Equals(wordToCheck))
            {
                Console.WriteLine("Your guess is good, you win! Press any key to continue.");
                Tries++;
                EndTime = DateTime.Now;
                AverageTime = EndTime - StartTime;
                EndGame();
            } 
            else 
            {
                Console.WriteLine("Unfortunately, the drawn word is not equal to your guess.");
                Tries++;
                TakeOneLife();
                TakeOneLife();
                Console.WriteLine("You loose two life points, press any key to continue.");
                Console.ReadKey();
            }
        }

        private void CheckIfWordToGuessContainGivenLetter()
        {
            Console.WriteLine("Write the letter you want to check");
            var letterToCheck = Console.ReadLine();
            var normalizedWordToGuess = WordToGuess.Item2.ToLower();

            if(normalizedWordToGuess.Contains(letterToCheck))
            {
                var x = HiddenWord.ToCharArray();

                for(int i=0; i< x.Count(); i++)
                {
                    if(normalizedWordToGuess[i] == Convert.ToChar(letterToCheck))
                                x[i] = WordToGuess.Item2[i];
                }
                HiddenWord = new string(x);
                Console.WriteLine("You hit a good letter! Press any key to continue.");
                Tries++;
                CheckIfWin();
                Console.ReadKey();
            } 
            else 
            {
                Console.WriteLine("Unfortunately, the drawn word does not contain given letter.");
                Tries++;
                TakeOneLife();
            }
        }

        public string AskForGuessingType()
        {
            string answer = "";
            Console.WriteLine("Do you want to guess a letter or a whole word?");
            Console.WriteLine("Write end if you want to exit the game.");
            do
            {
                answer = Console.ReadLine();
            }while(answer != "letter" && answer != "word" && answer != "end");
            return answer;
        }
        private (string, string) GetRandomWordFromFile()
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
        private void TakeOneLife()
        {
            if(LifePoints > 1)
            {
                LifePoints--;
            }
            else
                {
                    LifePoints = 0;
                    Console.WriteLine("You have lost. Drawn word was: " + HiddenWord);
                    EndGame();
                }
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
        private void CheckIfWin()
        {
            if(!HiddenWord.Contains("_"))
            {
                Console.WriteLine("Congratulations, you won!");
                EndGame();
            }
        }
        private void EndGame()
        {
            GameOver = true;
            Console.WriteLine($"Game took you {Tries} tries and {AverageTime.Minutes} mins and {AverageTime.Seconds} seconds.");
            System.Console.WriteLine("Press any key to return to main menu.");
            Console.ReadKey();
        }
    }
}