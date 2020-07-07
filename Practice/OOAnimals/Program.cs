using System;
using OOAnimals.Enums;
using OOAnimals.Structs;
using OOAnimals.Classes.Animals;
using OOAnimals.Classes.Animals.Mammals;
using System.Collections.Generic;

namespace OOAnimals
{
    class Program
    {
        static void Main(string[] args)
        {
            //generate a list of diffrent animals
            List<Animal> animals = new List<Animal>
            {
                new Human("Tomer", 27, 70, Gender.Male, new Position(), 9),
                new Dolphin("Dolphin", 2, 130, Gender.Male, new Position(), 3, 7)
            };

            //print all the animals
            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
            Console.WriteLine("\n");

            //move the animal and tell me how it is walking
            foreach (var animal in animals)
            {
                Console.WriteLine(animal.WayOfMoving());
                animal.Move(5, 5);
            }
            Console.WriteLine("\n");

            //print the animals again
            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
