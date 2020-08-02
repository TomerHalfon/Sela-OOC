using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystemExc.Classes
{
    class AccountingClerk
    {
        public void OnUnreasonableCustomerBalance(Customer customer, CustomEventArgs.UnreasonableCustomerBalanceEventArgs e)
        {
            Console.WriteLine($"AccountingClerk is telling the CFO about {customer.Name}, it's balance is {e.Balance}...");
        }
    }

}
