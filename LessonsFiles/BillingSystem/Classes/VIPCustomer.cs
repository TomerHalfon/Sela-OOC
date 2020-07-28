using BillingSystemExc.Interfaces;
using System;

namespace BillingSystemExc.Classes
{
    class VIPCustomer : Customer, IAdressable
    {
        const double amountPrecent = 0.8;
        string _adress;
        public VIPCustomer(string name, double balance) : base(name, balance)
        {
        }
        public VIPCustomer(string name) : base(name)
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

        public string GetAdress()
        {
            return $"Adress: {_adress}";
        }
    }
}
