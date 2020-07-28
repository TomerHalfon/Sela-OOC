using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
