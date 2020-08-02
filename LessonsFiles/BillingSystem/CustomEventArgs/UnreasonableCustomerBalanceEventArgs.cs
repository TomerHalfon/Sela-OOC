using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystemExc.CustomEventArgs
{
   class UnreasonableCustomerBalanceEventArgs:EventArgs
    {
        public UnreasonableCustomerBalanceEventArgs(double balance)
        {
            Balance = balance;
        }

        public double Balance { get; }
    }
}
