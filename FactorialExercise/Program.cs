using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactorialExercise
{
    class Program
    {
        //calculate factorial
        static long Factorial(long num)
        {
            long sum = 1;
            for (int i = 1; i <= num; i++)
            {
                sum *= i;
            }
            return sum;
        }

        static void Main(string[] args)
        {
            string inputString = "";
            //run as long as the input is stop
            while (!inputString.Equals("stop"))
            {
                //request a number
                Console.Write("please enter a number to calculate it's factorial\n(you can type in 'stop' to stop the program): ");
                inputString = Console.ReadLine();

                //if it's a valid number
                if (long.TryParse(inputString, out long inputNum))
                {
                    long res = Factorial(inputNum);
                    Console.WriteLine($"The Factorial of { inputString } is { res }");
                }
            }
        }
    }
}
