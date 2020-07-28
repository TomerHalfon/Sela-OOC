//Docs: 
// Interface: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/interfaces

using System.Collections.Generic;

namespace Interfaces
{
    class Program
    {
        static void Main()
        {
            List<Animal> animals = new List<Animal>
            {
                new Person("Person", 20),
                new Dog(5, 20)
            };

            foreach (Animal animal in animals)
            {
                animal.Talk();
                animal.TakeBreath();
            }
            List<IJumpable> jumpables = new List<IJumpable>
            {
                new Person("Person", 20),
                new Dog(5, 20)
            };

            foreach (IJumpable jumpable in jumpables)
            {
                jumpable.Jump(10);
            }

            List<IMoveable> moveables = new List<IMoveable>
            {
                new Person("Person", 20),
                new Dog(5, 20)
            };
            foreach (IMoveable moveable in moveables)
            {
                moveable.Move();
            }
        }
    }
}
