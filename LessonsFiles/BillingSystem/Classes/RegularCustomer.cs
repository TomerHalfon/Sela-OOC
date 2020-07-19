﻿using BillingSystemExc.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystemExc.Classes
{
    class RegularCustomer : Customer
    {
        public RegularCustomer(string name, double balance) : base(name, balance)
        {
        }
        public RegularCustomer(string name):base(name)
        {
        }
        //abstract function implementation
        public override void AddToBalance(double amount)
        {
            //add the larger, 0 OR amount parameter
            Balance += Math.Max(0, amount);
        }
    }
}
