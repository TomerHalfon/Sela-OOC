using PersonClassExc.Enums;
using PersonClassExc.Comparators;
using System;

namespace PersonClassExc
{
    class Program
    {
        static void Main()
        {
            //create person with full constructor
            Person person1 = new Person("Person1", Months.April,100, 27);
            Person person2 = new Person("Person2", Months.September, 500, 26);

            //create person without inserting an age (age defaults to 30)
            Person person3 = new Person("Person1", Months.November, 20);
            Person person4 = new Person("Person1", Months.April, 1);
            //Print the People
            Console.WriteLine(person1);
            Console.WriteLine(person2);
            Console.WriteLine(person3);
            Console.WriteLine(person4);
            Console.WriteLine();

            //equal override
            Console.WriteLine($"Are person1 and person2 equal?\n(do they share the same name and age): {person1.Equals(person2)}\n");

            //check if person is of type Person using GetType()
            Console.WriteLine($"is person of type Person? {person1.GetType() == typeof(Person)}\n");

            //print how many instances of Class Person were created using the static property
            //(notice we can only get the value, we can't change it from outside of the class)
            Console.WriteLine($"We created {Person.PersonCount} diffrent instances of class Person");

            //using IComperable
            Console.WriteLine("\nSorting all of the people above...");
            Person[] people = new Person[] { person1, person2, person3, person4 };
            Array.Sort(people);
            foreach (Person person in people)
            {
                Console.WriteLine(person);
            }
            Console.WriteLine("\nSorting by balance...");
            Array.Sort(people, new ComparePeopleByBalance());
            foreach (Person person in people)
            {
                Console.WriteLine(person);
            }
            Console.WriteLine("\nSorting by Age...");
            Array.Sort(people, new GeneralPersonComparer(PersonCompareMethod.ByAge));
            foreach (Person person in people)
            {
                Console.WriteLine(person);
            }
            Console.WriteLine("\nSorting by BirthMonth...");
            Array.Sort(people, new GeneralPersonComparer(PersonCompareMethod.ByBirthMonth));
            foreach (Person person in people)
            {
                Console.WriteLine(person);
            }
            Console.WriteLine("\nSorting by ID...");
            Array.Sort(people, new GeneralPersonComparer(PersonCompareMethod.ById));
            foreach (Person person in people)
            {
                Console.WriteLine(person);
            }
        }
    }
}