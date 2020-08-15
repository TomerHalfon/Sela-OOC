using System;

namespace HangMan.Library
{
    /// <summary>
    /// Flags is basically a bool array, the reason that it's in a separate class is to allow for code reusability, both Guesses and Word use this.
    /// can I skip all of this and just use an array where needed, yea :( ,  but this way I only need to write it once
    /// </summary>
    class Flags
    {
        readonly bool[] _flagsArray;

        internal bool this[int index]
        {
            get
            {
                if (IsInRange(index))
                {
                    return _flagsArray[index];
                }
                else
                {
                    throw new IndexOutOfRangeException($"{index}: out of range max: {_flagsArray.Length - 1}");
                }
            }
            set
            {
                if (IsInRange(index))
                {
                    _flagsArray[index] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException($"{index}: out of range max: {_flagsArray.Length - 1}");
                }
            }
        }

        internal int Length { get { return _flagsArray.Length; } }

        internal Flags(int size)
        {
            _flagsArray = new bool[size];
        }

        bool IsInRange(int index)
        {
            return index >= 0 && index < _flagsArray.Length;
        }
    }
}