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
        public int X;
        //Y poition
        public int Y;

        //constructor with parameters
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }
        
        //print data
        public override string ToString()
        {
            return $"({X},{Y})";
        }

        //returns a new position (X and Y) based on individual deltas
        public Position Move(int deltaX, int deltaY)
        {
            return new Position(X+deltaX, Y+deltaY);
        }

        //returns a new position (X and Y) based on a shared delata
        public Position Move(int delta)
        {
            return new Position(X + delta, Y + delta);
        }
    }
}
