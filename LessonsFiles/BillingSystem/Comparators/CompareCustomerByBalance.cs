using System;
using System.Collections;
using System.Collections.Generic;
using BillingSystemExc.Classes;

namespace BillingSystemExc.Comparators
{
    class CompareCustomerByBalance : IComparer//, IComparer<Customer>
    {
        public int Compare(object x, object y)
        {
            if (x is Customer customerX && y is Customer customerY)
            {
                return customerX.Balance.CompareTo(customerY.Balance);
            }
            throw new ArgumentException($"{x.GetType()} is not of type {y.GetType()}");
        }
        ////The generic Icomparer lets us 'skip' the type check, because we can only get a customer as a parameter
        //public int Compare(Customer x, Customer y)
        //{
        //    return x.Balance.CompareTo(y.Balance);
        //}
    }
}
