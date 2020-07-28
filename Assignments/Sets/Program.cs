using System;
using System.Collections.Generic;

namespace Sets
{
    class Program
    {
        //a rng for the program
        static Random rng = new Random();

        #region Functions for ease of use
        static void ReRollData(params Set[] sets)
        {
            foreach (Set item in sets)
            {
                for (int i = 0; i < 12; i++)
                {
                    item.Insert(rng.Next(1001));
                }
            }
        }
        static int RequestNumber(string msg)
        {
            int num;
            Console.Write(msg);
            while (!int.TryParse(Console.ReadLine(), out num))
            {
                Console.WriteLine("Invalid input!\nTry again...");
            }
            return num;
        } 
        #endregion
        static void Main()
        {
            //create two sets (s1,s2)
            Set s1 = new Set();
            Set s2 = new Set();

            //roll new data to each set
            ReRollData(s1, s2);

            //print the two sets
            Console.WriteLine("Generated two sets: ");
            Console.WriteLine($"S1 ==> {s1}");
            Console.WriteLine($"S2 ==> {s2}\n");

            //Intersect the two sets
            s1.Intersect(s2);
            Console.WriteLine($"Intersecting S2 to S1 ==> {s1}\n");

            //reset, reRoll and print data 
            s1 = new Set();
            s2 = new Set();
            ReRollData(s1, s2);
            Console.WriteLine("Rerolled Data!");
            Console.WriteLine($"S1 ==> {s1}");
            Console.WriteLine($"S2 ==> {s2}\n");

            //Preform Union on the two sets
            s1.Union(s2);
            Console.WriteLine($"Union S2 and S1 to S1 ==> {s1}\n");

            //reset, reRoll and print data 
            s1 = new Set();
            s2 = new Set();
            ReRollData(s1, s2);
            Console.WriteLine("Rerolled Data!");
            Console.WriteLine($"S1 ==> {s1}");
            Console.WriteLine($"S2 ==> {s2}\n");

            //Create a custom user genetated Set
            Console.WriteLine("Generating a user defined 3 numbers set: ");
            Set s3 = new Set(
                RequestNumber("Plase enter the first number: "), 
                RequestNumber("Plase enter the second number: "), 
                RequestNumber("Plase enter the third number: ")
                );

            //Check if s3 is a subset of one of the sets
            Console.WriteLine($"\nChecking if the user's set is a subset of S1 or S2...");
            if (s1.Subset(s3))
            {
                Console.WriteLine($"The user's set ==> {s3}\nis a subset of S1 ==> {s1}");
            }
            else
            {
                Console.WriteLine($"The user's set ==> {s3}\nis not a subset of S1 ==> {s1}");
            }
            if (s2.Subset(s3))
            {
                Console.WriteLine($"The user's set ==> {s3}\nis a subset of S2 ==> {s2}");
            }
            else
            {
                Console.WriteLine($"The user's set ==> {s3}\nis not a subset of S2 ==> {s2}");
            }

            //spacing
            Console.WriteLine();

            //check if a user input is a member of either set (s1,s2)
            int num = RequestNumber("Please enter a number to see if it's a member of S1/S2: ");
            Console.WriteLine($"Is {num} a member of S1: {s1.IsMember(num)}");
            Console.WriteLine($"Is {num} a member of S2: {s2.IsMember(num)}\n");

            //Insert a user input to s1 and s2
            num = RequestNumber("Plase enter a number to insert to s1 and s2: ");
            s1.Insert(num);
            s2.Insert(num);
            Console.WriteLine("Updated Sets Data: ");
            Console.WriteLine($"S1 ==> {s1}");
            Console.WriteLine($"S2 ==> {s2}\n");

            //Delete a user input from s1 and s2
            num = RequestNumber("Plase enter a number to delete from s1 and s2: ");
            s1.Delete(num);
            s2.Delete(num);
            Console.WriteLine("Updated Sets Data: ");
            Console.WriteLine($"S1 ==> {s1}");
            Console.WriteLine($"S2 ==> {s2}\n");
        }
    }
}