using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOAnimals.Structs
{
    //Position - is a point (x,y) that has the ability to move 
    public struct Position
    {
        //X position
        public int X { get; set; }
        //Y poition
        public int Y { get; set; }

        //constructor with parameters
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        //updates the parameters of the position (X and Y) based on individual deltas
        public void Move(int deltaX, int deltaY)
        {
            X += deltaX;
            Y += deltaY;
        }

        //updates the parameters of the position (X and Y) based on a shared delata
        public void Move(int delta)
        {
            X += delta;
            Y += delta;
        }
    }
}
