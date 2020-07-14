using System;

namespace PersonClassExc
{
    class Program
    {
        static void Main()
        {
            //create person with full constructor
            Person person1 = new Person("Person1", 27);
            Person person2 = new Person("Person2", 26);

            //create person with only one parameter (age defaults to 30)
            Person person3 = new Person("Person3");

            //Print the People
            Console.WriteLine(person1);
            Console.WriteLine(person2);
            Console.WriteLine(person3);
            Console.WriteLine();

            //equal override
            Console.WriteLine($"Are person1 and person2 equal?\n(do they share the same name and age): {person1.Equals(person2)}\n");

            //check if person is of type Person using GetType()
            Console.WriteLine($"is person of type Person? {person1.GetType() == typeof(Person)}\n");

            //print how many instances of Class Person were created using the static property
            //(notice we can only get the value, we can't change it from outside of the class)
            Console.WriteLine($"We created {Person.PersonCount} diffrent instances of class Person");
        }
    }
}