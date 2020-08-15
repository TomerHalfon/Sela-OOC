using System;
using System.Text;

namespace HangMan.Library
{
    /// <summary>
    /// A word is a string and an array of flags
    /// it also allows to show only what that is guessed so far
    /// </summary>
   sealed class Word
    {
        //a const to represent an unguessed letter
        const char emptySign = '_';
        internal bool IsComplete
        {
            get
            {
                for (int i = 0; i < _flags.Length; i++)
                {
                    if (!_flags[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        //holds the word 
        readonly string _word;

        //holds the flags for letters in the word that were guessed by the player
        readonly Flags _flags;

        internal Word(string word)
        {
            _word = word;
            _flags = new Flags(_word.Length);
        }

        //here we expect that the letter hasn't been guessed before(it won't matter to the game if in the word model we assign true on true...)
        internal bool Guess(char letter)
        {
            //creats a duplicate of the word but with Upper case letters
            string upperWord = _word.ToUpper();
            bool res = false;
            //loop the word
            for (int i = 0; i < upperWord.Length; i++)
            {
                //check letter in i position
                if (upperWord[i].Equals(letter))
                {
                    //update the flag
                    _flags[i] = true;
                    //successful guess
                    res = true;
                }
            }
            //return if the guess was correct
            return res;
        }
        //the ToString method will return the word as a string, will only show the guessed letters, unguessed letters will appear as a const sign
        public override string ToString()
        {
            StringBuilder hiddenWord = new StringBuilder();
            for (int i = 0; i <_flags.Length; i++)
            {
                hiddenWord.Append(_flags[i] ? _word[i].ToString() : emptySign + " ");
            }
            return hiddenWord.ToString();

        }
        //reveal the entire word
        internal void Reveal()
        {
            for (int i = 0; i < _flags.Length; i++)
            {
                _flags[i] = true;
            }
        }
    }
}
