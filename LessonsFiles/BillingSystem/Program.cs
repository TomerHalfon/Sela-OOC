using BillingSystemExc.Classes;
using System;

namespace BillingSystemExc
{
    class Program
    {
        const double amountToAdd = 100;
        static void Main()
        {
            //create a new billing system
            BillingSystem billingSystem = new BillingSystem(4);

            //create some customers
            RegularCustomer regularCustomer1 = new RegularCustomer("Customer1");
            RegularCustomer regularCustomer2 = new RegularCustomer("Customer2",100.5);
            VIPCustomer vIPCustomer1 = new VIPCustomer("Customer3");
            VIPCustomer vIPCustomer2 = new VIPCustomer("Customer4",1000);

            ////we canot create a Customer class instance
            //Customer customer = new Customer("Customer5");

            //Add Customers to the billing system
            //whould be better to add an overload taking parmas array
            billingSystem.AddCustomer(regularCustomer1);
            billingSystem.AddCustomer(regularCustomer2);
            billingSystem.AddCustomer(vIPCustomer1);
            billingSystem.AddCustomer(vIPCustomer2);

            //print the system before change
            Console.WriteLine(billingSystem);

            //Calling the UpdateBalane
            billingSystem.UpdateBalance(amountToAdd);
            Console.WriteLine($"Adding {amountToAdd} to all Customers\nVip should get 80% of the amount: {amountToAdd * 0.8}\nAnd Regular customers should get 100%\n");

            //print the system after change
            Console.WriteLine(billingSystem);
            
        }
    }
}
