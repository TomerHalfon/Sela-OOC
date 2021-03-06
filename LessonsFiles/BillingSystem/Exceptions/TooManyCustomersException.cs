﻿//Docs: 
//Exception Class: https://docs.microsoft.com/en-us/dotnet/api/system.exception?view=netframework-4.7.2
using System;

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
