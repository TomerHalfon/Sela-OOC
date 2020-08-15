using System;
using System.Collections.Generic;

namespace HangMan.Library
{
    /// <summary>
    /// a Class that holds an array of flags to each letter in the alphabet(Capital).
    /// </summary>
   sealed class Guesses
    {
        const int numOfLetters = 26;
        readonly Flags _flags;
        internal bool this[char letter]
        {
            get
            {
                return _flags[ConvertLetterToAlphabeticalIndex(letter)];
            }
            set
            {
                _flags[ConvertLetterToAlphabeticalIndex(letter)] = value;
            }
        }

        //will return a list of the letters that has been flaged (guessed)
        internal List<char> LettersGuessed
        {
            get
            {
                List<char> temp = new List<char>();
                for (int i = 0; i < _flags.Length; i++)
                {
                    if (_flags[i])
                    {
                        temp.Add(ConvertAlphabeticalIndexToChar(i));
                    }
                }
                return temp;
            }
        }

        //the defualt is 26, there is an option to add more incase we will need to 
        internal Guesses(int amount = numOfLetters)
        {
            _flags = new Flags(amount);
        }

        //convert a letter to an index ('A') = 0
        int ConvertLetterToAlphabeticalIndex(char letter)
        {
            return letter - 'A';
        }
        //convert an index to a letter ('A') = 0
        char ConvertAlphabeticalIndexToChar(int index)
        {
            return Convert.ToChar(index + 'A');
        }
    }
}
