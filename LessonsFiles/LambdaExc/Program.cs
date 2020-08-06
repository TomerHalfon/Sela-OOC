//Docs:
//Lambda: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/lambda-operator
//Guide: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/lambda-expressions
using System;
using System.Collections.Generic;
using System.Linq;

namespace LambdaExc
{
    class Program
    {
        static void Main()
        {
            List<Person> people = new List<Person>();
            people.Add(new Person() { Name = "Yossi", Age = 20 });
            people.Add(new Person() { Name = "Assaf", Age = 30 });
            people.Add(new Person() { Name = "Zoe", Age = 17 });
            people.Add(new Person() { Name = "Dan", Age = 70 });

            Console.WriteLine("Original list");
            Console.WriteLine("--------------");
            PrintList(people);

            // using FindAll find all people whose Age is greater or equal to 20
            List<Person> subList = people.FindAll(p => p.Age >= 20);
            Console.WriteLine("People with Age greater or equal to 20: ");
            Console.WriteLine("--------------");
            PrintList(subList);


            // try : Find all people with Name != Yossi
            List<Person> subList2 = people.FindAll(p => !p.Name.Equals("Yossi"));
            Console.WriteLine("People with Name != Yossi: ");
            Console.WriteLine("---------------------------");
            PrintList(subList2);


            // try: Sort all people by Name using Sort method with comparison delegate
            people.Sort((x, y) => x.Name.CompareTo(y.Name));
            Console.WriteLine("People List Sorted By Name ");
            Console.WriteLine("---------------------------");
            PrintList(people);


            // try: Find the max Age of all people,  use Max
            int a = people.Max(x => x.Age);
            Console.WriteLine("Person with Max Age");
            Console.WriteLine("--------------------");
            Console.WriteLine("The age of the oldest person is: " + a);

            // try 
            Person firstOdd = people.First(p => p.Age % 2 != 0);
            Console.WriteLine("first person with Age Whose odd number is: " + firstOdd);            
        }
        public static void PrintList(List<Person> list)
        {
            foreach (Person p in list)
                Console.WriteLine(p);
        }
    }
}

