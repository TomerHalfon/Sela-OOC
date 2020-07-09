using System;

namespace PersonClassExc
{
    class Program
    {
        static void Main()
        {
            //person use
            Person perosn = new Person("Tomer", 27);
            Console.WriteLine(perosn);

            //equal override
            Person person2 = new Person("Tomer", 26);
            Console.WriteLine(perosn.Equals(person2));
        }
    }
}