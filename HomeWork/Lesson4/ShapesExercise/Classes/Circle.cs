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
        //a const with the name of the shape(to avoid hard coding data)
        const string name = "Circle";
        
        //The radius of the circle (acn't be lower than 1)
        private double _radius;
        public double Radius
        {
            get { return _radius; }
            private set { _radius = Math.Max(value, 1); }
        }
        public Circle(Point position, double radius) : base(position, name)
        {
            Radius = radius;
        }

        // a draw function to draw the shape, we must implemant it (abstract)
        public override string Draw()
        {
            StringBuilder sb = new StringBuilder();
            double thickness = 0.5;
            double rIn = Radius - thickness, rOut = Radius + thickness;
            for (double y = Radius; y >= -Radius; --y)
            {
                for (double x = -Radius; x < rOut; x += 0.5) 
                {
                    double value = x * x + y * y;
                    if (value >= rIn * rIn && value <= rOut * rOut) 
                    {
                        sb.Append("*");
                    }
                    else
                    {
                        sb.Append(" ");
                    }
                }
                sb.Append("\n");
            }
            return sb.ToString();
        }

        public override void Resize(double precentage)
        {
            Radius *= 1 + precentage;
        }
        public override string Print()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.Print());
            sb.AppendLine($"It's Radius is {Radius}");
            return sb.ToString();
        }
    }
}
