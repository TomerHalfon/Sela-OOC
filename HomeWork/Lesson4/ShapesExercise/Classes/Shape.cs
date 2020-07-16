using System;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesExercise.Classes
{
    abstract class Shape
    {
        // a string representation of the shape
        public string Name { get; private set; }

        //the X/Y position of the shape (can also be a simple x and y vars)
        private Point _position;
        public Point Position
        {
            get { return _position; }
            protected set { _position = value; }
        }

        public Shape(Point position,string name)
        {
            Position = position;
            Name = name;
        }

        public abstract void Resize(double precentage);
        public abstract string Draw();
        public virtual string Print()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The Shape is a {Name}");
            sb.AppendLine(Draw());
            sb.AppendLine(ToString());
            return sb.ToString();
        }
        public virtual void Move(double distanceX, double distanceY = 0)
        {
            _position.X +=  distanceX;
            _position.Y += distanceY;
        }
        public override string ToString()
        {
            return $"The {Name} is located at: ({Position})";
        }
    }
}
