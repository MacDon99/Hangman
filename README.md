
# Hangman
Recruitment task.
Idea was to create a typical hangman game with some product owners' requirements.

## Technologies

 - .Net Core Console App

## Run
To run the project, go to src catalog and run command "dotnet run" via command line.
## Overview
At first, user see an introduction to the game as follows:
Welcome to the Hangman game!
Rules are simple. You have to guess the random word by writing a letter it could contain each round.
You have 5 lives, so you can be wrong 5 times with no consequences.
Loosing last live means you loose the game.
You can guess a letter or a whole word.
When you guess a word by typing it you get extra -10 seconds, but when you miss it, you lose 2 life points!
After 5 good tries in a row without loosing any live you get a hint!
Write start to start a game or exit to close it!

So after typing start, the game begins.
As it follows you can see a hangman acsi, guessing word, wrong and good guessing letters and users' life points which updates after every move

     ------
     |    |
     |
     |
     |
     |
    ---

    Word to guess: ________
    Wrong letters:
    Guessed letters:
    Your life points: 5
    Do you want to guess a letter or a whole word?
    Write end if you want to exit the game.

You can guess a single letter or a whole word, but you have to specify your move first, for example to guess a letter you have to write "letter" click enter and then type the letter you want to check.

After 5 good attempts in a row without loosing any life points you get a hint!

Guessing a whole word gives you extra time if you guess it, but it can cost you 2 lives if you miss!

## Winning

    Do you want to guess a letter or a whole word?
    Write end if you want to exit the game.
    word
    Write the word you want to check
    maputo
    Your guess is good, you win! Press any key to continue.
    Enter your name to save your score!
After winning the game you have to provide your name to save your score.
## Loosing

     ------
     |    |
     |   [ ]
     |   _|_
     |   _|_
     |
    ---
    You have lost. Drawn word was: Ngerulmud
    Game took you 7 tries and 0 mins and 46 seconds.
After loosing a game you get the information about number of your tries, time of guessing and the guessing word.
## After play
    ====================
    Name | Date | Time | Tries | Guessed word | Points
    Scoreboard:
    olowek | 11/04/2020 | 0:5 | 1 | Jakarta | 277440
    okulary | 11/03/2020 | 0:22 | 4 | Harare | 241920
    ====================
    Press any key to return to main menu.
After loosing or winning you always get the latest highscores, after clicking any key, you are asked if you want to play again or just leave the program.
