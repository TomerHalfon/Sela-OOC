using System;

namespace PigLatin
{
    /*
     * PigLatin Ex
     * Assumptions
     * The English phrase consists of words separated by blanks
     * there are no punctuation marks
     * all words have two or more letters.
     */
    class Program
    {
        const string addToEndOfWord = "ay";
        static string GetPigLatin(string word)
        {
            //remove the first char
            string translatedWord = word.Substring(1);

            //add the first char to the end
            translatedWord += word[0];

            //add the const ending of the word
            translatedWord += addToEndOfWord;

            //add a space after the word
            translatedWord += " ";

            return translatedWord;
        }
        static void Main()
        {
            //the string we will build upon
            string fullSentenceRes = string.Empty;

            //Request a sentence
            Console.WriteLine($"Please Enter your sentence:");
            string inputSentence = Console.ReadLine();

            //using the split method we can split the sentence by a seperator
            string[] words = inputSentence.Split(' ');

            //loop through all of the words
            foreach (string word in words)
            {
                //Translate the word
                fullSentenceRes += GetPigLatin(word);
            }
            Console.WriteLine($"The Full PigLatin Translation of the sentence: {inputSentence}\n");
            Console.WriteLine(fullSentenceRes +"\n");
        }
    }
}
