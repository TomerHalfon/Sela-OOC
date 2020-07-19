using BillingSystemExc.Classes;
using System;

namespace BillingSystemExc
{
    class Program
    {
        static void Main()
        {
            Customer c1 = new Customer("P1");
            Customer c2 = new Customer("P2", 100d);
            Customer c3 = new Customer("P2", 100d);
            BillingSystem billingSystem = new BillingSystem(2);
            billingSystem.AddCustomer(c1);
            billingSystem.AddCustomer(c2);
            billingSystem.AddCustomer(c3);
            Console.Write(billingSystem);
            
        }
    }
}
