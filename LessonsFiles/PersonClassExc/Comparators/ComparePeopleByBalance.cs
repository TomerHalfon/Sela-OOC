using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonClassExc.Comparators
{
    class ComparePeopleByBalance : IComparer<Person>
    {
        //The Generic Compare (it's much easier this way)
        public int Compare(Person x, Person y)
        {
            return y.Balance.CompareTo(x.Balance);
        }
    }
}
