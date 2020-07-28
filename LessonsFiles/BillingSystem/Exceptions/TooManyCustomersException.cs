using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystemExc.Exceptions
{
    public class TooManyCustomersException : Exception
    {
        public TooManyCustomersException() { }
        public TooManyCustomersException(string message) : base(message) { }
        public TooManyCustomersException(string message, Exception inner) : base(message, inner) { }

        public TooManyCustomersException(int max) { MaxCustomersAllowed = max; }
        public TooManyCustomersException(string message, int max) : base(message) { MaxCustomersAllowed = max; }
        public int MaxCustomersAllowed { get; }
    }

}
