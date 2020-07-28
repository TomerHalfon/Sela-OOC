//Docs: 
// Icomparer<T>(Generic): https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.icomparer-1?view=netcore-3.1
using System.Collections.Generic;
using BillingSystemExc.Classes;

namespace BillingSystemExc.Comparators
{
    class CompareCustomerByBalanceGeneric : IComparer<Customer>
    {
        //The generic Icomparer lets us 'skip' the type check, because we can only get a specific type as a parameter, Customer in this case
        public int Compare(Customer x, Customer y)
        {
            return x.Balance.CompareTo(y.Balance);
        }
    }
}