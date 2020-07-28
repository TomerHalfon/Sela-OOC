using System;

namespace CardsExc
{
    public class IllegalCardException : Exception
    {
        public IllegalCardException() { }
        public IllegalCardException(string message) : base(message) { }
        public IllegalCardException(string message, Exception inner) : base(message, inner) { }

        public IllegalCardException(int maxValue, int minValue)
        {
            MaxValue = maxValue;
            MinValue = minValue;
        }
        public IllegalCardException(string message, int maxValue, int minValue) : base(message)
        {
            MaxValue = maxValue;
            MinValue = minValue;
        }

        public int MaxValue { get;}
        public int MinValue { get;}
    }
}
