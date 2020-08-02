using BillingSystemExc.Classes;
using BillingSystemExc.Comparators;
using BillingSystemExc.Exceptions;
using BillingSystemExc.Interfaces;
using System;
using System.Collections.Generic;

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
            VIPCustomer vIPCustomer1 = new VIPCustomer("Customer3","Tel-Aviv");
            VIPCustomer vIPCustomer2 = new VIPCustomer("Customer4", "Jerusalem", 1000);

            ////we can't create a Customer class instance
            //Customer customer = new Customer("Customer5");

            //Add Customers to the billing system
            //would be better to add an overload taking parmas array
            try
            {
                Console.WriteLine($"adding 4 customers");
                billingSystem.AddCustomer(regularCustomer1);
                billingSystem.AddCustomer(vIPCustomer1);
                billingSystem.AddCustomer(regularCustomer2);
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

            #region Sorting Exmp
            Console.WriteLine("Sorting Customers by default Icomparer [by Id]");
            billingSystem.Sort();
            Console.WriteLine(billingSystem);
            Console.WriteLine("Sorting Customers by a specified Icomparer [by balance]");
            billingSystem.Sort(new CompareCustomerByBalance());
            Console.WriteLine(billingSystem);
            Console.WriteLine("Sorting Customers by a specified Icomparer [by name(Generic implementation)]");
            billingSystem.Sort(new CompareCustomerByNameGeneric());
            Console.WriteLine(billingSystem); 
            #endregion

            for (int i = 0; i < billingSystem.Length; i++)
            {
                if (!(billingSystem[i] is IAdressable adressable))
                {
                    continue;
                }
                Console.WriteLine(adressable.GetAdress());
            }

            #region Exc #7
            Random rnd = new Random();

            CustomerService customerService = new CustomerService();
            billingSystem.OnUnreasonableCustomerBalance += customerService.OnUnreasonableCustomerBalance;

            AccountingClerk accountingClerk = new AccountingClerk();
            billingSystem.OnUnreasonableCustomerBalance += accountingClerk.OnUnreasonableCustomerBalance;

            billingSystem.DoToAllCustomers(c => { c.AddToBalance(rnd.Next(2000001)); }); 
            #endregion
        }
    }
}