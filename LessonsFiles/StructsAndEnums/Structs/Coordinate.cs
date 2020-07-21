//Relevant Docs, Struct: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/struct

namespace StructsAndEnums.Structs
{
    //Struct is a small size value type. (up to 16 bytes)
    //it inherits ValueType which inherits Object.
    //it saves the data in the stack and not in the Heap
    //it can't inherit or be inherited
    //you can't define it's empty constructor, the empty constructor exist and it will allways set every field to it's default value
    struct Coordinate
    {
        private double _x;
        private double _y;

        //here we call the empty constructor to assign default values, and than using the properties we assign the parameters
        public Coordinate(double x, double y) : this()
        {
            X = x;
            Y = y;
        }

        public double X
        {
            get { return _x; }
            set { _x = value; }
        }

        public double Y
        {
            get { return _y; }
            set { _y = value; }
        }

        public override string ToString()
        {
            return $"({X},{Y})";
        }
    }
}
