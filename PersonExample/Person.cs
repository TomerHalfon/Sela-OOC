using System;
using System.Collections.Generic;
using System.Text;

namespace PersonExample
{
    class Person
    {
        public int Age { get; set; }
        public string Name { get; set; }

        public Person(int age, string name)
        {
            Age = age;
            Name = name;
        }

        public override string ToString()
        {
            return $"Name: {Name} Age: {Age}";
        }
    }
}
