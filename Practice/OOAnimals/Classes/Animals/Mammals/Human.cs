using OOAnimals.Enums;
using OOAnimals.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOAnimals.Classes.Animals.Mammals
{
    public class Human : Mammal
    {
        const int speed = 10;
        public Human(string name, int age, double weight, Gender gender, Position myPosition, int birthMonths) : base(name, age, speed, weight, gender, myPosition, birthMonths)
        {
        }
        public override string WayOfMoving()
        {
            return $"Walking";
        }
    }
}
