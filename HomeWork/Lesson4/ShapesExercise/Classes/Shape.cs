using System;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesExercise.Classes
{
    abstract class Shape
    {
        //the X/Y position of the shape (can also be a simple x and y vars)
        private Point _centerPoint;
        public Point CenterPoint
        {
            get { return _centerPoint; }
            protected set { _centerPoint = value; }
        }

        public Shape(Point centerPoint)
        {
            CenterPoint = centerPoint;
        }

        //there is no default way of resizing a shape.
        public abstract void Resize(double precentage);

        //all of the shapes move in the same way so we can define it here
        public void Move(double distanceX, double distanceY = 0)
        {
            _centerPoint.X +=  distanceX;
            _centerPoint.Y += distanceY;
        }

        public virtual string Print()
        {
            return $"I am a {GetType().Name}\nThe X and Y position ({CenterPoint.X},{CenterPoint.Y})";
        }
    }
}
