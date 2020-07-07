using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOAnimals.Classes.Animals
{
    public abstract class Animals
    {
        public string Name { get; private set; }
        public int Age { get; private set; } = 0;
        public int Speed { get; private set; } = 1;
        public double Weight { get; private set; }
        public Gender Gender { get; private set; }
        public Position MyPosition { get; private set; }

        public void Move(int deltaX, int deltaY)
        {
            MyPosition.Move(deltaX, deltaY);
        }
    }
}
