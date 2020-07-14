using BillingSystem.Classes;
using System;

namespace BillingSystem
{
    class Program
    {
        static void Main()
        {
            Customer c1 = new Customer("P1");
            Customer c2 = new Customer("P2", 100d);

            Console.WriteLine(c1);
            Console.WriteLine(c2);
            Console.WriteLine(Customer.CustomerCount);
        }
    }
}
