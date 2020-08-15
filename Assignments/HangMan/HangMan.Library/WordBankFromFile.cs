using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace HangMan.Library
{
    /// <summary>
    /// Allows to load a file and convert it to a jagged array which is used as a WordBank in the WordGenerator
    /// </summary>
        /*  A Formatted File minimum requirements
         * instructions line
         * difficulty line
         * a word
         */
    static class WordBankFromFile
    {
        #region Consts
        const string fileName = "Words.txt";
        const string instructionsLine = "**Add after each difficulty the words in separate lines**";
        const string wordTamplate1 = "*WordsGoesHere*";
        const string wordTamplate2 = "*WordsGoesHere*";
        const string invalidWord = " - InvalidWord";
        #endregion

        static readonly string[] difficultiesArray;

        static WordBankFromFile()
        {
            difficultiesArray = Enum.GetNames(typeof(Difficulty));
        }

        //Convert the file to a word bank (jagged array)
        internal static string[][] GetWordBank()
        {
            //word bank
            string[][] result = new string[difficultiesArray.Length][];

            string[] arr = ReadFile();
            if (arr == null)
            {
                throw new InvalidDataException("Edit the file to add words");
            }

            int dif = 0;
            int[] indexOfDifficulty = GetDifficultiesIndex(arr);
            foreach (int difficultyIndex in indexOfDifficulty)
            {
                List<string> temp = new List<string>();
                //after the keyword
                int i = difficultyIndex + 1;
                //while it didn't reach the next difficulty
                while (!indexOfDifficulty.Contains(i) && i < arr.Length)
                {
                    if (!arr[i].Contains(invalidWord))
                    {
                        //if the word is valid
                        temp.Add(arr[i]);
                    }
                    i++;
                }
                result[dif] = temp.ToArray();
                if (temp.Count == 0)
                {
                    throw new InvalidDataException($"No Words Found for {(Difficulty)dif} difficulty");
                }
                dif++;
            }
            return result;
        }
        //Create (Override) the base format of the file
        internal static void CreateBaseFile()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(instructionsLine);
            foreach (string difficulty in difficultiesArray)
            {
                sb.AppendLine(difficulty);
                sb.AppendLine(wordTamplate1);
                sb.AppendLine(wordTamplate2);
            }
            File.WriteAllText(fileName, sb.ToString());
        }
        //will open a text editor to allow editing of words
        internal static void Edit()
        {
            try
            {
                Process.Start(fileName);
            }
            catch (FileNotFoundException)
            {
                CreateBaseFile();
                Process.Start(fileName);
            }
        }

        //will read the file to an array
        static string[] ReadFile()
        {
            if (!File.Exists(fileName))
            {
                CreateBaseFile();
                return null;
            }
            return FlagInvalidWords(File.ReadAllLines(fileName));
        }
        //will flag any invalid words
        static string[] FlagInvalidWords(string[] words)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(instructionsLine);

            //start by skipping the instructions
            for (int i = 1; i < words.Length; i++)
            {
                //if the word is not of english charecters flag it as an invalid word
                if (!words[i].All(char.IsLetter) && !words[i].Contains(invalidWord) || words[i].Length == 0)
                {
                    words[i] += invalidWord;
                }
                sb.AppendLine(words[i]);
            }

            //rewrite the file so the player will know why his words didn't appear
            File.WriteAllText(fileName, sb.ToString());

            //retutrn the array now when we know what to skip
            return words;
        }
        //will look for the indexes of the difficulties
        static int[] GetDifficultiesIndex(string[] arr)
        {
            //gets a list of the indexers of the difficlties lvls in the fileArray
            List<int> indexOfDifficulty = new List<int>();
            foreach (string difficulty in difficultiesArray)
            {
                int index = Array.IndexOf(arr, difficulty);
                if (index != -1)
                {
                    indexOfDifficulty.Add(index);
                }
                else
                {
                    throw new InvalidDataException("Can't find all difficulties");
                }
            }
            return indexOfDifficulty.ToArray();
        }
    }
}

