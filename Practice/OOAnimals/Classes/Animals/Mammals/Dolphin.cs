using OOAnimals.Enums;
using OOAnimals.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOAnimals.Classes.Animals.Mammals
{
    public class Dolphin: Mammal
    {
        public int TailLength { get; set; }

        const int speed = 20;

        public Dolphin(string name, int age, double weight, Gender gender, Position myPosition, int birthMonths, int tailLength) :
           base(name, age, speed, weight, gender, myPosition, birthMonths)
        {
            TailLength = tailLength;
        }
        public override string ToString()
        {
            return $"{base.ToString()}, TailLength: {TailLength}";
        }
        public override string WayOfMoving()
        {
            return $"Swimming";
        }
    }
}
