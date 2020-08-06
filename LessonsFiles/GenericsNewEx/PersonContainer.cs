using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenericsNewEx
{
    public class PersonContainer
    {
        // Students: TODO : add a member which is
        // a List<Person
        List<Person> _people = new List<Person>();

        public void addPerson(Person p)
        {
            // Students: TODO: add the person to the list
            if (p != null)
            {
                _people.Add(p);
            }
        }
        public void sort()
        {
            // Students: TODO: make the list sorted
            // using the List Sort method
            _people.Sort((x,y)=>x.Name.CompareTo(y.Name));
        }
        public void printContainer()
        {
            // Students: TODO: print the list
            foreach (Person person in _people)
            {
                Console.WriteLine(person);
            }
        }
        public Person findPerson(Predicate<Person> cond)
        {
            // Students: TODO: find a person
            // in the list given the predicate.
            // Use list Find method.
            return _people.Find(cond);
        }
    }
}
