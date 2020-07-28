using System;
using System.Collections;
using BillingSystemExc.Classes;

namespace BillingSystemExc.Comparators
{
    class CompareCustomerByBalance : IComparer
    {
        public int Compare(object x, object y)
        {
            if (x is Customer customerX && y is Customer customerY)
            {
                return customerX.Balance.CompareTo(customerY.Balance);
            }
            throw new ArgumentException($"{x.GetType()} is not of type {y.GetType()}");
        }
    }
}
