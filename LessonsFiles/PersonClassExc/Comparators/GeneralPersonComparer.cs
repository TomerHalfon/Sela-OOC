using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonClassExc.Comparators
{
    enum PersonCompareMethod
    {
        ByName,
        ByAge,
        ById,
        ByBalance,
        ByBirthMonth
    }
    class GeneralPersonComparer : IComparer<Person>
    {
        private PersonCompareMethod _criteria;

        public GeneralPersonComparer(PersonCompareMethod criteria)
        {
            _criteria = criteria;
        }

        public int Compare(Person x, Person y)
        {
            switch (_criteria)
            {
                case PersonCompareMethod.ByName:
                    return x.Name.CompareTo(y.Name);
                    
                case PersonCompareMethod.ByAge:
                    return x.Age - y.Age;
                    
                case PersonCompareMethod.ById:
                    return x.Id - y.Id;
                    
                case PersonCompareMethod.ByBalance:
                    return x.Balance.CompareTo(y.Balance);

                case PersonCompareMethod.ByBirthMonth:
                    return x.BirthMonth.CompareTo(y.BirthMonth);
            }
            return x.CompareTo(y);
        }
    }
}
