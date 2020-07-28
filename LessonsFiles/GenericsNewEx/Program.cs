using System;

namespace GenericsNewEx
{
    class Program
    {
        static void Main()
        {
            Person p1 = new Person("John", 22, 10000);
            Person p2 = new Person("Albert", 42, 5000);
            Person p3 = new Person("Zvi", 20, 2000);
            Console.WriteLine(p1);

        }
    }
}
