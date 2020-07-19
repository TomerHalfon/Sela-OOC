using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ShapesExercise.Classes
{
    class Rectangle : Shape
    {
        //a const with the name of the shape(to avoid hard coding data)
        const string name = "Rectangle";

        //the width and the height can't be 0 or negative so will use full properties
        private double _width;
        private double _height;

        public double Width
        {
            get { return _width; }
            private set 
            {
                _width = Math.Max(value, 1);
            }
        }
        public double Height
        {
            get { return _height; }
            private set
            {
                _height = Math.Max(value, 1);
            }
        }

        public Rectangle(Point position, double widht, double height) : base(position, name)
        {
            Width = widht;
            Height = height;
        }

        // a draw function to draw the shape, we must implemant it (abstract)
        public override string Draw()
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

        //resize the shape by a parameter precentage
        public override void Resize(double precentage)
        {
            Width *= 1 + precentage;
            Height *= 1 + precentage;
        }

        //will use the base print but add to it the rectangle specific data
        public override string Print()
        {
            return $"{base.Print()}\nIt's Width is: {Width}, and it's Height is: {Height}";
        }
    }
}
