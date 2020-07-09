using System;
using System.Globalization;
using System.Threading;

namespace PersonClassExc
{
    class Program
    {
        static void Main(string[] args)
        {
            //person use
            Person perosn = new Person("Tomer", 27);
            Console.WriteLine(perosn);


            //format exercise
            //request a name
            Console.Write("Please enter emplyee name: ");
            string name = Console.ReadLine();

            //request salary
            Console.Write("Please enter {0} salary: ",name);
            double salary = double.Parse(Console.ReadLine());

            //set culture to us
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

            //format and print
            Console.WriteLine("Employee nane {0}, Salary {1:C}",name,salary);
        }
    }
}
