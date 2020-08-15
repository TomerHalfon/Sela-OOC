using System.Collections.Generic;

namespace HangMan.Library
{
    /// <summary>
    /// holds all of the data relevent to the player.
    /// player name, score and guesses
    /// </summary>
   sealed class Player
    {
        //how many points to add to the player's score foreach good guess
        const int pointsForSucsess = 100;

        //a readonly name for the player
        internal string Name { get;}
        //the score for the player
        internal int Score { get; private set; }

        //only allow the user of this class acsess only to a spesific property in Guesses 
        internal List<char> LettersGuessed
        {
            get
            {
                return _guesses.LettersGuessed;
            }
        }

        //all of the guesses availability for this player
        Guesses _guesses;

        //a player instance will be created through the game manager, the only data the user of the class can input here is the players name
        internal Player(string name)
        {
            Name = name;
            _guesses = new Guesses();
            Score = 0;
        }

        //checks if the letter has been guesd before
        internal bool IsAvaileableToGuess(char letter)
        {
            return !_guesses[letter];
        }
        //update the guesses array to reflect the letter availability and update score
        internal void Guess(char letter, bool sucsess)
        {
            _guesses[letter] = true;
            if (sucsess)
            {
                Score += pointsForSucsess;
            }
        }

        //reset the _guesses obj
        internal void ResetPlayerGuesses()
        {
            _guesses = new Guesses();
        }
        internal void ResetPlayerScore()
        {
            Score = 0;
        }
    }
}
