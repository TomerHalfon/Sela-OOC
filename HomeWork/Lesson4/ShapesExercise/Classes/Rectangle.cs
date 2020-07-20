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

        public Rectangle(Point position, double widht, double height) : base(position)
        {
            Width = widht;
            Height = height;
        }
        //resize the shape by a parameter precentage
        public override void Resize(double precentage)
        {
            Width *= (100 + precentage) / 100;
            Height *= (100 + precentage) / 100;
        }
        public override string Print()
        {
            return $"{base.Print()}\nThe Width is {Width} and the Height is {Height}";
        }
    }
}
