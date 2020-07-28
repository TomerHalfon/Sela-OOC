using BillingSystemExc.Classes;
using BillingSystemExc.Exceptions;
using System;

namespace BillingSystemExc
{
    class Program
    {
        const double amountToAdd = 100;
        static void Main()
        {
            //create a new billing system
            BillingSystem billingSystem = new BillingSystem(2);

            //create some customers
            RegularCustomer regularCustomer1 = new RegularCustomer("Customer1");
            RegularCustomer regularCustomer2 = new RegularCustomer("Customer2",100.5);
            VIPCustomer vIPCustomer1 = new VIPCustomer("Customer3");
            VIPCustomer vIPCustomer2 = new VIPCustomer("Customer4",1000);

            ////we can't create a Customer class instance
            //Customer customer = new Customer("Customer5");

            //Add Customers to the billing system
            //would be better to add an overload taking parmas array
            try
            {
                Console.WriteLine($"adding 4 customers");
                billingSystem.AddCustomer(regularCustomer1);
                billingSystem.AddCustomer(regularCustomer2);
                billingSystem.AddCustomer(vIPCustomer1);
                billingSystem.AddCustomer(vIPCustomer2);
            }
            catch (TooManyCustomersException e)
            {
                Console.WriteLine($"Max customers reached: {e.MaxCustomersAllowed}");
            }

            //print the system before change
            Console.WriteLine(billingSystem);

            //Calling the UpdateBalane
            billingSystem.UpdateBalance(amountToAdd);
            Console.WriteLine($"Adding {amountToAdd} to all Customers\nVip should get 80% of the amount: {amountToAdd * 0.8}\nAnd Regular customers should get 100%\n");

            //print the system after change
            Console.WriteLine(billingSystem);

            try
            {
                Console.WriteLine(billingSystem[2, "Customer1"]);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"Argument Exception !: {e.Message}");
            }
            billingSystem.Sort();
        }
    }
}
