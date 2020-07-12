using System.Text;

namespace PreparingForChapter4
{
    class Rectangle
    {
        //position
        public int X { get; private set; }
        public int Y { get; private set; }
        //size
        public int Width { get; private set; }
        public int Height { get; private set; }

        //constructor
        public Rectangle(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }
        //returns the area of the rectangle
        public int Area()
        {
            return Width * Height;
        }
        //change the size to a new size
        public void Resize(int newWidth,int newHeight)
        {
            Width = newWidth;
            Height = newHeight;
        }
        //change position to a new one
        public void Move(int newX,int newY)
        {
            X = newX;
            Y = newY;
        }
        //clone a rectangle data on to this 
        public void Assign(Rectangle otherRec)
        {
            X = otherRec.X;
            Y = otherRec.Y;
            Width = otherRec.Width;
            Height = otherRec.Height;
        }
        //returns true if the area is the same
        public bool IsSizeEqual(Rectangle otherRec)
        {
            return Area() == otherRec.Area();
        }
        //returns the smaller (by area) rectangle
        public Rectangle Minimum(Rectangle otherRec)
        {
            return (Area() < otherRec.Area()) ? this : otherRec;
        }
        //print the rectangle as a string
        public override string ToString()
        {
            return $"Positioned at ({X},{Y})\n\n\n{DrawRectangle()}";
        }
        //draw the rectangle for ease of use
        private string DrawRectangle()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    sb.Append("*   ");
                }
                sb.Append("\n");
            }
            return sb.ToString();
        }
        //compare the two by width and height (ignoring position)
        public override bool Equals(object obj)
        {
            Rectangle otherRec = (Rectangle)obj;
            return Width == otherRec.Width && Height == otherRec.Height;
        }
        //returns a unique hash code based on the Equals criteria of this rectangle
        public override int GetHashCode()
        {
            double res = (Width / Height);
            return res.GetHashCode();
        }
    }
}