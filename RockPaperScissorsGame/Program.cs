using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsGame
{
    class Program
    {
        static void PrintOptions()
        {
            //selections
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Rock");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Paper");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Scissors");
            Console.ForegroundColor = ConsoleColor.White;
        }
        static string GetComputerSelection(string playerSelection) 
        {
            string res;
            switch (playerSelection)
            {
                case "Rock":
                    res =  "Paper";
                    break;

                case "Paper":
                    res = "Scissors";
                    break;

                case "Scissors":
                    res = "Rock";
                    break;

                default:
                    res = "";
                    break;
            }
            return res;
        }

        static void Main(string[] args)
        {
            string inputString;
            string computerSelection;

            //instructions
            Console.WriteLine("Welcome to 'Rock Paper Scissors'");
            Console.WriteLine("you start the game by selecting one of the options\nthe game can last forever so type 'Stop' to stop the program");

            //game loop
            do
            {
                //show the options the player have and request a selection
                Console.WriteLine("\nEnter your choice");
                PrintOptions();
                Console.WriteLine();
                inputString = Console.ReadLine();

                //call the func and get the computer selection
                computerSelection = GetComputerSelection(inputString);

                //if not the default case (a valid input)
                if (!computerSelection.Equals(""))
                {
                    Console.WriteLine($"\nI chose the better weapon in this children game\n{computerSelection} beats {inputString}");
                }
                else if (!inputString.Equals("Stop"))
                {
                    Console.WriteLine($"\n{inputString} is not a valid selection");
                }

            } while (!inputString.Equals("Stop"));

            //display a message to indicate closing of the game
            Console.WriteLine("Closing the game");
        }
    }
}
