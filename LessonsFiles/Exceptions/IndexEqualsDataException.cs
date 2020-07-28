//Docs: 
//Exception Class: https://docs.microsoft.com/en-us/dotnet/api/system.exception?view=netframework-4.7.2
using System;

namespace Exceptions
{
    public class IndexEqualsDataException : Exception
    {
        public int Index { get; }
        public int Number { get; }
        public IndexEqualsDataException() { }
        public IndexEqualsDataException(string message) : base(message) { }
        public IndexEqualsDataException(string message, Exception inner) : base(message, inner) { }
        public IndexEqualsDataException(int index, int number)
        {
            Index = index;
            Number = number;
        }
        public override string ToString()
        {
            return $"{Message}\nIndex: {Index} == Number: {Number}\n{StackTrace}";
        }

    }
}
