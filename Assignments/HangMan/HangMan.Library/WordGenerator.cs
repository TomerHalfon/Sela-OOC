using System;

namespace HangMan.Library
{
    /// <summary>
    /// Creates a jagged array containing words for each difficulty in the enum
    /// </summary>
    static class WordGenerator
    {
        static string[][] _wordBank;
        static Random _rng;
        static internal int NumberOfDefaultLevels { get; } = 3;

        //replace the word bank to the parameter bank
        internal static void OverrideWordBank(string[][] words)
        {
            _wordBank = words;
        }

        //returns a random word based on the difficulty (sucsess = is if was able to load from file)
        internal static Word Generate(Difficulty difficulty)
        {
            _rng = new Random();
            // get a random word
            return new Word(_wordBank[(int)difficulty][_rng.Next(_wordBank[(int)difficulty].Length)]);
        }
        //the default word bank (HardCodedData allows for only 3 difficulties)
        internal static void InitDefaultWordBank()
        {
            //initialize the word bank
            _wordBank = new string[NumberOfDefaultLevels][];
            //Easy difficulty
            _wordBank[0] = new string[] { "Hello", "Good", "Dog", "Person", "Home", "Cat", "Car" };

            //Medium difficulty
            _wordBank[1] = new string[] { "Pineapple", "Motorcycle", "Refrigerator", "Beekeeper", "Internet", "Elephant" };

            //Hard difficulty
            _wordBank[2] = new string[] { "Rectangle", "Encyclopedia", "Inconsequential", "Automobile" };
        }
    }
}