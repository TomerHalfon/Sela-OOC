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
            Console.WriteLine($"Telling the CFO about {customer}...");
        }
    }

}
