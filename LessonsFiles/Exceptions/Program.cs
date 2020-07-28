//Docs: 
//Exception Class: https://docs.microsoft.com/en-us/dotnet/api/system.exception?view=netframework-4.7.2
//Try Catch finally: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/try-catch-finally
//a list of Exceptions: https://powershellexplained.com/2017-04-07-all-dotnet-exception-list/#systemioinvaliddataexception

using System;

namespace Exceptions
{
    class Program
    {
        //request a number
        static int GetNumberFromUser(string msg)
        {
            int num;
            do
            {
                Console.Write(msg);
            } while (!int.TryParse(Console.ReadLine(), out num));
            return num;
        }
        static void Main()
        {
            DemoClass demoClass = new DemoClass(10);
            char res = 'Y';
            while (res == 'Y')
            {
                try
                {
                    //the try block wil run until it incounters an exception
                    int i = GetNumberFromUser("Index: ");
                    demoClass[i] = GetNumberFromUser("Number: ");
                }
                //when an exception has been thrown the catch blocks will catch it

                catch (IndexEqualsDataException e)
                {
                    //when a spesific IndexEqualsDataException exception 
                    Console.WriteLine($"IndexEqualsDataException! : {e} ");
                }
                catch (Exception e)
                {
                    //when any exception has been thrown and hasn't been captured yet
                    Console.WriteLine($"IndexOutOfRangeException! : {e} ");
                }
                finally
                {
                    //after entering a try this will allways run
                    char temp;
                    do
                    {
                        Console.Write("Again?: ");
                    } while (!char.TryParse(Console.ReadLine(), out temp));
                    res = char.ToUpper(temp);
                }
            }
        }
    }
}