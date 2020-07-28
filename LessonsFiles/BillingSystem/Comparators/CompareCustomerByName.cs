using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BillingSystemExc.Classes;

namespace BillingSystemExc.Comparators
{
    class CompareCustomerByName : IComparer
    {
        public int Compare(object x, object y)
        {
            if (x is Customer customerX && y is Customer customerY)
            {
                return customerX.Name.CompareTo(customerY.Name);
            }
            throw new ArgumentException($"{x.GetType()} is not of type {y.GetType()}");
        }
    }
}
