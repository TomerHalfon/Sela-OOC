using System;

namespace FactorialExercise
{
    class Program
    {
        //calculate factorial with a recursive function
        static long FactorialRec(long num)
        {
            //recursive end point
            if (num<=1)
            {
                return 1;
            }
            return num * FactorialRec(num - 1);
        }

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

        static void Main()
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
                    //regular factorial function
                    long res = Factorial(inputNum);

                    ////recursive factorial function
                    //long res = FactorialRec(inputNum);

                    //print resualt
                    Console.WriteLine($"The Factorial of { inputString } is { res }");
                }
            }
        }
    }
}
