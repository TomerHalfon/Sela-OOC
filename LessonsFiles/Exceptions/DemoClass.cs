using System;

namespace Exceptions
{
    class DemoClass
    {
        int[] array;
        public int this[int index]
        {
            get
            {
                if (!IsInRange(index))
                {
                    //if out of range throw 
                    throw new IndexOutOfRangeException($"{index} is not in range");
                }
                return array[index];
            }
            set
            {
                if (!IsInRange(index))
                {
                    //if out of range throw 
                    throw new IndexOutOfRangeException($"{index} is not in range");
                }
                if (value == index)
                {
                    throw new IndexEqualsDataException(index,value);
                }
                array[index] = value;

            }
        }
        public DemoClass(int size)
        {
            array = new int[size];
        }
        bool IsInRange(int index)
        {
            return index >= 0 && index < array.Length;
        }
    }
}
