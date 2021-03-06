﻿namespace GenericsNewEx
{
   public class Person
    {
        public Person(string name, int age, int salary)
        {
            Name = name;
            Age = age;
            Salary = salary;
        }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public int Salary { get; private set; }
        public override string ToString()
        {
            return "Name: " + Name + " Age: " + Age + " Salary: " + Salary;
        }
    }
}
