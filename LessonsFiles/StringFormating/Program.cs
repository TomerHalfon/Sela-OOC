// The relevant documentation
//String format method:  https://docs.microsoft.com/en-us/dotnet/api/system.string.format?view=netcore-3.1
//culture info class: https://docs.microsoft.com/en-us/dotnet/api/system.globalization.cultureinfo?view=netcore-3.1
using System;
using System.Globalization;
using System.Threading;
namespace StringFormating
{
    class Program
    {
        static void Main()
        {
            //culture and formating
            //create a us culture
            CultureInfo usCulture = new CultureInfo("en-US");

            //set current culture to us
            Thread.CurrentThread.CurrentCulture = usCulture;

            //request name
            Console.Write("Please enter emplyee name: ");
            string name = usCulture.TextInfo.ToTitleCase(Console.ReadLine());
            while (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("invalid input!, try again");
                name = usCulture.TextInfo.ToTitleCase(Console.ReadLine());
            }

            //request salary
            double salary;
            Console.Write("Please enter {0}'s salary: ", name);
            while (!double.TryParse(Console.ReadLine(), out salary))
            {
                Console.WriteLine("invalid input!, try again");
            }

            //format and print
            Console.WriteLine("Employee name {0}, Salary {1:C}", name, salary);
        }
    }
}
