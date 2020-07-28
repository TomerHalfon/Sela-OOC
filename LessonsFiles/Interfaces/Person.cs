using System;

namespace Interfaces
{
    /*
     * person is an animal but also is implementing 2 interfaces.
     * a class can inherit only one class, but can implement as many interfaces as it wants
     * an interface can be implemented by default or Explicitely
     */
    class Person : Animal, IMoveable, IJumpable, ISwimable
    {
        public Person(string name, int age)
        {
            Name = name;
            base.age = age;
        }

        public string Name { get; set; }

        public void Jump(int height)
        {
            Console.WriteLine($"jumping to {height}");
        }

        public override void TakeBreath()
        {
            Console.WriteLine("taking a breath");
        }

        void IMoveable.Move()
        {
            Console.WriteLine("Moving");
        }

        void ISwimable.Move()
        {
            Console.WriteLine("Swimming");
        }
        public void Move()
        {
            Console.WriteLine("default Move");
        }
    }
}
