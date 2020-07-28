using System.Text;

namespace Sets
{
    class Set
    {
        //represent the maximum range (the last index of the boolean array)
        const int TopRange = 1000;

        //a private boolean array as requested
        private bool[] _array;

        //an empty constructor will initialize the array
        public Set()
        {
            _array = new bool[TopRange + 1];
        }

        //constructor with parmas, first it will go to the empty constructor(where it will initialize the array)
        //than it will execute the logic in the block
        public Set(params int[] numbers) : this()
        {
            foreach (int num in numbers)
            {
                if (IsInRange(num))
                {
                    _array[num] = true;
                }
            }
        }

        //Union combines two sets without duplicates [since we are using a boolean array, each number(index) can appear only once]
        public void Union(Set set)
        {
            for (int i = 0; i < _array.Length; i++)
            {
                _array[i] = set._array[i] || _array[i];
            }
        }

        //Intersect will change the set to only having the shared data with the parameter Set
        public void Intersect(Set set)
        {
            for (int i = 0; i < _array.Length; i++)
            {
                _array[i] = set._array[i] && _array[i];
            }
        }

        //Subset will return true if a set contains all of the numbers from the parameter set
        //an empty set, is a subset off all other sets
        public bool Subset(Set set)
        {
            for (int i = 0; i < _array.Length; i++)
            {
                if (set._array[i] && !_array[i])
                {
                    return false;
                }
            }
            return true;
        }

        //IsMember will return true if the parameter is in the set
        public bool IsMember(int num)
        {
            return IsInRange(num) && _array[num];
        }

        //Insert will add a number to the set
        public void Insert(int num)
        {
            if (IsInRange(num))
            {
                _array[num] = true;
            }
        }

        //Delete will remove the parameter number from the set
        public void Delete(int num)
        {
            if (IsInRange(num))
            {
                _array[num] = false;
            }
        }

        //Will return a string of the set
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < _array.Length; i++)
            {
                if (_array[i])
                {
                    sb.Append($"{i} ");
                }
            }
            return sb.ToString();
        }

        //compares two sets to see if they share the exact same Data
        public override bool Equals(object obj)
        {
            //reflect to see if obj can be downcasted to Set
            if (obj.GetType() == typeof(Set))
            {
                Set temp = (Set)obj;
                for (int i = 0; i < _array.Length; i++)
                {
                    if (temp._array[i] != _array[i])
                    {
                        return false;
                    }
                }
            }
            //if the two objects are not of the same type, they aren't comparable therefore will return false
            else
            {
                return false;
            }

            return true;
        }

        //a simple boolean function to avoid coding the same line multiple times
        private bool IsInRange(int num)
        {
            return num >= 0 && num <= TopRange;
        }
    }
}