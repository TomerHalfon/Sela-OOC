using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ShapesExercise.Classes
{
    class Circle : Shape
    {
        //The radius of the circle (acn't be lower than 1)
        private double _radius;
        public double Radius
        {
            get { return _radius; }
            private set { _radius = Math.Max(value, 1); }
        }
        public Circle(Point position, double radius) : base(position)
        {
            Radius = radius;
        }
        public override void Resize(double precentage)
        {
            Radius *= (100 + precentage) / 100;
        }
        public override string Print()
        {
            return $"{base.Print()}\nThe Radius is {Radius}";
        }
    }
}
