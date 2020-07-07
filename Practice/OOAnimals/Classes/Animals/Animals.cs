using System;
using OOAnimals.Enums;
using OOAnimals.Structs;

namespace OOAnimals.Classes.Animals
{
    //the base class of all animals (abstract)
    public abstract class Animals
    {
        //name of the animal(per instance not per class)
        public string Name { get; private set; }

        //age of the animal, defaults to 0(new born)
        public int Age { get; private set; } = 0;
        
        //movement speed of the animal, defaults to 1
        public int Speed { get; private set; } = 1;

        //weight of the animal
        public double Weight { get; private set; }

        //the animal's gender
        public Gender Gender { get; private set; }

        //the (X,Y) position for that animal
        public Position MyPosition { get; private set; }

        //move the animal based on her speed
        public void Move()
        {
            MyPosition.Move(Speed);
        }
    }
}
