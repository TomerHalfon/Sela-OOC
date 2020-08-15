using System;
using System.Text;

namespace HangMan.Library
{
    /// <summary>
    /// The Game itself
    /// </summary>
    public sealed class GameManager
    {
        //how many mistakes allowed
        const int hangManStages = 10;
        //EventsHandler
        public event EventHandler<bool> GameOverEvent;

        //the player instance (his guesses, name and score)
        Player GamePlayer { get; }
        #region Player data acsses
        //properies here allow the user of the dll to get data about the game without knowing about the player obj)
        public int GameScore { get { return GamePlayer.Score; } }
        public string PlayerName { get { return GamePlayer.Name; } }
        public string LettersGuessedAsString
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                foreach (char letter in GamePlayer.LettersGuessed)
                {
                    sb.Append($"{letter} ");
                }
                return sb.ToString();
            }
        }
        public char[] LettersGuessedAsCharArray
        {
            get
            {
                return GamePlayer.LettersGuessed.ToArray();
            }
        }
        #endregion

        #region Game Info
        //The instance of the word being played (holds the string and the flags)
        Word WordToGuess { get; set; }

        //the difficulty lvl
        public Difficulty GameDifficulty { get; private set; }

        //the status of the hang man daiagram
        int _hangManStatus;
        public int HangedManStatus
        {
            get { return _hangManStatus; }
            private set
            {
                _hangManStatus = value;
                //check if the hang man has reached it's final stage (game over)
                if (_hangManStatus >= hangManStages)
                {
                    //the game is over
                    GameOver();
                }
            }
        }

        //is the default word bank active
        //is the game active
        bool IsGameActive { get; set; }
        #endregion

        //constructor, sets the game as the default difficulty (Easy)
        public GameManager(string playerName, bool readFromFile, Difficulty difficulty = default)
        {
            //create a player with the name provided(parameter)
            GamePlayer = new Player(playerName);

            //check if it should use the data in the txt file
            if (readFromFile)
            {
                ReadFromFile();
                //set the difficulty
                GameDifficulty = difficulty;
            }
            //default wordbank
            else
            {
                //Init the Default WordBank
                WordGenerator.InitDefaultWordBank();
                //set the difficulty to the given parameter only if the default word bank can support the difficulty 
                if ((byte)difficulty <= WordGenerator.NumberOfDefaultLevels)
                {
                    GameDifficulty = difficulty;
                }
                //if can't then default
                else
                {
                    GameDifficulty = default;
                }
            }

            //generate a new word based on the difficulty
            WordToGuess = WordGenerator.Generate(GameDifficulty);
            //set the hangman status to 0
            HangedManStatus = 0;
            //activate the game (flag)
            IsGameActive = true;
        }

        //will print the (Coded) Word
        public override string ToString()
        {
            return WordToGuess.ToString();
        }

        #region GameControls
        //Allow to input a guess from outside od the dll (from the ui)
        public bool Guess(char letter)
        {
            bool res = false;

            //validate the input
            if (!ValidateLetter(letter))
            {
                //if not valid, do not cotinue and throw an argument exception
                throw new ArgumentException($"{letter} is not a valid English letter");
            }
            //use upper case letters only
            char upperLetter = char.ToUpper(letter);

            //check if the game is active and that the letter is available to guess
            if (IsGameActive && GamePlayer.IsAvaileableToGuess(upperLetter))
            {
                //guess the letter in two places,
                //in the word model
                //res will be the flag that will tell the user of the class if he was successful in his guess
                res = WordToGuess.Guess(upperLetter);
                //in the Player model
                GamePlayer.Guess(upperLetter, res);

                //check if the game is done(player guessed the entire word)
                if (WordToGuess.IsComplete)
                {
                    //acitvate the win game method(holds instructions for the end of the game)
                    WinGame();
                    //return sucsessfull guess and exit the method
                    return true;
                }

                //the guess was unsuccessful
                if (!res)
                {
                    //update the hang man status
                    HangedManStatus++;
                }
            }
            return res;
        }
        //make sure the letter is valid
        bool ValidateLetter(char letter)
        {
            //allow only english letters
            return char.IsLetter(letter);
        }

        //Allow to regenerate a new game from outside of the dll (from the ui)
        public void NewGame()
        {
            //set a new word
            NewWord();
            //activate the game (flag)
            IsGameActive = true;
            //Reset the score
            GamePlayer.ResetPlayerScore();
        }

        public void NextWord()
        {
            //set a new word
            NewWord();
            //activate the game (flag)
            IsGameActive = true;
        }
        //generate new word
        void NewWord()
        {
            //get new word from the generator
            WordToGuess = WordGenerator.Generate(GameDifficulty);
            //allways reset the hangman status when resetting the word
            HangedManStatus = 0;
            //allways reset the guesses when resetting the word
            GamePlayer.ResetPlayerGuesses();
        }
        //allow to change the difficilty lvl, will also allow to create a new game
        public void ChangeDifficulty(Difficulty difficulty, bool newGame)
        {
            //update the difficulty
            GameDifficulty = difficulty;

            if (newGame)
            {
                //generate a new game if asked to
                NewGame();
                //and exit
                return;
            }
            //generate a new word with out creating a new game
            NewWord();
        }
        #endregion

        #region GameEnding
        //what to do when the game is lost
        void GameOver()
        {
            //end the game
            IsGameActive = false;
            //Reveal The Word
            WordToGuess.Reveal();
            // invoke the event only if someone listens to it (not Null)
            GameOverEvent?.Invoke(this, false);
        }

        //wat to do when the game is won
        void WinGame()
        {
            IsGameActive = false;
            //invoke the event only if someone listens to it (not Null), pass true to indicate a win
            GameOverEvent?.Invoke(this, true);
        }

        #endregion

        #region FileControl
        //open the Text Editor to edit the words file
        public static void EditTxtFile()
        {
            WordBankFromFile.Edit();
        }
        //Replace
        public static void RepleaceFile()
        {
            WordBankFromFile.CreateBaseFile();
        }
        //Read from the words file
        void ReadFromFile()
        {
            //will throw an exception if cant read file correctly
             WordGenerator.OverrideWordBank(WordBankFromFile.GetWordBank());
        }
        public static void UseDefaultWordBank()
        {
            WordGenerator.InitDefaultWordBank();
        }
        #endregion
    }
}