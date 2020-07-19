using BillingSystemExc.Classes;
using System;

namespace BillingSystemExc.Classes
{
    class VIPCustomer : Customer
    {
        const double amountPrecent = 0.8;
        public VIPCustomer(string name, double balance = 0) : base(name, balance)
        {
        }

        //abstract function implementation
        public override void AddToBalance(double amount)
        {
            Balance += Math.Max(0, amount * amountPrecent);
        }
        public override string ToString()
        {
            return $"{base.ToString()}\t*VIP*";
        }
    }
}
