using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatingTheDigitsOfOddNumbers
{
    class Program
    {
        static int GetSumOfDigits(int num)
        {
            int sum = 0;

            //make sure that negative numbers work
            int workingNum = Math.Abs(num);

            //as long as you have a number
            while (workingNum > 0)
            {
                //add the first digit
                sum += workingNum % 10;

                //remove it from the number
                workingNum /= 10;
            }
            return sum;
        }
        static void Main(string[] args)
        {
            string inputString = "Y";
            int inputNum;
            do
            {
                //request a number
                Console.WriteLine("Please enter a whole odd number");
                bool isSucsess = int.TryParse(Console.ReadLine(), out inputNum);

                //check if the number is valid(a Whole Odd number)
                if (!isSucsess || inputNum % 2 == 0)
                {
                    Console.WriteLine("invalid input");
                    Console.WriteLine("try again");
                    continue;
                }
                else
                {
                    Console.WriteLine($"{GetSumOfDigits(inputNum)}");
                }

                Console.Write("Do you want to continue?\nEnter Y to continue OR any other key to exit: ");
                inputString = Console.ReadLine();
            } while (inputString.Equals("Y"));

        }
    }
}
