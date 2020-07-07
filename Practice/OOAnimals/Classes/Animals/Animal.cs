using System;
using OOAnimals.Enums;
using OOAnimals.Structs;

namespace OOAnimals.Classes.Animals
{
    //the base class of all animals (abstract)
    public abstract class Animal
    {
        //name of the animal
        public string Name { get; private set; }

        //age of the animal
        public int Age { get; private set; }
        
        //movement speed of the animal
        public int Speed { get; private set; } 

        //weight of the animal
        public double Weight { get; private set; }

        //the animal's gender
        public Gender Gender { get; private set; }

        //the (X,Y) position for that animal
        public Position MyPosition { get; protected set; }

        //full constructor
        public Animal(string name, int age, int speed, double weight, Gender gender, Position myPosition)
        {
            Name = name;
            Age = age;
            Speed = (speed <= 0) ? 1 : speed;
            Weight = weight;
            Gender = gender;
            MyPosition = myPosition;
        }

        //move the animal based on her speed
        public abstract void Move(int deltaX, int deltaY);
        public abstract string WayOfMoving();

        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}, Weight: {Weight}, Speed: {Speed}, Gender: {Gender}, Position: {MyPosition}";
        }
    }
}
