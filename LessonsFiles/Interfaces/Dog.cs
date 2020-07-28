using System;

namespace Interfaces
{
    class Dog: Animal, IMoveable, IJumpable
    {
        public Dog(int tailSize, int age)
        {
            TailSize = tailSize;
            base.age = age;
        }

        public int TailSize { get; set; }

        public void Jump(int height)
        {
            Console.WriteLine($"jumping to {height}");
        }

        public void Move()
        {
            Console.WriteLine("Moving");
        }

        public override void TakeBreath()
        {
            Console.WriteLine("Taking a breath");
        }
    }
}
