/* Relevant Docs:
 * Struct: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/struct
 * Enum: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/enum
 */

using StructsAndEnums.Enums;
using System;

namespace StructsAndEnums
{
    class Program
    {
        static string IsWeekEnd (WeekDays day)
        {
            string res = "WEEK DAY";
            switch (day)
            {
                case WeekDays.Friday:
                case WeekDays.Saturday:
                    res = "WEEKEND!!!";
                    break;
            }
            return res;
        }
        static void Main()
        {
            //Enums

            //will return a string array containing all of the names of the months
            string[] months = Enum.GetNames(typeof(Months));
            foreach (string month in months)
            {
                Console.WriteLine($"Month: {month}");
            }

            Console.WriteLine("\nEnter a month as shown above");
            try
            {
                //will convert (parse) a string to an Enum
                Months usersMonth = (Months)Enum.Parse(typeof(Months), Console.ReadLine());
                Console.WriteLine($"Sucsess! {usersMonth}");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("failed to parse");
            }

            //class exercise
            string[] weekDays = Enum.GetNames(typeof(WeekDays));
            Console.WriteLine("\nWeekDays\n");
            foreach (string day in weekDays)
            {
                Console.WriteLine($"Day: {day}");
            }

            Console.WriteLine("\nEnter a day as shown above");
            WeekDays userDay;
            try
            {
                userDay = (WeekDays)Enum.Parse(typeof(WeekDays), Console.ReadLine());
            }
            catch (ArgumentException)
            {
                Console.WriteLine("failed to parse defaulted to Sunday");
                userDay = WeekDays.Sunday;
            }
            Console.WriteLine(IsWeekEnd(userDay));
        }
    }
}
