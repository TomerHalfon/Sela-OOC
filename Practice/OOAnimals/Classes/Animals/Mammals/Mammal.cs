using OOAnimals.Enums;
using OOAnimals.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOAnimals.Classes.Animals.Mammals
{
    //the base class for all mammlals
    public abstract class Mammal : Animal
    {
        //how long it takes the give birth (in months)
        public int BirthMonths { get; set; }
        public Mammal(string name, int age, int speed, double weight, Gender gender, Position myPosition, int birthMonths) : base(name, age, speed, weight, gender, myPosition)
        {
            BirthMonths = birthMonths;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, BirthMonths: {BirthMonths}";
        }

        //move the animal
        public override void Move(int deltaX, int deltaY)
        {
          MyPosition = MyPosition.Move(deltaX + Speed, deltaY + Speed);
        }
    }
}
