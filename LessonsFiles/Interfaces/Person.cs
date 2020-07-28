using System;

namespace Interfaces
{
    /*
     * person is an animal but also is implementing 2 interfaces.
     * a class can inherit only one class, but can implement as many interfaces as it wants
     */
    class Person : Animal, IMoveable, IJumpable
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

        public void Move()
        {
            Console.WriteLine("Moving");
        }

        public override void TakeBreath()
        {
            Console.WriteLine("taking a breath");
        }
    }
}
