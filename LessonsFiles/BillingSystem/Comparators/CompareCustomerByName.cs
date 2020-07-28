﻿//Docs: 
// Icomparer: https://docs.microsoft.com/en-us/dotnet/api/system.collections.icomparer?view=netcore-3.1
using System;
using System.Collections;
using BillingSystemExc.Classes;

namespace BillingSystemExc.Comparators
{
    class CompareCustomerByName : IComparer//,IComparer<Customer>
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